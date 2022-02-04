using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class TwitchVoteCommand : MonoBehaviour, ITwitchCommandHandler
{
    public bool canVote = true;
    public string currentVoteType;
    public bool voteOnGoing = false;
    private List<string> voters = new List<string>();
    public Dictionary<string, int> choix = new Dictionary<string, int>();


    private void OnEnable()
    {
        Player.onHelpAsked += StartVote;
        GameManager.onHelpAsked += StartVote;
    }
    private void OnDisable()
    {
        Player.onHelpAsked -= StartVote;
        GameManager.onHelpAsked -= StartVote;
    }
    public void HandleCommand(TwitchCommandData data)
    {
        if (voteOnGoing)
        {
            if (choix.ContainsKey(data.Command))
            {
                choix[data.Command]++;
            }
        }
    }
    public void StartVote(Dictionary<string, int> choix, float time, Action<string> whenVoteStopped)
    {
        if (!voteOnGoing)
        {
            StartCoroutine(Timer(time, whenVoteStopped));
            this.choix = choix;
            voteOnGoing = true;
        }
    }
    private void StopVote(Action<string> whenVoteStopped)
    {
        voteOnGoing = false;
        string keyMax = choix.Aggregate((x,y) => x.Value > y.Value ? x : y).Key;
        choix = new Dictionary<string, int>();
        whenVoteStopped?.Invoke(keyMax);
    }
    private IEnumerator Timer(float time, Action<string> whenVoteStopped)
    {
        yield return new WaitForSecondsRealtime(time);
        StopVote(whenVoteStopped);
    }
}

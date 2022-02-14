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
    public Action<string, int> onVote;
    private void OnEnable()
    {
        Player.onHelpAsked += StartVote;
        GameManager.onHelpAsked += StartVote;
        TwitchMenuManager.onMapChoiceStart += StartVote;
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
            if (choix.ContainsKey(data.Argument))
            {
                choix[data.Argument]++;
                onVote?.Invoke(data.Argument, choix[data.Argument]);
            }
        }
    }
    public void StartVote(Dictionary<string, int> choix, float time, Action<string> whenVoteStopped, Action<string, int> onVote)
    {
        if (!voteOnGoing)
        {
            this.onVote = onVote;
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

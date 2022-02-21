using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchVote : MonoBehaviour, ITwitchCommandHandler
{
    public TwitchChat twitchchat;

    private bool vote = false;

    public void HandleCommand(TwitchCommandData data)
    {
        if(vote == false)
        {
            if (data.Argument == "start")
            {
                StartCoroutine(WaitBeforeVote());
            }         
        }
    }



    private IEnumerator WaitBeforeVote()
    {
        vote = true;
        yield return new WaitForSeconds(10f);
         vote = false;
    }


}

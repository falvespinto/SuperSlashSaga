using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchVoteCommand : MonoBehaviour, ITwitchCommandHandler
{
    public bool canVote = true;
    private int positif = 0;
    private int negatif = 0;

    public void HandleCommand(TwitchCommandData data)
    {
        if(canVote == true && data.Argument == "Domination")
        {

            StartCoroutine(WaitBeforeVote());
            switch (data.Argument)
            {
                case "Oui":
                    positif += positif;
                    break;
                case "Non":
                    negatif += negatif;
                    break;
            }

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitBeforeVote()
    {
        canVote = true;
        yield return new WaitForSeconds(10f);
        canVote = false;
    }
}

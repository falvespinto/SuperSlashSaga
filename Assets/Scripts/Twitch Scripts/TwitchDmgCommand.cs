using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchDmgCommand : MonoBehaviour, ITwitchCommandHandler
{
    public void HandleCommand(TwitchCommandData data)
    {
        switch (data.Argument)
        {
            case "J1":
                GameObject.Find("Player1").GetComponentInChildren<Player>().TakeDamage(10,"Twitch");
                break;
            case "J2":
                GameObject.Find("Player2").GetComponentInChildren<Player>().TakeDamage(10, "Twitch");
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchDmgCommand : MonoBehaviour, ITwitchCommandHandler
{
    public PlayerData J1;
    public PlayerData J2;
    public void HandleCommand(TwitchCommandData data)
    {
        switch (data.Argument)
        {
            case "J1":
                J1.GetComponentInChildren<Player>().TakeDamage(10,"Twitch");
                break;
            case "J2":
                J2.GetComponentInChildren<Player>().TakeDamage(10, "Twitch");
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchHypeCommand : MonoBehaviour, ITwitchCommandHandler
{
    PlayerData J1;
    PlayerData J2;

    public TwitchHypeCommand(PlayerData J1, PlayerData J2)
    {
        this.J1 = J1;
        this.J2 = J2;
    }

    public void HandleCommand(TwitchCommandData data)
    {
        J1.GetComponentInChildren<Player>().LetsDance();
        J2.GetComponentInChildren<Player>().LetsDance();
    }

}

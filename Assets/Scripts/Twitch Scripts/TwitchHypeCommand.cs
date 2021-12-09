using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchHypeCommand : MonoBehaviour, ITwitchCommandHandler
{
    public PlayerData J1;
    public PlayerData J2;

    public void HandleCommand(TwitchCommandData data)
    {
        J1.GetComponentInChildren<Player>().LetsDance();
        J2.GetComponentInChildren<Player>().LetsDance();
    }

}

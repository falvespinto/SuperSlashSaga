using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TwitchGameManager : MonoBehaviour
{
    public PlayerData P1Data;
    public PlayerData P2Data;
    private Player P1;
    private Player P2;
    private Player playerToHelp;
    private int sendHelpState = 0;
    public Action<string> whenVoteStopped;
    public Dictionary<string, int> choixHelp = new Dictionary<string, int>
    {
        {"force", 0},
        {"vitesse", 0},
        {"heal", 0},
        {"rien", 0}
    };
    public static Action<Dictionary<string, int>, float, Action<string>, Action<string, int>> onHelpAsked;

    private void Start()
    {
        P1 = P1Data.GetComponentInChildren<Player>();
        P2 = P2Data.GetComponentInChildren<Player>();
    }
    private void OnEnable()
    {
        whenVoteStopped += HelpPlayer;
    }
    private void OnDisable()
    {
        whenVoteStopped -= HelpPlayer;
    }

    private void Update()
    {
        if (MenuScript.nomDeChaine != null && TwitchChat.Instance.userExist)
        {
            if (P1 == null) P1 = P1Data.GetComponentInChildren<Player>();
            if (P2 == null) P2 = P2Data.GetComponentInChildren<Player>();
            if (sendHelpState == 0 && (Mathf.Abs(P1.currentHealth - P2.currentHealth) >= 30))
            {
                AskForHelpToTwitch();
            }
            else if (sendHelpState == 1 && (Mathf.Abs(P1.currentHealth - P2.currentHealth) >= 40))
            {
                AskForHelpToTwitch();
            }
            else if (sendHelpState == 2 && (Mathf.Abs(P1.currentHealth - P2.currentHealth) >= 50))
            {
                AskForHelpToTwitch();
            }
        }
    }

    private void AskForHelpToTwitch()
    {
        switch (sendHelpState)
         {
            case 0:
                if (UnityEngine.Random.Range(1, 2) == 1)
                {
                    sendHelpState++;
                }
                else
                {
                    StartHelp();
                    sendHelpState = 3;
                }
                break;
            case 1:
                if (UnityEngine.Random.Range(1, 2) == 1)
                {
                    sendHelpState++;
                }
                else
                {
                    StartHelp();
                    sendHelpState = 3;
                }
                break;
            case 2:
                StartHelp();
                sendHelpState++;
                break;
        }
    }

    private void HelpPlayer(string result)
    {
        switch (result)
        {
            case "force":
                break;
            case "vitesse":
                break;
            case "heal":
                playerToHelp.currentHealth += 25;
                playerToHelp.healthBar.SetHealth(playerToHelp.currentHealth);
                TwitchChat.Instance.SendIRCMessage("Le joueur " + (playerToHelp.playerIndex + 1) + "a été soigné.");
                break;
            case "rien":
                TwitchChat.Instance.SendIRCMessage("Le joueur " + (playerToHelp.playerIndex + 1) + "n'a pas reçu de bonus.");
                break;
        }
    }

    private void StartHelp()
    {
        playerToHelp = P1.currentHealth < P2.currentHealth ? P1 : P2;
        onHelpAsked?.Invoke(choixHelp, 30, whenVoteStopped, null);
        TwitchChat.Instance.SendIRCMessage("Voulez-vous aidez le joueur" + (playerToHelp.playerIndex + 1) + "?" +
            "heal: soigne le joueur" +
            "rien : refuser d'aider le joueur");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public bool P1HasSelected;
    public bool P2HasSelected;
    public bool hasStartedGame;
    public bool isTwitchActivated;
    public PlayerControls P1;
    public PlayerControls P2;
    public static string choixMap;
    public static string choixModifier;
    public static InputUser P1User;
    public static InputUser P2User;
    public static InputDevice P1Device;
    public static InputDevice P2Device;
    public static IAmanager managerIA;
    public static Action onCharactersSelected;


    private void OnEnable()
    {
        TwitchMenuManager.onVoteGlobalEnd += FinalInitGame;
    }

    private void OnDisable()
    {
        TwitchMenuManager.onVoteGlobalEnd -= FinalInitGame;
    }
    void Start()
    {
        P1HasSelected = false;
        P2HasSelected = false;
        hasStartedGame = false;
        managerIA = FindObjectOfType<IAmanager>();
        //FIX donner une valeure a isTwitchActivated en fonction de si twitch est activé, pour l'instant il est forcément activé donc pas encore
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStartedGame)
        {
            if (P1 != null && P2 != null)
            {
                if (P1.hasSelected && P2.hasSelected)
                {
                    InitGame();
                    hasStartedGame = true;
                }
            }
        }
    }

    void InitGame()
    {
        if (!MenuScript.chatSelectMap || MenuScript.nomDeChaine == null)
        {
            FinalInitGame("jour", "aucun");
        }
        else
        {
            onCharactersSelected?.Invoke();
        }

        
    }

    void FinalInitGame(string map, string modifier)
    {
        choixMap = map;
        choixModifier = modifier;
        if (P1.champSelect.currentSlot.GetComponent<LevelSelectItemScript>().name == "Yuetsu")
        {
            PlayerPrefs.SetInt("selectedCharacterP1", 0);
            P1User = P1.champSelect.GetComponent<PlayerInput>().user;
            P1Device = P1.champSelect.GetComponent<PlayerInput>().devices[0];
            Debug.Log("P1 Device Startgame : " + P1Device);
        }
        else
        {
            if (P1.champSelect.currentSlot.GetComponent<LevelSelectItemScript>().name == "Daiki")
            {
                PlayerPrefs.SetInt("selectedCharacterP1", 2);
                P1User = P1.champSelect.GetComponent<PlayerInput>().user;
                P1Device = P1.champSelect.GetComponent<PlayerInput>().devices[0];
                Debug.Log("P1 Device Startgame : " + P1Device);
            }
        }

        if (P2.champSelect.currentSlot.GetComponent<LevelSelectItemScript>().name == "Yuetsu" && !managerIA.bIsIA)
        {
            PlayerPrefs.SetInt("selectedCharacterP2", 0);
            P2User = P2.champSelect.GetComponent<PlayerInput>().user;
            P2Device = P2.champSelect.GetComponent<PlayerInput>().devices[0];
            Debug.Log("P2 Device Startgame : " + P2Device);
        }
        else
        {
            PlayerPrefs.SetInt("selectedCharacterP2", 1);
        }

        SceneManager.LoadScene("SampleScene");
    }
}

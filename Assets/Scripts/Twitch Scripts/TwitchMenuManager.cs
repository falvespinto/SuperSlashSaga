using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchMenuManager : MonoBehaviour
{
    public string resultatChoixMap;
    public string resultatChoixModifier;
    public Canvas twitchChoicesCanvas;
    public Dictionary<string, int> choixMap = new Dictionary<string, int>
    {
        {"jour", 0},
        {"nuit", 0}
    };
    public Dictionary<string, int> choixModifier = new Dictionary<string, int>
    {
        {"frénésie", 0},
        {"aucun", 0}
    };
    public static Action<Dictionary<string, int>, float, Action<string>, Action<string, int>> onMapChoiceStart;
    public static Action<string> onMapChoiceEnd;
    public static Action<string> onModifierChoiceEnd;
    public static Action<string, int> onVoteIncrease;
    public static Action<string, string> onVoteGlobalEnd;
    private void OnEnable()
    {
        StartGame.onCharactersSelected += OnCharacterSelected;
        onMapChoiceEnd += OnMapChoiceEnd;
        onModifierChoiceEnd += OnModifierChoiceEnd;
    }
    private void OnDisable()
    {
        StartGame.onCharactersSelected -= OnCharacterSelected;
        onMapChoiceEnd -= OnMapChoiceEnd;
    }
    private void OnCharacterSelected()
    {
        // affiche un écran de pop up avec les images des maps
        twitchChoicesCanvas.gameObject.SetActive(true);
        // Lance le vote 
        TwitchChat.Instance.SendIRCMessage("Choisissez la map ^^ hihi uwu");
        onMapChoiceStart?.Invoke(choixMap, 20, onMapChoiceEnd, onVoteIncrease);
    }

    void OnMapChoiceEnd(string choix)
    {
        resultatChoixMap = choix;
        TwitchChat.Instance.SendIRCMessage("Vous avez choisi la map : " + choix);
        // Lance le vote 
        TwitchChat.Instance.SendIRCMessage("Veuillez choisir le modificateur de gameplay de ce combat");
        onMapChoiceStart?.Invoke(choixModifier, 20, onModifierChoiceEnd, onVoteIncrease);
        // attend le résultat

        // Lance le combat
    }

    void OnModifierChoiceEnd(string choix)
    {
        resultatChoixModifier = choix;
        onVoteGlobalEnd?.Invoke(resultatChoixMap, resultatChoixModifier);
    }
}

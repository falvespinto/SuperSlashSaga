using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TwitchChoicesUI : MonoBehaviour
{
    public Image[] mapImages;
    public TextMeshProUGUI resultText;
    public Image[] modifiersImages;
    public Image resultMapImage;
    public Image resultModifierImage;
    public bool isInModifierChoice;

    private void OnEnable()
    {
        TwitchMenuManager.onMapChoiceEnd += SwapToModifiersChoices;
        TwitchMenuManager.onVoteIncrease += VoteIncrease;
        TwitchMenuManager.onModifierChoiceEnd += SwapToModifiersChoices;
    }
    private void OnDisable()
    {
        TwitchMenuManager.onMapChoiceEnd -= SwapToModifiersChoices;
        TwitchMenuManager.onModifierChoiceEnd -= SwapToModifiersChoices;
        TwitchMenuManager.onVoteIncrease -= VoteIncrease;
    }

    void SwapToModifiersChoices(string choice)
    {
        if (isInModifierChoice)
        {
            foreach (Image modifierImage in modifiersImages)
            {
                if (modifierImage.GetComponent<TwitchNodeName>().nodeName != choice)
                {
                    //mapImage.gameObject.SetActive(false);
                    LeanTween.scale(modifierImage.gameObject, new Vector3(0, 0, 0), 1f).setDestroyOnComplete(true);
                }
                else
                {
                    resultModifierImage = modifierImage;
                    LeanTween.move(modifierImage.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.5f);
                    LeanTween.size(modifierImage.GetComponent<RectTransform>(), new Vector2(750, 400), 0.5f).setOnComplete(EndChoice);
                    resultText.text = "Le chat a choisi le modificateur : " + choice;
                }
            }
        }
        else
        {
            foreach (Image mapImage in mapImages)
            {
                if (mapImage.GetComponent<TwitchNodeName>().nodeName != choice)
                {
                    //mapImage.gameObject.SetActive(false);
                    LeanTween.scale(mapImage.gameObject, new Vector3(0, 0, 0), 1f).setDestroyOnComplete(true);
                }
                else
                {
                    resultMapImage = mapImage;
                    LeanTween.move(mapImage.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.5f);
                    LeanTween.size(mapImage.GetComponent<RectTransform>(), new Vector2(750, 400), 0.5f).setOnComplete(NextChoice);
                    resultText.text = "Le chat a choisi la map : " + choice;
                    resultText.gameObject.SetActive(true);
                }
            }
        }
    }

    void VoteIncrease(string choixName, int nbVote)
    {
        if (!isInModifierChoice)
        {
            foreach (Image mapImage in mapImages)
            {
                if (mapImage.GetComponent<TwitchNodeName>().nodeName == choixName)
                {
                    mapImage.GetComponent<TwitchNodeName>().score.text = nbVote.ToString();
                }
            }
        }
        else
        {
            foreach (Image modifierImage in modifiersImages)
            {
                if (modifierImage.GetComponent<TwitchNodeName>().nodeName == choixName)
                {
                    modifierImage.GetComponent<TwitchNodeName>().score.text = nbVote.ToString();
                }
            }
        }

    }

    void NextChoice()
    {
        StartCoroutine(StartNextChoice());
    }
    
    void EndChoice()
    {
        //bounce
        StartCoroutine(EndChoiceTimer());
    }

    IEnumerator StartNextChoice()
    {
        //faire bounce le map choice + lui ajouter un cadre
        isInModifierChoice = true;
        yield return new WaitForSeconds(1f);
        resultText.text = "Veuillez voter pour le modificateur de combat";
        //yield return new WaitForSeconds(1.5f);
        HandleUINextChoice();
    }

    void HandleUINextChoice()
    {
        foreach (Image modifierImage in modifiersImages)
        {
            LeanTween.moveX(modifierImage.GetComponent<RectTransform>(), -500, 0.5f);
        }
        LeanTween.scale(resultMapImage.gameObject, new Vector3(0, 0, 0), 1f).setDestroyOnComplete(true);
    }

    IEnumerator EndChoiceTimer()
    {
        //faire bounce le map choice + lui ajouter un cadre
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

}

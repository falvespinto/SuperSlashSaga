using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //RAF changer d'image pour que ca aille avec le dialogue ET peut etre mettre en sombre l'image du personnage qui ne parle pas
    //RAF faire fonctionner la manette pour que quand on appuie sur A ca change de ligne de dialogue et quand on a plus de dialogue ca change de scene
    public GameObject tNameText;
    public GameObject dNameText;
    public Text tDialogueText;
    public GameObject gGameObjectStart;
    public GameObject gGameObjectContinue;
    public Queue<string> qSentences;

    public GameObject yuestu;
    public GameObject daiki;


    // Start is called before the first frame update
    void Start()
    {
        qSentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        qSentences.Clear();
        foreach(string sentence in dialogue.sSentences)
        {
            qSentences.Enqueue(sentence);
        }
        gGameObjectStart.SetActive(false);
        gGameObjectContinue.SetActive(true);
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(qSentences.Count == 0)
        {
            EndDialogue();
            // RAF changer de scene car fin du dialogue
            return;
        }
        string sentence = qSentences.Dequeue();
        if(sentence.Contains("Yuetsu :"))
        {
            sentence = sentence.Remove(0,8);
            dNameText.SetActive(false);
            tNameText.SetActive(true);
            daiki.SetActive(false);
            yuestu.SetActive(true);
        }
        else if(sentence.Contains("Daiki :"))
        {
            sentence = sentence.Remove(0,7);
            tNameText.SetActive(false);
            dNameText.SetActive(true);
            yuestu.SetActive(false);
            daiki.SetActive(true);
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
        tDialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            tDialogueText.text += letter;
            
            yield return new WaitForSeconds(0.1f);
        }
    }
    void EndDialogue()
    {
        Debug.Log("end");
    }
}

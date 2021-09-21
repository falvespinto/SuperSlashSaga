using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //RAF changer d'image pour que ca aille avec le dialogue ET peut etre mettre en sombre l'image du personnage qui ne parle pas
    //RAF faire fonctionner la manette pour que quand on appuie sur A ca change de ligne de dialogue et quand on a plus de dialogue ca change de scene
    public Text tNameText;
    public Text tDialogueText;
    public GameObject gGameObjectStart;
    public GameObject gGameObjectContinue;
    public Queue<string> qSentences;
    // Start is called before the first frame update
    void Start()
    {
        qSentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        tNameText.text = dialogue.sName;
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
        tDialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            tDialogueText.text += letter;
            
            yield return new WaitForEndOfFrame();//RAF changer pour qu'un message s'affiche toute les 0.1sec
        }
    }
    void EndDialogue()
    {
        Debug.Log("end");
    }
}

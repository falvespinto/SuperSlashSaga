using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManagerManette : MonoBehaviour
{
    //RAF changer d'image pour que ca aille avec le dialogue ET peut etre mettre en sombre l'image du personnage qui ne parle pas
    //RAF faire fonctionner la manette pour que quand on appuie sur A ca change de ligne de dialogue et quand on a plus de dialogue ca change de scene
    public GameObject tNameText;
    public GameObject dNameText;
    public GameObject pNameText;
    public GameObject iNameText;
    public GameObject boiteDialogue;
    public Text tDialogueText;
    public GameObject gGameObjectStart;
    public GameObject gGameObjectContinue;
    public GameObject gGameObjectFinir;
    public Queue<string> qSentences;

    public GameObject yuestu;
    public GameObject daiki;
    public GameObject pereDaiki;
    public GameObject yuestuOmbre;
    public GameObject daikiOmbre;


    public int chapitre = 0;
    private int i = 0;
    public Dialogue dialogue;


    // Start is called before the first frame update
    void Start()
    {
        qSentences = new Queue<string>();
        i++;
        if (i == 1)
        {

            qSentences.Clear();
            foreach (string sentence in dialogue.sSentences)
            {
                qSentences.Enqueue(sentence);
            }
            gGameObjectStart.SetActive(false);
            gGameObjectContinue.SetActive(true);
            boiteDialogue.SetActive(true);
            Debug.Log("Start");
            DisplayNextSentence();
        }
    }


    public void Play(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            i++;
            if (i == 1)
            {

                qSentences.Clear();
                foreach (string sentence in dialogue.sSentences)
                {
                    qSentences.Enqueue(sentence);
                }
                gGameObjectStart.SetActive(false);
                gGameObjectContinue.SetActive(true);
                boiteDialogue.SetActive(true);
                Debug.Log("Start");
                DisplayNextSentence();
            }
            if (i >= 2)
            {
                DisplayNextSentence();
                Debug.Log("Continue");
            }
        }
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
        if (qSentences.Count == 1)
        {
            Debug.Log(qSentences.Count);
            gGameObjectContinue.SetActive(false);
            gGameObjectFinir.SetActive(true);
        }

        if (qSentences.Count == 0)
        {
            EndDialogue();
            // RAF changer de scene car fin du dialogue
            return;
        }
        string sentence = qSentences.Dequeue();
        if(sentence.Contains("Yuetsu1 :"))
        {
            sentence = sentence.Remove(0,9);
            dNameText.SetActive(false);
            tNameText.SetActive(true);
            daiki.SetActive(false);
            yuestu.SetActive(true);
            chapitre = 1;
        }
        else if(sentence.Contains("Daiki1 :"))
        {
            sentence = sentence.Remove(0,8);
            tNameText.SetActive(false);
            dNameText.SetActive(true);
            pNameText.SetActive(false);
            iNameText.SetActive(false);
            yuestu.SetActive(false);
            daiki.SetActive(true);
            pereDaiki.SetActive(false);
            daikiOmbre.SetActive(false);
            pereDaiki.SetActive(true);
            chapitre = 1;
        }
        else if(sentence.Contains("Père1 de Daiki :"))
        {
            sentence = sentence.Remove(0, 16);
            Debug.Log("a");
            tNameText.SetActive(false);
            dNameText.SetActive(false);
            pNameText.SetActive(true);
            pereDaiki.SetActive(true);
            daiki.SetActive(false);
            daikiOmbre.SetActive(true);
            chapitre = 1;

        }
        else if (sentence.Contains("??? :"))
        {
            sentence = sentence.Remove(0, 5);
            tNameText.SetActive(false);
            dNameText.SetActive(false);
            iNameText.SetActive(true);
            pereDaiki.SetActive(true);
            daiki.SetActive(false);
            daikiOmbre.SetActive(true);
            yuestu.SetActive(false);
            chapitre = 1;
        }

        if (sentence.Contains("Yuetsu2 :"))
        {
            sentence = sentence.Remove(0, 9);
            dNameText.SetActive(false);
            tNameText.SetActive(true);
            iNameText.SetActive(false);
            daiki.SetActive(false);
            yuestu.SetActive(true);
            daikiOmbre.SetActive(true);
            yuestuOmbre.SetActive(false);
            chapitre = 2;
        }
        else if (sentence.Contains("Daiki2 :"))
        {
            sentence = sentence.Remove(0, 8);
            tNameText.SetActive(false);
            dNameText.SetActive(true);
            pNameText.SetActive(false);
            iNameText.SetActive(false);
            yuestu.SetActive(false);
            daiki.SetActive(true);
            pereDaiki.SetActive(false);
            yuestuOmbre.SetActive(true);
            daikiOmbre.SetActive(false);
            chapitre = 2;
        }
        else if (sentence.Contains("Père2 de Daiki :"))
        {
            sentence = sentence.Remove(0, 16);
            tNameText.SetActive(false);
            dNameText.SetActive(false);
            pNameText.SetActive(true);
            iNameText.SetActive(false);
            daiki.SetActive(false);
            chapitre = 2;
        }

        if (sentence.Contains("Yuetsu3 :"))
        {
            sentence = sentence.Remove(0, 9);
            dNameText.SetActive(false);
            tNameText.SetActive(true);
            pereDaiki.SetActive(false);
            iNameText.SetActive(false);
            daiki.SetActive(false);
            yuestu.SetActive(true);
            yuestuOmbre.SetActive(false);
            daikiOmbre.SetActive(true);
            chapitre = 3;
        }
        else if (sentence.Contains("Daiki3 :"))
        {
            sentence = sentence.Remove(0, 8);
            tNameText.SetActive(false);
            dNameText.SetActive(true);
            pNameText.SetActive(false);
            iNameText.SetActive(false);
            yuestu.SetActive(false);
            pereDaiki.SetActive(false);
            daiki.SetActive(true);
            daikiOmbre.SetActive(false);
            yuestuOmbre.SetActive(true);
            chapitre = 3;
        }
        else if (sentence.Contains("Père3 de Daiki :"))
        {
            sentence = sentence.Remove(0, 16);
            tNameText.SetActive(false);
            dNameText.SetActive(false);
            iNameText.SetActive(false);
            pNameText.SetActive(true);
            daiki.SetActive(false);
            pereDaiki.SetActive(true);
            chapitre = 3;
        }

        if (sentence.Contains("Yuetsu4 :"))
        {
            sentence = sentence.Remove(0, 9);
            dNameText.SetActive(false);
            tNameText.SetActive(true);
            pereDaiki.SetActive(false);
            iNameText.SetActive(false);
            daiki.SetActive(false);
            yuestu.SetActive(true);
            daikiOmbre.SetActive(true);
            yuestuOmbre.SetActive(false);
            chapitre = 4;
        }
        else if (sentence.Contains("Daiki4 :"))
        {
            sentence = sentence.Remove(0, 8);
            tNameText.SetActive(false);
            dNameText.SetActive(true);
            pNameText.SetActive(false);
            iNameText.SetActive(false);
            yuestu.SetActive(false);
            pereDaiki.SetActive(false);
            daiki.SetActive(true);
            daikiOmbre.SetActive(false);
            yuestuOmbre.SetActive(true);
            chapitre = 4;
        }
        else if (sentence.Contains("Père4 de Daiki :"))
        {
            sentence = sentence.Remove(0, 16);
            tNameText.SetActive(false);
            dNameText.SetActive(false);
            iNameText.SetActive(false);
            pNameText.SetActive(true);
            daiki.SetActive(false);
            pereDaiki.SetActive(true);
            chapitre = 4;
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
        if(chapitre == 1)
        {
            SceneManager.LoadScene("SceneCampagneDebut");
        }
        if(chapitre == 2)
        {
            SceneManager.LoadScene("SceneCampagneYuetsuFirstCombat");
        }
        if(chapitre == 3)
        {
            SceneManager.LoadScene("SceneCampagneFlashbackCombat");
        }
        if (chapitre == 4)
        {
            SceneManager.LoadScene("Crédit");
        }
    }
}

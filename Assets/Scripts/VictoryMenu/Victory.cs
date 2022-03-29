using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Victory : MonoBehaviour
{
    private int SelectedButton = 1;
    [SerializeField]
    private int NumberOfButtons;
    private bool verificationMenu = false;
    private bool verificationOption = false;
    private int winner;
    public Transform positionWinner;
    public Transform positionLooser;
    public List<GameObject> listPrefab;
    private Animator animatorWinner;
    private Animator animatorLooser;

    void Start()
    {
        winner = GameManager.winner;

        if (winner == 1)
        {
            GameObject.Find("joueur2").SetActive(false);
            if (LoadCharacter.selectedCharacterP1 == 0 || LoadCharacter.selectedCharacterP1 == 1)
            {
                listPrefab[0].transform.position = positionWinner.position;
                listPrefab[0].transform.rotation = positionWinner.rotation;
                listPrefab[0].transform.localScale = positionWinner.localScale;
                Instantiate(listPrefab[0]);
            }
            else
            {
                listPrefab[2].transform.position = positionWinner.position;
                listPrefab[2].transform.rotation = positionWinner.rotation;
                listPrefab[2].transform.localScale = positionWinner.localScale;
                Instantiate(listPrefab[2]);
            }

            if (LoadCharacter.selectedCharacterP2 == 0 || LoadCharacter.selectedCharacterP2 == 1)
            {
                listPrefab[5].transform.position = positionLooser.position;
                listPrefab[5].transform.rotation =  positionLooser.rotation;
                listPrefab[5].transform.localScale  = positionLooser.localScale;
                Instantiate(listPrefab[5]);
            }
            else
            {
                listPrefab[7].transform.position = positionLooser.position;
                listPrefab[7].transform.rotation = positionLooser.rotation;
                listPrefab[7].transform.localScale = positionLooser.localScale;
                Instantiate(listPrefab[7]);
            }
        }
        else
        {
            GameObject.Find("joueur1").SetActive(false);
            if (LoadCharacter.selectedCharacterP2 == 0 || LoadCharacter.selectedCharacterP2 == 1)
            {
                listPrefab[4].transform.position = positionWinner.position;
                listPrefab[4].transform.rotation = positionWinner.rotation;
                listPrefab[4].transform.localScale = positionWinner.localScale;
                Instantiate(listPrefab[4]);
            }
            else
            {
                listPrefab[6].transform.position = positionWinner.position;
                listPrefab[6].transform.rotation = positionWinner.rotation;
                listPrefab[6].transform.localScale = positionWinner.localScale;
                Instantiate(listPrefab[6]);
            }

            if (LoadCharacter.selectedCharacterP1 == 0 || LoadCharacter.selectedCharacterP1 == 1)
            {
                listPrefab[1].transform.position = positionLooser.position;
                listPrefab[1].transform.rotation = positionLooser.rotation;
                listPrefab[1].transform.localScale = positionLooser.localScale;
                Instantiate(listPrefab[1]);
            }
            else
            {
                listPrefab[3].transform.position = positionLooser.position;
                listPrefab[3].transform.rotation = positionLooser.rotation;
                listPrefab[3].transform.localScale = positionLooser.localScale;
                Instantiate(listPrefab[5]);
            }
        }
    }


    private void OnPlay()
    {
        if (SelectedButton == 1)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            SceneManager.LoadScene("Menu Principal");
        }
    }
}

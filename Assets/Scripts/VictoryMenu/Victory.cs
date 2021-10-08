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
    public GameObject j1;
    public GameObject j2;
    void Start()
    {
        winner = Player.winner;
        if(winner == 1)
        {
            GameObject.Find("joueur2").SetActive(false);
            j1.transform.position = positionWinner.position;
            j1.transform.rotation = positionWinner.rotation;
            j1.transform.localScale = positionWinner.localScale;
            Instantiate(j1);
            j2.transform.position = positionLooser.position;
            j2.transform.rotation = positionLooser.rotation;
            j2.transform.localScale = positionLooser.localScale;
            Instantiate(j2);
        }
        else
        {
            GameObject.Find("joueur1").SetActive(false);
            j2.transform.position = positionWinner.position;
            j2.transform.rotation = positionWinner.rotation;
            j2.transform.localScale = positionWinner.localScale;
            Instantiate(j2);
            j1.transform.position = positionLooser.position;
            j1.transform.rotation = positionLooser.rotation;
            j1.transform.localScale = positionLooser.localScale;
            Instantiate(j1);
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

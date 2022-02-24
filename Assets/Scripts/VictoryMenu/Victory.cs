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
    public GameObject winnerJ1;
    public GameObject winnerJ2;
    public GameObject looserJ1;
    public GameObject looserJ2;
    private Animator animatorWinner;
    private Animator animatorLooser;

    void Start()
    {
        winner = GameManager.winner;
        if(winner == 1)
        {
            GameObject.Find("joueur2").SetActive(false);
            winnerJ1.transform.position = positionWinner.position;
            winnerJ1.transform.rotation = positionWinner.rotation;
            winnerJ1.transform.localScale = positionWinner.localScale;
            Instantiate(winnerJ1);
            looserJ2.transform.position = positionLooser.position;
            looserJ2.transform.rotation = positionLooser.rotation;
            looserJ2.transform.localScale = positionLooser.localScale;
            Instantiate(looserJ2);
        }
        else
        {
            GameObject.Find("joueur1").SetActive(false);
            winnerJ2.transform.position = positionWinner.position;
            winnerJ2.transform.rotation = positionWinner.rotation;
            winnerJ2.transform.localScale = positionWinner.localScale;
            Instantiate(winnerJ2);
            looserJ1.transform.position = positionLooser.position;
            looserJ1.transform.rotation = positionLooser.rotation;
            looserJ1.transform.localScale = positionLooser.localScale;
            Instantiate(looserJ1);
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

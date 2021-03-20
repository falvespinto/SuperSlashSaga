using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Victory : MonoBehaviour
{
    public GameObject Point, mainMenu;
    private int SelectedButton = 1;
    [SerializeField]
    private int NumberOfButtons;
    private bool verificationMenu = false;
    private bool verificationOption = false;
    private int winner;
    public Transform ButtonPosition1;


    void Start()
    {
        winner = Player.winner;
        if(winner == 1)
        {
            GameObject.Find("joueur2").SetActive(false);
        }
        else
        {
            GameObject.Find("joueur1").SetActive(false);
        }
        FindObjectOfType<AudioManager>().Play("ambiance");
    }


    private void OnPlay()
    {
        if (SelectedButton == 1)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            FindObjectOfType<AudioManager>().Play("bruitage");
            SceneManager.LoadScene("Menu Principal");
        }

    }

    private void MoveThePointer()
    {
        // Moves the pointer
        if (SelectedButton == 1)
        {
            Point.transform.position = ButtonPosition1.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
    }

}

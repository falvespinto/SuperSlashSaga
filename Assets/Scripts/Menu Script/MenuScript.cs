using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Audio;


public class MenuScript : MonoBehaviour
{
    public GameObject Point, optionsMenu, mainMenu;
  
    private int SelectedButton = 1;
    [SerializeField]
    private int NumberOfButtons;
    private bool verificationMenu = false;
    private bool verificationOption = false;
    AudioManager musique = new AudioManager();

    public Transform ButtonPosition1;
    public Transform ButtonPosition2;
    public Transform ButtonPosition3;
    public Transform ButtonPosition4;
    public Transform ButtonPosition5;
    public Transform ButtonPosition6;
    public Transform ButtonPosition7;
    public Transform ButtonPosition8;


    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MusiqueMenu");
    }


    private void OnPlay()
    {
        if (SelectedButton == 1)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            Debug.Log("Campagne");
        }
        else if (SelectedButton == 2)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            SceneManager.LoadScene("CharacterSelection");
        }
        else if (SelectedButton == 3)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            Debug.Log("Online");
        }
        else if (SelectedButton == 4)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            Debug.Log("Options");
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
            verificationOption = true;
            Point.transform.position = ButtonPosition6.position;
            SelectedButton = 6;

        }
        else if (SelectedButton == 5)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            Application.Quit();
            Debug.Log("Quit");
        }

       else if (SelectedButton == 6)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            Debug.Log("Augmentation");
            musique.IncreaseVolume(0.1f);
        }

        else if (SelectedButton == 7)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            Debug.Log("Descente");
            musique.DecreaseVolume(0.1f);
        }

        else if (SelectedButton == 8)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            Debug.Log("Back");
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
            Point.transform.position = ButtonPosition1.position;
            SelectedButton = 1;
        }

    }
    private void OnButtonUp()
    {
        // Checks if the pointer needs to move down or up, in this case the poiter moves up one button
        if (verificationOption == false)
        {
            if (SelectedButton > 1)
            {
                SelectedButton -= 1;
            }
            MoveThePointer();
            return;
        }
    }
    private void OnButtonDown()
    {
        // Checks if the pointer needs to move down or up, in this case the poiter moves down one button
        if (verificationMenu == false)
        {
            if (SelectedButton < NumberOfButtons)
            {
                SelectedButton += 1;
            }
            MoveThePointer();
            return;
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
        else if (SelectedButton == 2)
        {
            Point.transform.position = ButtonPosition2.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 3)
        {
            Point.transform.position = ButtonPosition3.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 4)
        {
            Point.transform.position = ButtonPosition4.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationMenu = false;
        }
        else if (SelectedButton == 5)
        {
            Point.transform.position = ButtonPosition5.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationMenu = true;
            verificationOption = false;
        }
        else if (SelectedButton == 6)
        {
            verificationOption = true;
            Point.transform.position = ButtonPosition6.position;
            verificationMenu = false;
        }
        else if (SelectedButton == 7)
        {
            verificationOption = false;
            Point.transform.position = ButtonPosition7.position;
        }

        else if (SelectedButton == 8)
        {
            Point.transform.position = ButtonPosition8.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationOption = false;
        }

    }
    
}

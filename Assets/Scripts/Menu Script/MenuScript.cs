using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Audio;


public class MenuScript : MonoBehaviour
{
    public GameObject Point, optionsMenu, mainMenu ,campagneMenu, versusMenu, streamMenu;

    private int SelectedButton = 1;
    [SerializeField]
    private int NumberOfButtons;
    private bool verificationMenu = false;
    private bool verificationOption = false;
    private bool verificationCampagne = false;
    private bool verificationVersus = false;
    private bool verificationStream = false;
    AudioManager musique = new AudioManager();

    public Transform ButtonPosition1;
    public Transform ButtonPosition2;
    public Transform ButtonPosition3;
    public Transform ButtonPosition4;
    public Transform ButtonPosition5;
    public Transform ButtonPosition6;
    public Transform ButtonPosition7;
    public Transform ButtonPosition8;
    public Transform ButtonPosition9;

    public bool cooldown = false;


    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MusiqueMenu");
    }


    public void Play()
    {
        if (cooldown == false)
        {
            cooldown = true;
            Invoke("setCooldown", 0.3f);

            if (SelectedButton == 1)
            {
                //Utilisation du bouton campagne
                Debug.Log("Campagne");
                mainMenu.SetActive(false);
                campagneMenu.SetActive(true);
                verificationCampagne = true;
                Point.transform.position = ButtonPosition7.position;
                SelectedButton = 7;

            }
            else if (SelectedButton == 2)
            {
                //utilisation du bouton versus
                Debug.Log("Versus");
                mainMenu.SetActive(false);
                versusMenu.SetActive(true);
            }
            else if (SelectedButton == 3)
            {
                // Utilisation du bouton Twitch
                Debug.Log("Twitch");
                mainMenu.SetActive(false);
                streamMenu.SetActive(true);
            }
            else if (SelectedButton == 4)
            {
                // Selection du bouton Option
                Debug.Log("Options");
                mainMenu.SetActive(false);
                optionsMenu.SetActive(true);
                verificationOption = true;
                Point.transform.position = ButtonPosition6.position;
                SelectedButton = 6;

            }
            else if (SelectedButton == 5)
            {
                // utilisation du bouton Quitter
                Application.Quit();
                Debug.Log("Quit");
            }

            else if (SelectedButton == 6)
            {
                //Utilisation du bouton back des options
                Debug.Log("Back");
                optionsMenu.SetActive(false);
                mainMenu.SetActive(true);
                verificationOption = false;
                verificationMenu = false;
                Point.transform.position = ButtonPosition1.position;
                SelectedButton = 1;
            }

            else if (SelectedButton == 7)
            {
                //Utilisation du bouton nouvelle campagne
                Debug.Log("nouveau");
                //SceneManager.LoadScene("CharacterSelection");
            }

            else if (SelectedButton == 8)
            {
                Debug.Log("continuer");
                //utilisation du bouton continuer campagne
                //SceneManager.LoadScene("CharacterSelection");
            }

            else if (SelectedButton == 9)
            {
                //utilisation du bouton back campagne
                campagneMenu.SetActive(false);
                mainMenu.SetActive(true);
                verificationCampagne = false;
                verificationMenu = false;
                Point.transform.position = ButtonPosition1.position;
                SelectedButton = 1;
            }
        }

    }
    public void ButtonUp()
    {
        // Checks if the pointer needs to move down or up, in this case the poiter moves up one button
        if (verificationOption == false)
        {

            if (cooldown == false)
            {
                cooldown = true;
                Invoke("setCooldown", 0.3f);
                if (SelectedButton > 1)
                {
                    SelectedButton -= 1;
                }
                MoveThePointer();
                return;
            }
        }
    }
    public void ButtonDown()
    {
        // Checks if the pointer needs to move down or up, in this case the poiter moves down one button
        if (verificationMenu == false)
        {
            if (cooldown == false)
            {
                cooldown = true;
                Invoke("setCooldown", 0.3f);
                if (SelectedButton < NumberOfButtons)
                {
                    SelectedButton += 1;
                }
                MoveThePointer();
                return;
            }
        }
    }


    public void MoveThePointer()
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
            Point.transform.position = ButtonPosition6.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationOption = false;
        }
        else if (SelectedButton == 7)
        {
            Point.transform.position = ButtonPosition7.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationCampagne = true;
        }
        else if (SelectedButton == 8)
        {
            Point.transform.position = ButtonPosition8.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 9)
        {
            Point.transform.position = ButtonPosition9.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationCampagne = false;
        }
    }

    private void setCooldown()
    {
        cooldown = false;
    }

}

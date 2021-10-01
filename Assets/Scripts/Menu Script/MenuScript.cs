﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Audio;


public class MenuScript : MonoBehaviour
{
    public GameObject pointMenu, pointOption, pointCampagne, pointVersus, pointStream, optionsMenu, mainMenu ,campagneMenu, versusMenu, streamMenu;

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
    public Transform ButtonPosition10;
    public Transform ButtonPosition11;
    public Transform ButtonPosition12;
    public Transform ButtonPosition13;
    public Transform ButtonPosition14;
    public Transform ButtonPosition15;
    public Transform ButtonPosition16;
    public Transform ButtonPosition17;

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
                pointMenu.SetActive(false);
                pointCampagne.SetActive(true);
                SelectedButton = 7;

            }
            else if (SelectedButton == 2)
            {
                //utilisation du bouton versus
                Debug.Log("Versus");
                mainMenu.SetActive(false);
                versusMenu.SetActive(true);
                pointMenu.SetActive(false);
                pointVersus.SetActive(true);
                SelectedButton = 10;
            }
            else if (SelectedButton == 3)
            {
                // Utilisation du bouton Twitch
                Debug.Log("Twitch");
                mainMenu.SetActive(false);
                streamMenu.SetActive(true);
                pointMenu.SetActive(false);
                pointStream.SetActive(true);
                SelectedButton = 14;
            }
            else if (SelectedButton == 4)
            {
                // Selection du bouton Option
                Debug.Log("Options");
                mainMenu.SetActive(false);
                optionsMenu.SetActive(true);
                pointMenu.SetActive(false);
                pointOption.SetActive(true);
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
                pointOption.SetActive(false);
                pointMenu.SetActive(true);
                SelectedButton = 1;
                pointMenu.transform.position = ButtonPosition1.position;
                pointOption.transform.position = ButtonPosition6.position;
            }

            else if (SelectedButton == 7)
            {
                //Utilisation du bouton nouvelle campagne
                Debug.Log("Continuer");
                //SceneManager.LoadScene("CharacterSelection");
            }

            else if (SelectedButton == 8)
            {
                Debug.Log("Nouvelle partie");
                //utilisation du bouton nouvelle partie campagne
            }

            else if (SelectedButton == 9)
            {
                //utilisation du bouton back campagne
                campagneMenu.SetActive(false);
                mainMenu.SetActive(true);
                pointCampagne.SetActive(false);
                pointMenu.SetActive(true);
                pointMenu.transform.position = ButtonPosition1.position;
                SelectedButton = 1;
                pointCampagne.transform.position = ButtonPosition15.position;
            }

            else if (SelectedButton == 10)
            {
                //utilisation du bouton jcj
                SceneManager.LoadScene("CharacterSelection 1");      
            }

            else if (SelectedButton == 11)
            {
                //utilisation du bouton jce
                Debug.Log("JCE");
                SceneManager.LoadScene("CharacterSelectionIA");
            }

            else if (SelectedButton == 12)
            {
                //utilisation du bouton entrainement 
                Debug.Log("Entrainement");
            }

            else if (SelectedButton == 13)
            {
                //utilisation du bouton back 
                Debug.Log("back");
                mainMenu.SetActive(true);
                versusMenu.SetActive(false);
                pointMenu.SetActive(true);
                pointVersus.SetActive(false);
                SelectedButton = 1;
                pointMenu.transform.position = ButtonPosition1.position;
                pointVersus.transform.position = ButtonPosition7.position;

            }

            else if (SelectedButton == 14)
            {
                //utilisation du bouton nom de chaine
                Debug.Log("nom Chaine");
            }

            else if (SelectedButton == 15)
            {
                //utilisation du bouton nom user
                Debug.Log("nom user");
            }

            else if (SelectedButton == 16)
            {
                //utilisation du bouton clé
                Debug.Log("clé");
            }

            else if (SelectedButton == 17)
            {
                //utilisation du bouton back
                Debug.Log("back");
                mainMenu.SetActive(true);
                streamMenu.SetActive(false);
                pointMenu.SetActive(true);
                pointStream.SetActive(false);
                SelectedButton = 1;
                pointMenu.transform.position = ButtonPosition1.position;
                pointStream.transform.position = ButtonPosition11.position;
            }


        }

    }
    public void ButtonUp()
    {
        // Checks if the pointer needs to move down or up, in this case the poiter moves up one button

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
    public void ButtonDown()
    {
        // Checks if the pointer needs to move down or up, in this case the poiter moves down one button
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


    public void MoveThePointer()
    {
        // Moves the pointer
        if (SelectedButton == 1)
        {
            pointMenu.transform.position = ButtonPosition1.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 2)
        {     
            pointMenu.transform.position = ButtonPosition2.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 3)
        {
            pointMenu.transform.position = ButtonPosition3.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 4)
        {
            pointMenu.transform.position = ButtonPosition4.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 5)
        {
            pointMenu.transform.position = ButtonPosition5.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 6)
        {
            pointOption.transform.position = ButtonPosition6.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 7)
        {
            pointCampagne.transform.position = ButtonPosition15.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 8)
        {
            pointCampagne.transform.position = ButtonPosition16.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 9)
        {
            pointCampagne.transform.position = ButtonPosition17.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 10)
        {
            pointVersus.transform.position = ButtonPosition7.position;
            FindObjectOfType<AudioManager>().Play("percution");
        }
        else if (SelectedButton == 11)
        {
            pointVersus.transform.position = ButtonPosition8.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationCampagne = false;
        }
        else if (SelectedButton == 12)
        {
            pointVersus.transform.position = ButtonPosition9.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationCampagne = false;
        }
        else if (SelectedButton == 13)
        {
            pointVersus.transform.position = ButtonPosition10.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationCampagne = false;
        }
        else if (SelectedButton == 14)
        {
            pointStream.transform.position = ButtonPosition11.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationCampagne = false;
        }
        else if (SelectedButton == 15)
        {
            pointStream.transform.position = ButtonPosition12.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationCampagne = false;
        }
        else if (SelectedButton == 16)
        {
            pointStream.transform.position = ButtonPosition13.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationCampagne = false;
        }
        else if (SelectedButton == 17)
        {
            pointStream.transform.position = ButtonPosition14.position;
            FindObjectOfType<AudioManager>().Play("percution");
            verificationCampagne = false;
        }
    }

    private void setCooldown()
    {
        cooldown = false;
    }

}

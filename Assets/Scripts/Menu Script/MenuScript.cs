using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour
{
    public GameObject Point, optionsMenu, mainMenu;
  
    private int SelectedButton = 1;
    [SerializeField]
    private int NumberOfButtons;

    public Transform ButtonPosition1;
    public Transform ButtonPosition2;
    public Transform ButtonPosition3;
    public Transform ButtonPosition4;
    public Transform ButtonPosition5;
    public Transform ButtonPosition6;
    public Transform ButtonPosition7;



    private void OnPlay()
    {
        if (SelectedButton == 1)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (SelectedButton == 2)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            Debug.Log("Campagne");
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
            Debug.Log("Slide");
        }


        else if (SelectedButton == 7)
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
        if (SelectedButton > 1)
        {
            SelectedButton -= 1;
        }
        MoveThePointer();
        return;
    }
    private void OnButtonDown()
    {
        // Checks if the pointer needs to move down or up, in this case the poiter moves down one button
        if (SelectedButton < NumberOfButtons)
        {
            SelectedButton += 1;
        }
        MoveThePointer();
        return;
    }
    private void MoveThePointer()
    {
        // Moves the pointer
        if (SelectedButton == 1)
        {
            Point.transform.position = ButtonPosition1.position;
        }
        else if (SelectedButton == 2)
        {
            Point.transform.position = ButtonPosition2.position;
        }
        else if (SelectedButton == 3)
        {
            Point.transform.position = ButtonPosition3.position;
        }
        else if (SelectedButton == 4)
        {
            Point.transform.position = ButtonPosition4.position;
        }
        else if (SelectedButton == 5)
        {
            Point.transform.position = ButtonPosition5.position;
        }
        else if (SelectedButton == 6)
        {
            Point.transform.position = ButtonPosition6.position;
        }
        else if (SelectedButton == 7)
        {
            Point.transform.position = ButtonPosition7.position;
        }
    }
    
}

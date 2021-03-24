using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Point, pauseMenu, Menu;
    private int SelectedButton = 1;
    [SerializeField]
    private int NumberOfButtons;

    public Transform ButtonPosition1;
    public Transform ButtonPosition2;
    public Transform ButtonPosition3;
    public Transform ButtonPosition4;

    public static bool GameIsPaused = false;


    void Start()
    {
        //FindObjectOfType<AudioManager>().Play("MusiqueMenu");
    }

    private void OnPlay()
    {
        if (SelectedButton == 1)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            Debug.Log("Resume");
            Resume();
        }
        else if (SelectedButton == 2)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            Debug.Log("Selection perso");
            Time.timeScale = 1f;
            SceneManager.LoadScene("CharacterSelection");
        }
        else if (SelectedButton == 3)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            Debug.Log("Option");
        }
        else if (SelectedButton == 4)
        {
            // When the button with the pointer is clicked, this piece of script is activated
            Debug.Log("RetourMenu");
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu Principal");
        }

    }

    private void Update()
    {

    }

    private void OnPause()
    {
        Menu.SetActive(false);
        if (GameIsPaused)
        {
            pauseMenu.SetActive(false);
            Resume();
            Menu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(true);
            Pause();
        }
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    private void OnButtonUp()
    {
        if(GameIsPaused)
        {
            // Checks if the pointer needs to move down or up, in this case the poiter moves up one button
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
        if(GameIsPaused)
        {
            // Checks if the pointer needs to move down or up, in this case the poiter moves down one button
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
        }
    }
}

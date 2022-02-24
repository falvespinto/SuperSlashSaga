using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Point, PointMenu, PointCommande, pauseMenu, Menu, commandeMenu;
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

    public static bool GameIsPaused = false;
    public bool cooldown = false;


    void Start()
    {
        //FindObjectOfType<AudioManager>().Play("MusiqueMenu");
    }

    public void Play()
    {
        if (cooldown == false)
        {
            cooldown = true;
            StartCoroutine(setCooldown());
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
                Debug.Log("Commande");
                pauseMenu.SetActive(false);
                Time.timeScale = 0f;
                commandeMenu.SetActive(true);
                SelectedButton = 7;
                
            }
            else if (SelectedButton == 4)
            {
                // When the button with the pointer is clicked, this piece of script is activated
                Debug.Log("Option");
                Menu.SetActive(true);
                Time.timeScale = 0f;
                pauseMenu.SetActive(false);
                Point.SetActive(false);
                PointMenu.SetActive(true);
                SelectedButton = 6;
                PointMenu.transform.position = ButtonPosition6.position;
            }
            else if (SelectedButton == 5)
            {
                // When the button with the pointer is clicked, this piece of script is activated
                Debug.Log("RetourMenu");
                Time.timeScale = 1f;
                SceneManager.LoadScene("Menu Principal");
            }
            else if (SelectedButton == 6)
            {
                // When the button with the pointer is clicked, this piece of script is activated
                Debug.Log("Retour");
                Time.timeScale = 0f;
                Menu.SetActive(false);
                pauseMenu.SetActive(true);
                Point.SetActive(true);
                PointMenu.SetActive(false);
                SelectedButton = 1;
                Point.transform.position = ButtonPosition1.position;
            }
            else if (SelectedButton == 7)
            {
                // When the button with the pointer is clicked, this piece of script is activated
                Debug.Log("Retour");
                Time.timeScale = 0f;
                commandeMenu.SetActive(false);
                pauseMenu.SetActive(true);
                Point.SetActive(true);
                PointMenu.SetActive(false);
                SelectedButton = 1;
                Point.transform.position = ButtonPosition1.position;
            }
        }

    }

    private void Update()
    {
       
    }

    public void pause()
    {
            if (GameIsPaused)
            {
                Resume();    
            }
            else
            {
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
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void ButtonUp()
    {
        if (GameIsPaused)
        {
            // Checks if the pointer needs to move down or up, in this case the poiter moves up one button
            if (cooldown == false)
            {
                cooldown = true;
                StartCoroutine(setCooldown());
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
        if (GameIsPaused)
        {
            // Checks if the pointer needs to move down or up, in this case the poiter moves down one button
            if (cooldown == false)
            {
                cooldown = true;
                StartCoroutine(setCooldown());
                if (SelectedButton < NumberOfButtons)
                {
                    SelectedButton += 1;
                }
                MoveThePointer();
                return;
            }
        }
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
            PointMenu.transform.position = ButtonPosition6.position;
        }

    }
    private IEnumerator setCooldown()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        cooldown = false;
    }

    public void Selecte(InputAction.CallbackContext ctx)
    {
        if(ctx.started)
        {
            ChapitreManager.instance.chapitre();
        }
    }

}

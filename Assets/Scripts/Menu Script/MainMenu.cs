using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject menuFirstButton, optionsCloseButton, campagneButton, onlineButton, quitButton;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MusiqueMenu");
    }

    public void VersusGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


}

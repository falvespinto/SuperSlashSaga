using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public bool P1HasSelected;
    public bool P2HasSelected;
    public bool hasStartedGame;
    public PlayerControls P1;
    public PlayerControls P2;
    public static InputDevice P1Device;
    public static InputDevice P2Device;
    void Start()
    {
        P1HasSelected = false;
        P2HasSelected = false;
        hasStartedGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStartedGame)
        {
            if (P1 != null && P2 != null)
            {
                if (P1.hasSelected && P2.hasSelected)
                {
                    Invoke("InitGame", 3f);
                    hasStartedGame = true;
                }
            }
        }
    }

    void InitGame()
    {
        Debug.Log("change scene");
        if (P1.champSelect.currentSlot.GetComponent<LevelSelectItemScript>().name == "Yuetsu")
        {
            PlayerPrefs.SetInt("selectedCharacterP1", 0);
            P1Device = P1.champSelect.GetComponent<PlayerInput>().devices[0];
        }
        else
        {
            Debug.Log("bah y'a rien d'autre chakal, Molière");
        }

        if (P2.champSelect.currentSlot.GetComponent<LevelSelectItemScript>().name == "Yuetsu")
        {
            PlayerPrefs.SetInt("selectedCharacterP2", 0);
            P2Device = P2.champSelect.GetComponent<PlayerInput>().devices[0];
        }
        else
        {
            Debug.Log("bah y'a rien d'autre chakal, Molière");
        }

        SceneManager.LoadScene("SampleScene");

    }
}

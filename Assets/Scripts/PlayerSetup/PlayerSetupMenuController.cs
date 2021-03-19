using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using System.Runtime.InteropServices.ComTypes;

public class PlayerSetupMenuController : MonoBehaviour
{

    private int PlayerIndex;
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private GameObject readyPanel;
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private Button readyButton;
    private float ignoreInputTime = 1.5f;
    private bool inputEnabled;
    private GameObject cursor;
    private GameObject char1;
    private GameObject char2;
    private GameObject char3;
    private GameObject char4;

    public void Awake()
    {
        //playerControls.CharacterSelect.Droite.performed += ctx => Droite();
        //playerControls.CharacterSelect.Bas.performed += ctx => Bas();
    }
    public void SetPlayerIndex(int pi)
    {
        PlayerIndex = pi;
        titleText.SetText("Player " + (pi + 1).ToString());
        ignoreInputTime = Time.time + ignoreInputTime;
        if (PlayerIndex == 0)
        {
            cursor = GameObject.Find("P1Cursor");
        }
        else
        {
            cursor = GameObject.Find("P2Cursor");
        }

        char1 = GameObject.Find("character1");
        char2 = GameObject.Find("character2");
        char3 = GameObject.Find("character3");
        char4 = GameObject.Find("character4");

    }

    // Update is called once per frame
    void Update()
    {
        

        if(Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }

    }
    public void SetColor(Material color)
    {
        if (!inputEnabled)
        {
            return;
        }
        PlayerConfigurationManager.Instance.SetPlayerColor(PlayerIndex, color);
        readyPanel.SetActive(true);
        readyButton.Select();
        menuPanel.SetActive(false);
    }

    public void MoveCursor()
    {

    }

    void Droite()
    {
        Debug.Log("droite");
        cursor.transform.position = new Vector3(-50,124,0);
    }
    void Bas()
    {
        Debug.Log("bas");
        cursor.transform.position = new Vector3(-103, 70, 0);
    }


    public void ReadyPlayer()
    {
        if (!inputEnabled)
        {
            return;
        }
        Debug.Log(PlayerIndex);
        PlayerConfigurationManager.Instance.ReadyPlayer(PlayerIndex);
        readyButton.gameObject.SetActive(false);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    private Vector2 movementInput;
    public int index;
    private PlayerControls[] test;
    public GameObject button;
    public LevelSelectScreenScript champSelect;
    public GameObject prefab;
    private GameObject instantiatePrefab;
    public bool hasSelected;
    public Texture[] playersIcons;
    public bool isInit = false;
    private void Awake()
    {
        champSelect = GetComponent<LevelSelectScreenScript>();
        champSelect.selector = gameObject;
        hasSelected = false;

    }
    private void Start()
    {
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.position = GameObject.Find("Row1_1").transform.position;
        test = GameObject.FindObjectsOfType<PlayerControls>();
        if (test.Length <= 1)
        {
            index = 0;
        }
        else
        {
            index = 1;
            gameObject.GetComponent<RawImage>().texture = playersIcons[1];
        }
        Invoke("Init", 0.1f);
        Debug.Log(index);


    }
    private void Update()
    {
        if (!hasSelected && isInit)
        {
            if (movementInput.x > 0)
            {
                champSelect.MoveSelector("right");
            }
            else if (movementInput.x < 0)
            {
                champSelect.MoveSelector("left");
            }
            else if (movementInput.y > 0)
            {
                champSelect.MoveSelector("up");
            }
            else if (movementInput.y < 0)
            {
                champSelect.MoveSelector("down");
            }
        }
    }
    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnSelect(InputAction.CallbackContext ctx) {
        if (ctx.canceled && isInit)
        {
            hasSelected = true;
            Debug.Log("perso a été select" + champSelect.currentSlot.GetComponent<LevelSelectItemScript>().name);
            if (index == 0)
            {
                GameObject.FindObjectOfType<StartGame>().P1 = this;
            }
            else if (index == 1)
            {
                GameObject.FindObjectOfType<StartGame>().P2 = this;
            }
            
        }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
            if(collider.GetComponent<PlayerControls>() != null)
        {
            button = collider.gameObject;
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerControls>() != null)
        {
            button = null;
        }
    }
    public void Init()
    {
        isInit = true;
    }

}

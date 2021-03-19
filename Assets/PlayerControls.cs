using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public float speed = 5;
    private UnityEngine.Vector2 movementInput;
    public int index;
    private PlayerControls[] test;
    public GameObject button;
    private LevelSelectScreenScript champSelect;
    public GameObject prefab;
    private GameObject instantiatePrefab;
    public Texture[] playersIcons;
    private void Awake()
    {
        champSelect = GetComponent<LevelSelectScreenScript>();
        champSelect.selector = gameObject;
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
        Debug.Log(index);


    }
    private void Update()
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
    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    
    public void OnPress(InputAction.CallbackContext ctx) => Selected();
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

    public void Selected()
    {
        Debug.Log("oui");

    }
}

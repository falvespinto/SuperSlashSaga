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
    public Sprite[] playersIcons;
    public bool isInit = false;
    public GameObject spawnPositionJ1;
    public GameObject spawnPositionJ2;
    public GameObject yuetsuPrefab;
    private GameObject currentPrefabSpawn;
    private GameObject characterSpawn;
    private bool isSpawnableJ1;
    private bool isSpawnableJ2;
    private int indexJ1;
    private int indexJ2;

    private void Awake()
    {
        champSelect = GetComponent<LevelSelectScreenScript>();
        champSelect.selector = gameObject;
        hasSelected = false;
        currentPrefabSpawn = null;
        isSpawnableJ1 = true;
        isSpawnableJ2 = true;

        FindObjectOfType<AudioManager>().Play("selectionPerso");
        prefab.transform.SetParent(GameObject.Find("Canvas").transform);
        prefab.transform.position = GameObject.Find("Row1_1").transform.position;
        
    }
    private void Start()
    {
        test = GameObject.FindObjectsOfType<PlayerControls>();
        if (test.Length <= 1)
        {
            index = 0;
            indexJ1 = 1;
        }
        else
        {
            index = 1;
            indexJ2 = 1;
            gameObject.GetComponent<Image>().sprite = playersIcons[1];
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

        if (indexJ1 == 1 && isSpawnableJ1 == true)
        {
            InstanciateJ1(yuetsuPrefab);
            if (currentPrefabSpawn != characterSpawn)
            {
                currentPrefabSpawn = characterSpawn;
                isSpawnableJ1 = false;
            }
        }
        else if (indexJ2 == 1 && isSpawnableJ2 == true)
        {

            InstanciateJ2(yuetsuPrefab);
            if (currentPrefabSpawn != characterSpawn)
            {
                currentPrefabSpawn = characterSpawn;
                isSpawnableJ2 = false;
            }

        }
        
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
            FindObjectOfType<AudioManager>().Play("ajoutJoueur");
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
    public GameObject InstanciateJ1(GameObject character)
    {
        characterSpawn = Instantiate(character) as GameObject;
        characterSpawn.transform.position = spawnPositionJ1.transform.position;
        characterSpawn.transform.rotation = spawnPositionJ1.transform.rotation;
        characterSpawn.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        return characterSpawn;
    }
    public GameObject InstanciateJ2(GameObject character)
    {
        characterSpawn = Instantiate(character) as GameObject;
        characterSpawn.transform.position = spawnPositionJ2.transform.position;
        characterSpawn.transform.rotation = spawnPositionJ2.transform.rotation;
        characterSpawn.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        return characterSpawn;
    }
}

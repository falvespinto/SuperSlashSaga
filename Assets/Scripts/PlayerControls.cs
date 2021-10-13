using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;


/// <summary>
/// RAF Si possible trouver comment changer le device affecté a l'instance de cette classe.
/// Sinon créer une var qui prend ia.PlayerControls
/// </summary>
public class PlayerControls : MonoBehaviour
{
    public initialisationBandeau initialisationBandeau;
    private Vector2 movementInput;
    public int index;
    private PlayerControls[] test;
    public GameObject button;
    public LevelSelectScreenScript champSelect;
    public IAmanager managerIA;
    public GameObject prefab;
    private GameObject instantiatePrefab;
    public bool hasSelected;
    public Sprite[] playersIcons;
    public bool isInit = false;
    public GameObject spawnPositionJ1;
    public GameObject spawnPositionJ2;
    public GameObject spawnValidationJ1;
    public GameObject spawnValidationJ2;
    public GameObject yuetsuPrefab;
    public GameObject yuetsuPrefabJ2;
    public GameObject startPlayer1;
    public GameObject startPlayer2;
    private GameObject currentPrefabSpawn;
    private GameObject iaPrefabSpawn;
    private GameObject characterSpawn;
    private GameObject validationSpawn;
    public bool isSpawnableJ1;
    public bool isSpawnableJ2;
    private bool isSpawnableIA;
    private int indexJ1;
    private int indexJ2;
    private int indexIA;
    private GameObject ia;

    private void Awake()
    {
        startPlayer1 = GameObject.Find("press start j1");
        startPlayer2 = GameObject.Find("press start j2");
        champSelect = GetComponent<LevelSelectScreenScript>();
        champSelect.selector = gameObject;
        hasSelected = false;
        currentPrefabSpawn = null;
        iaPrefabSpawn = null;
        isSpawnableJ1 = true;
        isSpawnableJ2 = true;
        isSpawnableIA = true;
        managerIA = FindObjectOfType<IAmanager>();
        initialisationBandeau = FindObjectOfType<initialisationBandeau>();
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
            gameObject.GetComponentInChildren<Image>().sprite = playersIcons[0];
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Destroy(startPlayer1);
        }

        else
        {
            if (managerIA.bIsIA)
            {
                index = 1;
                indexIA = 1;
                gameObject.GetComponentInChildren<Image>().sprite = playersIcons[2];
                gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else{
                index = 1;
                indexJ2 = 1;
                gameObject.GetComponentInChildren<Image>().sprite = playersIcons[1];
                gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Destroy(startPlayer2);
            }

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
            /*else if (movementInput.y > 0)
            {
                champSelect.MoveSelector("up");
            }
            else if (movementInput.y < 0)
            {
                champSelect.MoveSelector("down");
            }*/
        }
        if (hasSelected && isInit && index == 0 && managerIA.bIsIA && ia != null && !ia.GetComponent<PlayerControls>().hasSelected)
        {
            if (movementInput.x > 0)
            {
                ia.GetComponent<PlayerControls>().champSelect.MoveSelector("right"); 
            }
            else if (movementInput.x < 0)
            {
                ia.GetComponent<PlayerControls>().champSelect.MoveSelector("left");
            }
            /*else if (movementInput.y > 0)
            {
                ia.GetComponent<PlayerControls>().champSelect.MoveSelector("up");
            }
            else if (movementInput.y < 0)
            {
                ia.GetComponent<PlayerControls>().champSelect.MoveSelector("down");
            }*/
        }
    }
    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnSelect(InputAction.CallbackContext ctx) {
        
        if (isInit && !hasSelected)
        {
            
            if (indexJ1 == 1 && isSpawnableJ1 == true)
            {
                InstanciateJ1(yuetsuPrefab);
                initialisationBandeau.validationJ1.SetActive(true);
                if (currentPrefabSpawn != characterSpawn)
                {
                    currentPrefabSpawn = characterSpawn;
                    isSpawnableJ1 = false;
                }
            }
            else if (indexJ2 == 1 && isSpawnableJ2 == true)
            {
                InstanciateJ2(yuetsuPrefabJ2);
                initialisationBandeau.validationJ2.SetActive(true);
                if (currentPrefabSpawn != characterSpawn)
                {

                    currentPrefabSpawn = characterSpawn;
                    isSpawnableJ2 = false;
                }

            }
            else if (indexIA == 1)
            {
                InstanciateJ2(yuetsuPrefabJ2);
                initialisationBandeau.validationJ2.SetActive(true);
                if (currentPrefabSpawn != characterSpawn)
                {

                    currentPrefabSpawn = characterSpawn;
                    isSpawnableJ2 = false;
                }

            }

            Debug.Log(isInit);
        if (ctx.canceled && isInit)
        {
            hasSelected = true;
            Debug.Log("perso a été select" + champSelect.currentSlot.GetComponent<LevelSelectItemScript>().name);

            if (index == 0)
            {
                GameObject.FindObjectOfType<StartGame>().P1 = this;
                if (managerIA.bIsIA)
                {
                       ia = Instantiate(managerIA.selector);
                }
            } 
                    
            
            else if (index == 1)
            {
                GameObject.FindObjectOfType<StartGame>().P2 = this;
            }
            FindObjectOfType<AudioManager>().Play("ajoutJoueur");
        }
        }
        else if (isInit && hasSelected && managerIA.bIsIA && ia != null)
        {
            ia.GetComponent<PlayerControls>().SelectIA();
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

    void SelectIA()
    {
        if (managerIA.bIsIA && isSpawnableIA && indexIA == 1 && !hasSelected)
        {
            InstanciateJ2(yuetsuPrefabJ2);
            if (iaPrefabSpawn != characterSpawn)
            {
                iaPrefabSpawn = characterSpawn;
                isSpawnableIA = false;
                GameObject.FindObjectOfType<StartGame>().P2 = this;
                hasSelected = true;
            }
        }
    }


}

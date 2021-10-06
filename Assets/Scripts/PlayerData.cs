using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int playerIndex;
    public Transform camera;
    public Camera cam;
    public HealthBar healthBar;
    public ManaBar manabar;
    public PermutationBar permutationBar;
    public LayerMask enemyLayer;
    public LayerMask playerLayer;
    public GameObject playerTarget;
    public Transform target;
    IAmanager iaManager;


    // Start is called before the first frame update
    void Awake()
    {
        camera = cam.transform;
    }
    private void Start()
    {
        iaManager = GetComponent<IAmanager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (playerTarget.GetComponentInChildren<Player>() != null && !StartGame.managerIA.bIsIA)
            {
                target = playerTarget.GetComponentInChildren<Player>().transform;
            }
            else if(playerTarget.GetComponentInChildren<IA>() != null && StartGame.managerIA.bIsIA)
            {
                target = playerTarget.GetComponentInChildren<IA>().transform;
            }
            else if (playerTarget.GetComponentInChildren<Player>() != null && StartGame.managerIA.bIsIA && playerTarget.GetComponent<PlayerData>().playerIndex == 0)
            {
                target = playerTarget.GetComponentInChildren<Player>().transform;
            }
        }
    }
}

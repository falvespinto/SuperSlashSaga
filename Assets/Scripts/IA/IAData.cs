using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAData : MonoBehaviour
{
    public int playerIndex;
    public Transform camera;
    public Camera cam;
    public HealthBar healthBar;
    public LayerMask enemyLayer;
    public LayerMask playerLayer;
    public GameObject playerTarget;
    public Transform target;


    // Start is called before the first frame update
    void Awake()
    {

        camera = cam.transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (playerTarget.GetComponentInChildren<IA>() != null)
            {
                target = playerTarget.GetComponentInChildren<IA>().transform;
            }
        }
    }
}
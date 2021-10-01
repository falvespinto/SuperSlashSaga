using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParadeIA : MonoBehaviour
{
    public bool paradeButtonPressed;
    public bool paradeButtonReleased;
    public bool isParing;
    public bool isAttacking;
    public bool isRunAttacking;
    public PlayerAttackIA playerAttackIA;
    public Transform target;
    public PlayerData playerData;
    private Player player;
    private bool neverPared;
    public void Awake()
    {
        playerData = GetComponentInParent<PlayerData>();
        player = GetComponent<Player>();
        playerAttackIA = GetComponent<PlayerAttackIA>();
    }
    public void Start()
    {

        target = playerData.target;
        paradeButtonPressed = false;
        paradeButtonReleased = false;
        neverPared = true;
    }

    void Update()
    {


    }

    public void InitializedParadeAttack()
    {
        if (!playerAttackIA.isAttacking && !playerAttackIA.isParing && !playerAttackIA.isRunAttacking)
        {
            playerAttackIA.LookAtTarget();
            playerAttackIA.isParing = true;
            Debug.Log("is Paring");
            //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // bloque les déplacements horizontaux
            playerAttackIA.m_Animator.SetBool("IsParing", true);
        }
    }
    public void FinalizedParadeAttack()
    {
        if (!playerAttackIA.isAttacking && playerAttackIA.isParing && !playerAttackIA.isRunAttacking)
        {
            playerAttackIA.isParing = false;
            Debug.Log("has stopped paring");
            playerAttackIA.m_Animator.SetBool("IsParing", false);
        }
    }
}

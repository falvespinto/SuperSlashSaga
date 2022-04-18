using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Parade : MonoBehaviour
{
    public bool paradeButtonPressed;
    public bool paradeButtonReleased;
    public bool isParing;
    public bool isAttacking;
    public bool isRunAttacking;
    public PlayerController playerController;
    public PlayerAttack playerAttack;
    public Transform target;
    public PlayerData playerData;
    public Player player;
    private bool neverPared;
    public GameObject shield;
    public static Action<string> OnParadeUsed;
    public void Awake()
    {
        playerData = GetComponentInParent<PlayerData>();
        playerController = GetComponent<PlayerController>();
        player = GetComponent<Player>();
        playerAttack = GetComponent<PlayerAttack>();
    }
    public void Start()
    {
        target = playerData.target;
        paradeButtonPressed = false;
        paradeButtonReleased = false;
        neverPared = true;
    }

    public void InitializedParadeAttack()
    {
        OnParadeUsed?.Invoke("Parade");
        shield.SetActive(true);
        playerAttack.LookAtTarget();
        playerAttack.isParing = true;
        Debug.Log("is Paring");
        //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // bloque les déplacements horizontaux
        playerAttack.m_Animator.SetBool("IsParing", true);
    }
    public void FinalizedParadeAttack()
    {
        if (!playerAttack.isAttacking && playerAttack.isParing)
        {
            shield.SetActive(false);
            playerAttack.isParing = false;
            Debug.Log("has stopped paring");
            playerAttack.m_Animator.SetBool("IsParing", false);
        }
    }
}

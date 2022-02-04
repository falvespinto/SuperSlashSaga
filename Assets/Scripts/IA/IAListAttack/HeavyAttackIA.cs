using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttackIA : MonoBehaviour
{
    public bool isAttacking;
    public bool isParing;
    private bool heavyCanAutoCancel;
    public float heavyAttackTime;
    public PlayerData playerData;
    public Player player;
    public PlayerAttackIA playerAttackIA;
    public float lightAttackTime;
    public void Awake()
    {
        playerData = GetComponentInParent<PlayerData>();
        player = GetComponent<Player>();
        playerAttackIA = GetComponent<PlayerAttackIA>();
    }
    public void Start()
    {
        UpdateAnimClipTimes();
        heavyCanAutoCancel = true;
    }
    private void Update()
    {

    }
    public void PerformedHeavyAttack(string attackType)
    {
        // A revoir (constante)(attackType)(vite)(stp)
        if (!playerAttackIA.isAttacking && !playerAttackIA.isParing && !playerAttackIA.isRunAttacking && attackType == "normal")
        {
            if (heavyCanAutoCancel)
            {
                Vector3 direction = playerAttackIA.LookAtTarget();
                playerAttackIA.isAttacking = true;
                // Cela retirerait le fait de pouvoir choisir frame par frame si on applique un coup mais serait peut être plus performant ?
                Debug.Log("is attacking heavy");
                // m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // bloque les déplacements horizontaux
                playerAttackIA.swordAttacks.damage = 20;
                playerAttackIA.swordAttacks.attackType = "Heavy";
                // ChangeAnimationState(m_Punch);
                playerAttackIA.m_Animator.SetTrigger("HeavyAttack");
                StartCoroutine(playerAttackIA.ForwardAttack(0.2f, direction, 0.30f));
                //StartCoroutine(AttackAutoCancel(heavyAttackTime, heavyCanAutoCancel));
                Invoke("AttackComplete", heavyAttackTime - 0.7f);

            }
        }

        if (!playerAttackIA.isAttacking && !playerAttackIA.isParing && !playerAttackIA.isRunAttacking && attackType == "bottom")
        {
            Vector3 direction = playerAttackIA.LookAtTarget();
            playerAttackIA.isAttacking = true;
            // Cela retirerait le fait de pouvoir choisir frame par frame si on applique un coup mais serait peut être plus performant ?
            Debug.Log("is attacking bottom heavy");
            // m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // bloque les déplacements horizontaux
            playerAttackIA.swordAttacks.damage = 20;
            // à changer pê
            playerAttackIA.swordAttacks.attackType = "Heavy";
            // ChangeAnimationState(m_Punch);
            // à changer
            playerAttackIA.m_Animator.SetTrigger("BottomHeavyAttack");
            StartCoroutine(playerAttackIA.ForwardAttack(heavyAttackTime - 0.5f, direction, 0.05f));
            Invoke("AttackComplete", heavyAttackTime - 0.5f);
            FindObjectOfType<AudioManager>().Play("epee");
        }
    }


    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = playerAttackIA.m_Animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "HeavyYuetsu":
                    heavyAttackTime = clip.length;
                    break;
                case "BottomHeavy":
                    lightAttackTime = clip.length / 1.5f;
                    break;
            }

        }
    }
    // A remplacer par une coroutine plus tard
    public void AttackComplete()
    {
        Debug.Log("testeuu");
        playerAttackIA.isAttacking = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    public bool isAttacking;
    public bool isParing;
    private bool heavyCanAutoCancel;
    public float heavyAttackTime;
    public CharacterController controller;
    public PlayerData playerData;
    public Player player;
    public PlayerController playerController;
    public PlayerAttack playerAttack;
    public float lightAttackTime;
    public float timeBeforeCancelHeavy;

    private bool cooldown = false;


    public void Awake()
    {
        playerData = GetComponentInParent<PlayerData>();
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
        if (!playerAttack.isAttacking && !playerAttack.isParing && attackType == "normal" && !player.isInCombo)
        {
            playerController.isRunning = false;
            Vector3 direction = playerAttack.LookAtTarget();
            playerAttack.isAttacking = true;
            // Cela retirerait le fait de pouvoir choisir frame par frame si on applique un coup mais serait peut être plus performant ?
            Debug.Log("is attacking heavy");
            // m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // bloque les déplacements horizontaux
            playerAttack.swordAttacks.damage = 20;
            playerAttack.swordAttacks.attackType = "Heavy";
            // ChangeAnimationState(m_Punch);
            playerAttack.m_Animator.SetTrigger("HeavyAttack");
            StartCoroutine(playerAttack.ForwardAttack(0.2f, direction, 0.30f));
            //StartCoroutine(AttackAutoCancel(heavyAttackTime, heavyCanAutoCancel));
            Invoke("AttackComplete", timeBeforeCancelHeavy);
            StartCoroutine(setCooldown());
            player.playerAudio.playSoundLourd();
        }


        if (attackType == "bottom")
        {
            Vector3 direction = playerAttack.LookAtTarget();
            playerAttack.isAttacking = true;
            // Cela retirerait le fait de pouvoir choisir frame par frame si on applique un coup mais serait peut être plus performant ?
            Debug.Log("is attacking bottom heavy");
            // m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // bloque les déplacements horizontaux
            playerAttack.swordAttacks.damage = 20;
            // à changer pê
            playerAttack.swordAttacks.attackType = "Heavy";
            // ChangeAnimationState(m_Punch);
            // à changer
            playerAttack.m_Animator.SetTrigger("BottomHeavyAttack");
            StartCoroutine(playerAttack.ForwardAttack(heavyAttackTime - 0.5f, direction, 0.05f));
            Invoke("AttackComplete", heavyAttackTime - 0.5f);
            StartCoroutine(setCooldown());
            player.playerAudio.playSoundLourd();
        }
    }


    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = playerAttack.m_Animator.runtimeAnimatorController.animationClips;
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
        playerAttack.isAttacking = false;
    }

    private IEnumerator setCooldown()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        Debug.Log("j'attend");
        cooldown = false;
    }
}

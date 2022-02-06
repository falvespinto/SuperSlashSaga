using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LightAttack : MonoBehaviour
{
    public enum LightComboState
    {
        NONE,
        LIGHT_1,
        LIGHT_2,
        LIGHT_3,
        LIGHT_4
    }

    #region Variables
    public float lightAttackTime;
    public float heavyAttackTime;
    public float light2AttackTime;
    public float light3AttackTime;
    public float lightComboAttackTime;
    public float bottomLightAttackTime;
    public float bottomLight2AttackTime;
    public Player player;
    public PlayerAttack playerAttack;
    public PlayerData playerData;
    public float default_Combo_Timer = 1f;
    public float current_Combo_Timer;
    public bool isAttacking;
    public LightComboState lightComboState;
    public BottomLightComboState bottomLightComboState;
    public bool isParing;
    public bool isLightAttacking;
    public PlayerController playerController;
    public CharacterController controller;
    public GameObject vfxSword;
    private Rect posCam;
    private Rect posCamOpponent;
    public Vector3 playerHitPositionOffSet;
    #endregion


    //Times
    public float timeBeforeCancelLight1;
    public float timeBeforeCancelLight2;
    public float timeBeforeCancelLight3;
    public float timeBeforeCancelLight4;
    public float timeOfCombo;
    //Log
    public static Action<int> onComboTriggered;

    private void Awake()
    {
        //   m_Rigidbody = GetComponent<Rigidbody>();
        playerData = GetComponentInParent<PlayerData>();
        playerController = GetComponent<PlayerController>();
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        isLightAttacking = false;
        isAttacking = false;
        lightComboState = LightComboState.NONE;
        bottomLightComboState = BottomLightComboState.NONE;
        current_Combo_Timer = default_Combo_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        ResetComboState();
    }

    #region PerformedLightAttack method
    public void PerformedLightAttack(string attackType)
    {
        if (attackType == "normal")
        {
            if ((int)lightComboState >= 4 || lightComboState == null)
            {
                Debug.Log("il est allez dans light combo state >= 4");
            }
            else
            {
                isLightAttacking = true;
                playerAttack.isAttacking = true;
                lightComboState++;
                Debug.Log(lightComboState);
                if (lightComboState == LightComboState.LIGHT_1)
                {
                    current_Combo_Timer = default_Combo_Timer;
                    playerAttack.playerHit = null;
                    playerController.isRunning = false;
                    Vector3 direction = playerAttack.LookAtTarget();
                    playerAttack.SetAttacksData(7,"Light");
                    playerAttack.m_Animator.SetTrigger("LightAttack");
                    if (!playerAttack.isHeNearEnemy()) StartCoroutine(playerAttack.ForwardAttack(lightAttackTime - 0.6f, direction, 0.05f));
                    Invoke("AttackComplete", timeBeforeCancelLight1);
                    player.playerAudio.playSoundLeger();
                }

                if (lightComboState == LightComboState.LIGHT_2)
                {
                    current_Combo_Timer = default_Combo_Timer;
                    playerAttack.playerHit = null;
                    playerController.isRunning = false;
                    Vector3 direction = playerAttack.LookAtTarget();
                    // Joue attaque 1 du combo de coup léger
                    //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
                    playerAttack.SetAttacksData(8, "Light");
                    // ChangeAnimationState(m_Punch);
                    playerAttack.m_Animator.SetTrigger("LightAttack2");
                    if (!playerAttack.isHeNearEnemy()) StartCoroutine(playerAttack.ForwardAttack(light2AttackTime - 0.5f, direction, 0.05f));
                    Invoke("AttackComplete", timeBeforeCancelLight2);
                    player.playerAudio.playSoundLeger();
                    //m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim
                }

                if (lightComboState == LightComboState.LIGHT_3)
                {
                    current_Combo_Timer = default_Combo_Timer;
                    playerAttack.playerHit = null;
                    playerController.isRunning = false;
                    Vector3 direction = playerAttack.LookAtTarget();
                    playerAttack.SetAttacksData(8, "Light");
                    playerAttack.m_Animator.SetTrigger("LightAttack3");
                    if (!playerAttack.isHeNearEnemy()) StartCoroutine(playerAttack.ForwardAttack(light2AttackTime - 0.5f, direction, 0.05f));
                    Invoke("AttackComplete", timeBeforeCancelLight3);
                    player.playerAudio.playSoundLeger();
                }

                if (lightComboState == LightComboState.LIGHT_4)
                {
                    playerAttack.playerHit = null;
                    playerController.isRunning = false;
                    Vector3 direction = playerAttack.LookAtTarget();
                    playerAttack.m_Animator.SetTrigger("LightAttackCombo");
                    Invoke("AttackComplete", timeBeforeCancelLight4);
                    playerAttack.SetAttacksData(6, "Light");
                    StartCoroutine(playerAttack.ForwardAttack(0.2f, direction, 0.3f));
                    player.playerAudio.playSoundLeger();
                }

                if (lightComboState == LightComboState.NONE)
                {

                }


            }

        }
        else
        {
            if (!playerAttack.isParing)
            {

            }
        }

    } 
    #endregion

    void ResetComboState()
    {
        if (isLightAttacking)
        {
            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {
                Debug.Log("combo reset");
                lightComboState = LightComboState.NONE;
                isLightAttacking = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }
    public IEnumerator InfuseSword(float time)
    {
        yield return new WaitForSeconds(time);
        try
        {
            vfxSword.SetActive(true);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void CheckPerformFullCombo()
    {
        if (playerAttack.playerHit != null)
        {
            StartCoroutine(PerformFullCombo());
        }
    }
    public IEnumerator PerformFullCombo()
    {
         if (playerAttack.playerHit != null)
         {
            if (playerAttack.playerHit.GetComponent<Permutation>().hasPermuted == false)
            {
                onComboTriggered?.Invoke(player.playerIndex);
                playerAttack.isAttacking = true;
                playerController.isRunning = false;
                playerAttack.playerHit.GetComponent<Player>().isInCombo = true;
                player.isInCombo = true;
                yield return new WaitForSeconds(0.3f);
                playerAttack.playerHit.GetComponent<CharacterController>().enabled = false;
                controller.enabled = false;
                Vector3 positionAtk = GameObject.Find("ReplacePointAtk").transform.position;
                Quaternion rotationAtk = GameObject.Find("ReplacePointAtk").transform.rotation;
                transform.position = positionAtk;
                transform.rotation = rotationAtk;
                Vector3 positionRcv = GameObject.Find("ReplacePointRcv" + player.characterName).transform.position;
                Quaternion rotationRcv = GameObject.Find("ReplacePointRcv" + player.characterName).transform.rotation;
                playerAttack.playerHit.transform.position = positionRcv;
                playerAttack.playerHit.transform.rotation = rotationRcv;
                controller.enabled = true;
                playerAttack.playerHit.GetComponent<CharacterController>().enabled = true;
                //StartCoroutine(InfuseSword(0.15f));
                StartCoroutine(playerAttack.ResetCombo(timeOfCombo));
                Invoke("AttackComplete", timeOfCombo);
                StartCoroutine(playerAttack.playerHit.GetComponent<Player>().goInEnemyCombo(timeOfCombo));
                GetComponent<TimeLineController>().PerformFullCombo(playerAttack.m_Animator, playerAttack.playerHit.GetComponent<Animator>());
            }
        }
    }
    // A remplacer par une coroutine plus tard
    public void AttackComplete()
    {
        playerAttack.isAttacking = false;
    }

}

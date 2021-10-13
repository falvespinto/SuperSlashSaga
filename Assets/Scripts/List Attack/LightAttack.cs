using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float default_Combo_Timer = 2f;
    public float default_BottomCombo_Timer = 2f;
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

    private void Awake()
    {
        //   m_Rigidbody = GetComponent<Rigidbody>();
        playerData = GetComponentInParent<PlayerData>();
        playerController = GetComponent<PlayerController>();
    }
    void Start()
    {
        UpdateAnimClipTimes();
        default_Combo_Timer = light3AttackTime;
        default_BottomCombo_Timer = bottomLightAttackTime + bottomLight2AttackTime - 1.2f;
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

            }
            else
            {
                isLightAttacking = true;
                playerAttack.isAttacking = true;
                current_Combo_Timer = default_Combo_Timer;
                lightComboState++;
                if (lightComboState == LightComboState.LIGHT_1)
                {
                    playerAttack.playerHit = null;
                    playerController.isRunning = false;
                    Vector3 direction = playerAttack.LookAtTarget();
                    // Joue attaque 1 du combo de coup l�g�
                    //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // d�placements horizontaux bloqu�s
                    playerAttack.swordAttacks.damage = 7;
                    playerAttack.swordAttacks.attackType = "Light";
                    // ChangeAnimationState(m_Punch);
                    playerAttack.m_Animator.SetTrigger("LightAttack");
                    StartCoroutine(playerAttack.ForwardAttack(lightAttackTime - 0.6f, direction, 0.05f));
                    Invoke("AttackComplete", timeBeforeCancelLight1);
                    player.playerAudio.playSoundLeger();
                }

                if (lightComboState == LightComboState.LIGHT_2)
                {
                    playerAttack.playerHit = null;
                    playerController.isRunning = false;
                    Vector3 direction = playerAttack.LookAtTarget();
                    // Joue attaque 1 du combo de coup léger
                    //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
                    playerAttack.swordAttacks.damage = 8;
                    playerAttack.swordAttacks.attackType = "Light";
                    // ChangeAnimationState(m_Punch);
                    playerAttack.m_Animator.SetTrigger("LightAttack2");
                    StartCoroutine(playerAttack.ForwardAttack(light2AttackTime - 0.5f, direction, 0.05f));
                    Invoke("AttackComplete", timeBeforeCancelLight2);
                    player.playerAudio.playSoundLeger();
                    //m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim
                }

                if (lightComboState == LightComboState.LIGHT_3)
                {
                    playerAttack.playerHit = null;
                    playerController.isRunning = false;
                    Vector3 direction = playerAttack.LookAtTarget();
                    playerAttack.swordAttacks.damage = 8;
                    playerAttack.swordAttacks.attackType = "Light";
                    playerAttack.m_Animator.SetTrigger("LightAttack3");
                    Debug.Log(light3AttackTime);
                    StartCoroutine(playerAttack.ForwardAttack(0.2f, direction, 0.3f));
                    Invoke("AttackComplete", timeBeforeCancelLight3);
                    player.playerAudio.playSoundLeger();
                }

                if (lightComboState == LightComboState.LIGHT_4)
                {
                    playerController.isRunning = false;
                    Vector3 direction = playerAttack.LookAtTarget();
                    Debug.Log("is attacking light 4");
                    Debug.Log(lightComboAttackTime);
                    playerAttack.m_Animator.SetTrigger("LightAttackCombo");
                    Invoke("AttackComplete", timeBeforeCancelLight3);
                    playerAttack.swordAttacks.damage = 4;
                    playerAttack.swordAttacks.attackType = "Light";
                    //StartCoroutine(ComboWorkflow());

                    //Invoke("CheckPerformFullCombo", 0f);
                    player.playerAudio.playSoundLeger();
                    StartCoroutine(CheckPerformFullCombo());
                    



                }

                if (lightComboState == LightComboState.NONE)
                {

                }
                Debug.Log(lightComboState);


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

    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = playerAttack.m_Animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Light1Yuetsu":
                    lightAttackTime = clip.length / 1.5f;
                    break;
                case "Light2Yuetsu":
                    light2AttackTime = clip.length / 1.5f;
                    break;
                case "BottomLight1":
                    lightAttackTime = clip.length / 1.5f;
                    break;
                case "Light3Yuetsu":
                    light3AttackTime = clip.length;
                    break;
                case "LightComboYuetsu":
                    lightComboAttackTime = clip.length;
                    break;
            }
        }
    }
    void ResetComboState()
    {
        if (isLightAttacking)
        {
            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {
                lightComboState = LightComboState.NONE;
                isLightAttacking = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }
    public IEnumerator InfuseSword(float time)
    {
        yield return new WaitForSeconds(time);
        vfxSword.SetActive(true);
    }
    public IEnumerator CheckPerformFullCombo()
    {
        Debug.Log("test");
        if (lightComboState == LightComboState.LIGHT_4 && playerAttack.playerHit != null)
        {
            playerAttack.isAttacking = true;
            playerController.isRunning = false;
            playerAttack.playerHit.GetComponent<Player>().isInCombo = true;
            player.isInCombo = true;
            playerAttack.playerHit.GetComponent<CharacterController>().enabled = false;
            controller.enabled = false;
            Vector3 positionAtk = GameObject.Find("ReplacePointAtk").transform.position;
            Quaternion rotationAtk = GameObject.Find("ReplacePointAtk").transform.rotation;
            transform.position = positionAtk;
            transform.rotation = rotationAtk;
            Vector3 positionRcv = GameObject.Find("ReplacePointRcv").transform.position;
            Quaternion rotationRcv = GameObject.Find("ReplacePointRcv").transform.rotation;
            playerAttack.playerHit.transform.position = positionRcv;
            playerAttack.playerHit.transform.rotation = rotationRcv;
            controller.enabled = true;
            playerAttack.playerHit.GetComponent<CharacterController>().enabled = true;
            yield return new WaitForSeconds(0.3f);
            StartCoroutine(InfuseSword(0.15f));
            StartCoroutine(playerAttack.SwitchCamera(7.5f));
            Invoke("AttackComplete", 7.5f);
            StartCoroutine(playerAttack.playerHit.GetComponent<Player>().goInEnemyCombo(7.5f));
            GetComponent<TimeLineController>().PerformFullCombo(playerAttack.m_Animator, playerAttack.playerHit.GetComponent<Animator>(), playerData.cam.GetComponent<CinemachineBrain>());
        }
    }
    // A remplacer par une coroutine plus tard
    public void AttackComplete()
    {
        playerAttack.isAttacking = false;
    }
}

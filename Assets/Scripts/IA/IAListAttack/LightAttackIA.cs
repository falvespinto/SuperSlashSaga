using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttackIA : MonoBehaviour
{
    public enum LightComboState
    {
        NONE,
        LIGHT_1,
        LIGHT_2,
        LIGHT_3,
        LIGHT_4
    }

    public enum BottomLightComboState
    {
        NONE,
        BOTTOM_LIGHT_1,
        BOTTOM_LIGHT_2
    }

    public float lightAttackTime;
    public float heavyAttackTime;
    public float light2AttackTime;
    public float light3AttackTime;
    public float lightComboAttackTime;
    public float bottomLightAttackTime;
    public float bottomLight2AttackTime;
    private Player player;
    private PlayerAttackIA playerAttackIA;
    public PlayerData playerData;
    public float default_Combo_Timer = 2f;
    public float default_BottomCombo_Timer = 2f;
    public float current_Combo_Timer;
    public bool isAttacking;
    public LightComboState lightComboState;
    public BottomLightComboState bottomLightComboState;
    public bool isParing;
    public bool isInCombo;
    public GameObject vfxSword;
    private Rect posCam;
    private Rect posCamOpponent;
    private void Awake()
    {
        //   m_Rigidbody = GetComponent<Rigidbody>();
        playerData = GetComponentInParent<PlayerData>();
        player = GetComponent<Player>();
        playerAttackIA = GetComponent<PlayerAttackIA>();
    }
    void Start()
    {
        UpdateAnimClipTimes();
        default_Combo_Timer = light3AttackTime;
        default_BottomCombo_Timer = bottomLightAttackTime + bottomLight2AttackTime - 1.2f;
        isInCombo = false;
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
    public void PerformedLightAttack(string attackType)
    {
        if (!playerAttackIA.isAttacking && !playerAttackIA.isParing && attackType == "normal")
        {
            if ((int)lightComboState >= 4 || lightComboState == null)
            {

            }
            else
            {

                playerAttackIA.isInCombo = true;
                playerAttackIA.isAttacking = true;
                current_Combo_Timer = default_Combo_Timer;
                lightComboState++;
                if (lightComboState == LightComboState.LIGHT_1)
                {
                    Vector3 direction = playerAttackIA.LookAtTarget();
                    // Joue attaque 1 du combo de coup légé
                    //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux bloqués
                    playerAttackIA.swordAttacks.damage = 7;
                    playerAttackIA.swordAttacks.attackType = "Light";
                    // ChangeAnimationState(m_Punch);
                    playerAttackIA.m_Animator.SetTrigger("LightAttack");
                    StartCoroutine(playerAttackIA.ForwardAttack(lightAttackTime - 0.6f, direction, 0.05f));
                    Invoke("AttackComplete", lightAttackTime - 0.7f);
                    FindObjectOfType<AudioManager>().Play("epee");

                    //m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim


                }

                if (lightComboState == LightComboState.LIGHT_2)
                {
                    Vector3 direction = playerAttackIA.LookAtTarget();
                    // Joue attaque 1 du combo de coup légé
                    //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
                    playerAttackIA.swordAttacks.damage = 8;
                    playerAttackIA.swordAttacks.attackType = "Light";
                    // ChangeAnimationState(m_Punch);
                    playerAttackIA.m_Animator.SetTrigger("LightAttack2");
                    StartCoroutine(playerAttackIA.ForwardAttack(light2AttackTime - 0.5f, direction, 0.05f));
                    Invoke("AttackComplete", light2AttackTime - 0.3f);
                    FindObjectOfType<AudioManager>().Play("epee");
                    //m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim
                }

                if (lightComboState == LightComboState.LIGHT_3)
                {
                    Vector3 direction = playerAttackIA.LookAtTarget();
                    playerAttackIA.swordAttacks.damage = 8;
                    playerAttackIA.swordAttacks.attackType = "Light";
                    playerAttackIA.m_Animator.SetTrigger("LightAttack3");
                    Debug.Log(light3AttackTime);
                    StartCoroutine(playerAttackIA.ForwardAttack(0.2f, direction, 0.3f));
                    Invoke("AttackComplete", light3AttackTime - 0.7f);
                    playerAttackIA.playerHit = null;
                    FindObjectOfType<AudioManager>().Play("epee");
                }

                if (lightComboState == LightComboState.LIGHT_4)
                {
                    Vector3 direction = playerAttackIA.LookAtTarget();
                    Debug.Log("is attacking light 4");
                    Debug.Log(lightComboAttackTime);
                    playerAttackIA.m_Animator.SetTrigger("LightAttackCombo");
                    Invoke("AttackComplete", lightComboAttackTime);
                    playerAttackIA.swordAttacks.damage = 4;
                    playerAttackIA.swordAttacks.attackType = "Light";
                    //StartCoroutine(ComboWorkflow());
                    Invoke("CheckPerformFullCombo", 1f);
                    FindObjectOfType<AudioManager>().Play("epee");
                }

                if (lightComboState == LightComboState.NONE)
                {

                }
                Debug.Log(lightComboState);


            }

        }
        else
        {
            if (!playerAttackIA.isParing)
            {

            }
        }

        if (!playerAttackIA.isAttacking && !playerAttackIA.isParing)
        {
            if ((int)lightComboState >= 2 || lightComboState == null && attackType == "bottom")
            {

            }
            else
            {
                playerAttackIA.isInCombo = true;
                //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
                // Si on veut avoir un timer différent entre chaques combo, il faut bouger l'afféctation du current combo timer dans les if ci-dessous et affecter current combo timer avec des valeurs paramétrés au préalable
                playerAttackIA.isAttacking = true;
                current_Combo_Timer = default_Combo_Timer;
                lightComboState++;
                if (lightComboState == LightComboState.LIGHT_1)
                {
                    playerAttackIA.LookAtTarget();
                    // Joue attaque 1 du combo de coup légé
                    Debug.Log("is attacking light");
                    //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux bloqués
                    playerAttackIA.swordAttacks.damage = 7;
                    playerAttackIA.swordAttacks.attackType = "Light";
                    // ChangeAnimationState(m_Punch);
                    playerAttackIA.m_Animator.SetTrigger("BottomLightAttack");
                    Invoke("AttackComplete", lightAttackTime - 0.75f);
                    Debug.Log(lightAttackTime);
                    //m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim


                }

                if (lightComboState == LightComboState.LIGHT_2)
                {
                    playerAttackIA.LookAtTarget();
                    // Joue attaque 1 du combo de coup légé
                    Debug.Log("is attacking light 2");
                    //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
                    playerAttackIA.swordAttacks.damage = 8;
                    playerAttackIA.swordAttacks.attackType = "Light";
                    // ChangeAnimationState(m_Punch);
                    playerAttackIA.m_Animator.SetTrigger("LightAttack2");
                    Debug.Log(light2AttackTime);
                    Invoke("AttackComplete", light2AttackTime);
                    //m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim
                }

                if (lightComboState == LightComboState.NONE)
                {

                }
                Debug.Log(lightComboState);


            }

        }
    }

    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = playerAttackIA.m_Animator.runtimeAnimatorController.animationClips;
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
        if (playerAttackIA.isInCombo)
        {
            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {
                lightComboState = LightComboState.NONE;
                playerAttackIA.isInCombo = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }
    void ResetBottomComboState()
    {
        if (playerAttackIA.isInCombo)
        {
            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {
                bottomLightComboState = BottomLightComboState.NONE;
                playerAttackIA.isInCombo = false;
                current_Combo_Timer = default_BottomCombo_Timer;
            }
        }
    }
    public IEnumerator InfuseSword(float time)
    {
        yield return new WaitForSeconds(time);
        vfxSword.SetActive(true);
    }
    public void CheckPerformFullCombo()
    {
        Debug.Log("test");
        if (lightComboState == LightComboState.LIGHT_4 && playerAttackIA.playerHit != null)
        {
            playerAttackIA.isAttacking = true;
            StartCoroutine(InfuseSword(0.15f));
            StartCoroutine(playerAttackIA.FullScreenCamera(7.5f));
            Invoke("AttackComplete", 7.5f);
            StartCoroutine(playerAttackIA.playerHit.GetComponent<Player>().goInEnemyCombo(7.5f));
            GetComponent<TimeLineController>().PerformFullCombo(playerAttackIA.m_Animator, playerAttackIA.playerHit.GetComponent<Animator>(), playerData.cam.GetComponent<CinemachineBrain>());
        }
    }
    // A remplacer par une coroutine plus tard
    public void AttackComplete()
    {
        Debug.Log("testeuu");
        playerAttackIA.isAttacking = false;
    }
}

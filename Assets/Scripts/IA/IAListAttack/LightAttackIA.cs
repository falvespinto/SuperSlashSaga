using Cinemachine;
using System;
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
    public float light1AttackTimeWait;
    public float light2AttackTimeWait;
    public float light3AttackTimeWait;
    public float light4AttackTimeWait;
    public float light1AttackTime;
    public float heavyAttackTime;
    public float light2AttackTime;
    public float light3AttackTime;
    public float lightComboAttackTime;
    public float bottomLightAttackTime;
    public float bottomLight2AttackTime;
    private IA ia;
    public PlayerAttackIA playerAttackIA;
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
    public static Action<int> onComboTriggered;
    public float timeOfCombo;
    private void Awake()
    {
        //   m_Rigidbody = GetComponent<Rigidbody>();
        playerData = GetComponentInParent<PlayerData>();
        ia = GetComponent<IA>();
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
                light1AttackTimeWait = light1AttackTime - 0.7f;
                light2AttackTimeWait = light2AttackTime - 0.3f;
                light3AttackTimeWait = light3AttackTime - 0.7f;
                light4AttackTimeWait = lightComboAttackTime;
                if (lightComboState == LightComboState.LIGHT_1)
                {
                    Vector3 direction = playerAttackIA.LookAtTarget();
                    // Joue attaque 1 du combo de coup légé
                    //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux bloqués
                    playerAttackIA.swordAttacks.damage = 7;
                    playerAttackIA.swordAttacks.attackType = "Light";
                    // ChangeAnimationState(m_Punch);
                    playerAttackIA.m_Animator.SetTrigger("LightAttack");
                    light1AttackTimeWait = light1AttackTime - 0.7f;
                    Debug.Log("Duree premiere attack : " + light1AttackTimeWait);
                    StartCoroutine(playerAttackIA.ForwardAttack(light1AttackTime - 0.6f, direction, 0.05f));
                    Invoke("AttackComplete", light1AttackTime - 0.7f);


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
                    light2AttackTimeWait = light2AttackTime - 0.3f;
                    Debug.Log("Duree deuxieme attack : " + light2AttackTimeWait);
                    StartCoroutine(playerAttackIA.ForwardAttack(light2AttackTime - 0.5f, direction, 0.05f));
                    Invoke("AttackComplete", light2AttackTime - 0.3f);
                    //m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim
                }

                if (lightComboState == LightComboState.LIGHT_3)
                {
                    Vector3 direction = playerAttackIA.LookAtTarget();
                    playerAttackIA.swordAttacks.damage = 8;
                    playerAttackIA.swordAttacks.attackType = "Light";
                    playerAttackIA.m_Animator.SetTrigger("LightAttack3");
                    Debug.Log(light3AttackTime);
                    light3AttackTimeWait = light3AttackTime - 0.7f;
                    Debug.Log("Duree troisieme attack : " + light3AttackTimeWait);
                    StartCoroutine(playerAttackIA.ForwardAttack(0.2f, direction, 0.3f));
                    Invoke("AttackComplete", light3AttackTime - 0.7f);
                    playerAttackIA.playerHit = null;

                }

                if (lightComboState == LightComboState.LIGHT_4)
                {
                    Vector3 direction = playerAttackIA.LookAtTarget();
                    Debug.Log("is attacking light 4");
                    Debug.Log(lightComboAttackTime);
                    playerAttackIA.m_Animator.SetTrigger("LightAttackCombo");
                    light4AttackTimeWait = lightComboAttackTime;
                    Debug.Log("Duree quatrieme attack : " + light4AttackTimeWait);
                    Invoke("AttackComplete", lightComboAttackTime);
                    playerAttackIA.swordAttacks.damage = 4;
                    playerAttackIA.swordAttacks.attackType = "Light";
                    //StartCoroutine(ComboWorkflow());
                    StartCoroutine("CheckPerformFullCombo");
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
    }

    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = playerAttackIA.m_Animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Light1Yuetsu":
                    light1AttackTime = clip.length / 1.5f;
                    break;
                case "Light2Yuetsu":
                    light2AttackTime = clip.length / 1.5f;
                    break;
                case "BottomLight1":
                    light1AttackTime = clip.length / 1.5f;
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

    public IEnumerator InfuseSword(float time)
    {
        yield return new WaitForSeconds(time);
        vfxSword.SetActive(true);
    }
    public void CheckPerformFullCombo()
    {
        if (playerAttackIA.playerHit != null)
        {
            StartCoroutine(PerformFullCombo());
        }
    }
    public IEnumerator PerformFullCombo()
    {
        if (playerAttackIA.playerHit != null)
        {
            if (playerAttackIA.playerHit.GetComponent<Permutation>().hasPermuted == false)
            {
                onComboTriggered?.Invoke(ia.playerIndex);
                playerAttackIA.isAttacking = true;
                //playerController.isRunning = false;
                playerAttackIA.playerHit.GetComponent<Player>().isInCombo = true;
                ia.isInCombo = true;
                yield return new WaitForSeconds(0.3f);
                playerAttackIA.playerHit.GetComponent<CharacterController>().enabled = false;
                //controller.enabled = false;
                Vector3 positionAtk = GameObject.Find("ReplacePointAtk").transform.position;
                Quaternion rotationAtk = GameObject.Find("ReplacePointAtk").transform.rotation;
                transform.position = positionAtk;
                transform.rotation = rotationAtk;
                Vector3 positionRcv = GameObject.Find("ReplacePointRcv" + ia.characterName).transform.position;
                Quaternion rotationRcv = GameObject.Find("ReplacePointRcv" + ia.characterName).transform.rotation;
                playerAttackIA.playerHit.transform.position = positionRcv;
                playerAttackIA.playerHit.transform.rotation = rotationRcv;
                //controller.enabled = true;
                playerAttackIA.playerHit.GetComponent<CharacterController>().enabled = true;
                //StartCoroutine(InfuseSword(0.15f));
                StartCoroutine(playerAttackIA.ResetCombo(timeOfCombo));
                Invoke("AttackComplete", timeOfCombo);
                StartCoroutine(playerAttackIA.playerHit.GetComponent<Player>().goInEnemyCombo(timeOfCombo));
                GetComponent<TimeLineController>().PerformFullCombo(playerAttackIA.m_Animator, playerAttackIA.playerHit.GetComponent<Animator>());
            }
        }
    }

        // A remplacer par une coroutine plus tard
        public void AttackComplete()
    {
        playerAttackIA.isAttacking = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public enum LightComboState
{
    NONE,
    LIGHT_1,
    LIGHT_2,
    LIGHT_3,
    LIGHT_4
}

public enum RunLightComboState
{
    NONE,
    RUN_LIGHT_1,
    RUN_LIGHT_2
}
public enum BottomLightComboState
{
    NONE,
    BOTTOM_LIGHT_1,
    BOTTOM_LIGHT_2
}

public enum RunBottomLightComboState
{
    NONE,
    RUN_BOTTOM_LIGHT_1,
    RUN_BOTTOM_LIGHT_2
}

public class PlayerAttack : MonoBehaviour
{

    public bool isAttacking;
    public bool isRunAttacking;
    public Attack swordAttacks;
    public LightComboState lightComboState;
    public RunLightComboState runLightComboState;
    public BottomLightComboState bottomLightComboState;
    public RunBottomLightComboState runBottomLightComboState;

    private Rigidbody m_Rigidbody;

    public float default_Combo_Timer = 2f;
    public float default_Combo_Timer_Run = 2f;
    public float default_BottomCombo_Timer = 2f;
    public float current_Combo_Timer;
    public Animator m_Animator;
    public bool isInCombo;
    public PlayerController playerController;
    public bool isParing;
    private Player player;
    public Transform target;
    public PlayerData playerData;
    public float lightAttackTime;
    public float heavyAttackTime;
    public float light2AttackTime;
    public float light3AttackTime;
    public float lightComboAttackTime;
    public float bottomLightAttackTime;
    public float bottomLight2AttackTime;
    public float runLightAtkTime;
    public float runLightAtk2Time;

    public bool lightAttackButtonPressed;
    public bool heavyAttackButtonPressed;
    public bool bottomLightAttackButtonPressed;
    public bool bottomHeavyAttackButtonPressed;
    public bool paradeButtonPressed;
    public bool paradeButtonReleased;
    private Rect posCam;
    private Rect posCamOpponent;
    public GameObject playerHit;

    private bool canLight;
    private bool canHeavy;
    private bool canParade;

    private bool neverPared;

    public CharacterController controller;

    private bool heavyCanAutoCancel;

    public GameObject vfxSword;
    private void Awake()
    {
        //   m_Rigidbody = GetComponent<Rigidbody>();
        playerData = GetComponentInParent<PlayerData>();
        playerController = GetComponent<PlayerController>();
        player = GetComponent<Player>();
    }
    public void Start()
    {
        UpdateAnimClipTimes();
        default_Combo_Timer = light3AttackTime;
        default_Combo_Timer_Run = runLightAtkTime + runLightAtk2Time;
        default_BottomCombo_Timer = bottomLightAttackTime + bottomLight2AttackTime - 1.2f;
        canLight = true;
        canHeavy = true;
        canParade = true;
        isInCombo = false;
        isAttacking = false;
        isRunAttacking = false;
        lightComboState = LightComboState.NONE;
        bottomLightComboState = BottomLightComboState.NONE;
        current_Combo_Timer = default_Combo_Timer;
        lightAttackButtonPressed = false;
        heavyAttackButtonPressed = false;
        bottomLightAttackButtonPressed = false;
        bottomHeavyAttackButtonPressed = false;
        paradeButtonPressed = false;
        paradeButtonReleased = false;
        neverPared = true;
        heavyCanAutoCancel = true;
        target = playerData.target;
    }

    private void Update()
    {
        if (target == null)
        {
            target = playerData.target;
        }
        ResetComboState();

        if (!player.isTakingDamage)
        {
            if (lightAttackButtonPressed && !isAttacking && !isParing && !isRunAttacking)
            {
                lightAttackButtonPressed = false;
                if ((int)lightComboState >= 4 || lightComboState == null || (int)runLightComboState >= 2 || runLightComboState == null)
                {

                }
                else
                {

                    isInCombo = true;
                    //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
                    // Si on veut avoir un timer différent entre chaques combo, il faut bouger l'afféctation du current combo timer dans les if ci-dessous et affecter current combo timer avec des valeurs paramétrés au préalable


                    if (playerController.isRunning)
                    {
                        isRunAttacking = true;
                        current_Combo_Timer = default_Combo_Timer_Run;
                        runLightComboState++;
                        if (runLightComboState == RunLightComboState.RUN_LIGHT_1)
                        {
                            LookAtTarget();
                            // Joue attaque 1 du combo de coup légé pendant un sprint
                            //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux bloqués
                            swordAttacks.damage = 5;
                            swordAttacks.attackType = "Light";
                            m_Animator.SetBool("RunLightAttack", true);
                            Invoke("RunLightAttack1Complete", runLightAtkTime);
                            Invoke("AttackComplete", runLightAtkTime - 0.4f);
                        }

                        if (runLightComboState == RunLightComboState.RUN_LIGHT_2)
                        {
                            LookAtTarget();
                            // m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux bloqués
                            swordAttacks.damage = 7;
                            swordAttacks.attackType = "Light";
                            m_Animator.SetBool("RunLightAttack2", true);
                            Invoke("RunLightAttack2Complete", runLightAtk2Time);
                            Invoke("AttackComplete", runLightAtk2Time);
                        }

                        if (runLightComboState == RunLightComboState.NONE)
                        {

                        }
                        Debug.Log(runLightComboState);
                    }
                    else
                    {
                        isAttacking = true;
                        current_Combo_Timer = default_Combo_Timer;
                        lightComboState++;
                        if (lightComboState == LightComboState.LIGHT_1)
                        {
                            playerController.isRunning = false;
                            Vector3 direction = LookAtTarget();
                            // Joue attaque 1 du combo de coup légé
                            //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux bloqués
                            swordAttacks.damage = 7;
                            swordAttacks.attackType = "Light";
                            // ChangeAnimationState(m_Punch);
                            m_Animator.SetTrigger("LightAttack");
                            StartCoroutine(ForwardAttack(lightAttackTime-0.6f,direction, 0.05f));
                            Invoke("AttackComplete", lightAttackTime - 0.7f);
                            //m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim


                        }

                        if (lightComboState == LightComboState.LIGHT_2)
                        {
                            playerController.isRunning = false;
                            Vector3 direction = LookAtTarget();
                            // Joue attaque 1 du combo de coup légé
                            //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
                            swordAttacks.damage = 8;
                            swordAttacks.attackType = "Light";
                            // ChangeAnimationState(m_Punch);
                            m_Animator.SetTrigger("LightAttack2");
                            StartCoroutine(ForwardAttack(light2AttackTime-0.5f, direction, 0.05f));
                            Invoke("AttackComplete", light2AttackTime - 0.3f);
                            //m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim
                        }

                        if (lightComboState == LightComboState.LIGHT_3)
                        {
                            playerController.isRunning = false;
                            Vector3 direction = LookAtTarget();
                            swordAttacks.damage = 8;
                            swordAttacks.attackType = "Light";
                            m_Animator.SetTrigger("LightAttack3");
                            Debug.Log(light3AttackTime);
                            StartCoroutine(ForwardAttack(0.2f, direction, 0.3f));
                            Invoke("AttackComplete", light3AttackTime - 0.7f);
                            playerHit = null;
                        }

                        if (lightComboState == LightComboState.LIGHT_4)
                        {
                            playerController.isRunning = false;
                            Vector3 direction = LookAtTarget();
                            Debug.Log("is attacking light 4");
                            Debug.Log(lightComboAttackTime);
                            m_Animator.SetTrigger("LightAttackCombo");
                            Invoke("AttackComplete", lightComboAttackTime);
                            swordAttacks.damage = 4;
                            swordAttacks.attackType = "Light";
                            //StartCoroutine(ComboWorkflow());
                            Invoke("CheckPerformFullCombo", 1f);

                        }

                        if (lightComboState == LightComboState.NONE)
                        {

                        }
                        Debug.Log(lightComboState);
                    }

                }

            }
            else
            {
                if (!isParing && !isRunAttacking)
                {

                }
            }

            if (bottomLightAttackButtonPressed && !isAttacking && !isParing && !isRunAttacking)
            {
                bottomLightAttackButtonPressed = false;
                if ((int)lightComboState >= 2 || lightComboState == null || (int)runLightComboState >= 2 || runLightComboState == null)
                {

                }
                else
                {

                    isInCombo = true;
                    //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
                    // Si on veut avoir un timer différent entre chaques combo, il faut bouger l'afféctation du current combo timer dans les if ci-dessous et affecter current combo timer avec des valeurs paramétrés au préalable


                    if (playerController.isRunning)
                    {
                        isRunAttacking = true;
                        current_Combo_Timer = default_Combo_Timer_Run;
                        runLightComboState++;
                        if (runLightComboState == RunLightComboState.RUN_LIGHT_1)
                        {
                            LookAtTarget();
                            // Joue attaque 1 du combo de coup légé pendant un sprint
                            Debug.Log("Run light atk 1");
                            //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux bloqués
                            swordAttacks.damage = 5;
                            swordAttacks.attackType = "Light";
                            m_Animator.SetBool("RunBottomLightAttack", true);
                            Invoke("RunBottomLightAttack1Complete", runLightAtkTime);
                            Invoke("AttackComplete", runLightAtkTime - 0.4f);
                        }

                        if (runLightComboState == RunLightComboState.RUN_LIGHT_2)
                        {
                            LookAtTarget();
                            Debug.Log("Run light atk 2");
                            // m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux bloqués
                            swordAttacks.damage = 7;
                            swordAttacks.attackType = "Light";
                            m_Animator.SetBool("RunBottomLightAttack2", true);
                            Invoke("RunBottomLightAttack2Complete", runLightAtk2Time);
                            Invoke("AttackComplete", runLightAtk2Time);
                        }

                        if (runLightComboState == RunLightComboState.NONE)
                        {

                        }
                        Debug.Log(runLightComboState);
                    }
                    else
                    {
                        isAttacking = true;
                        current_Combo_Timer = default_Combo_Timer;
                        lightComboState++;
                        if (lightComboState == LightComboState.LIGHT_1)
                        {
                            LookAtTarget();
                            // Joue attaque 1 du combo de coup légé
                            Debug.Log("is attacking light");
                            //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux bloqués
                            swordAttacks.damage = 7;
                            swordAttacks.attackType = "Light";
                            // ChangeAnimationState(m_Punch);
                            m_Animator.SetTrigger("BottomLightAttack");
                            Invoke("AttackComplete", lightAttackTime - 0.75f);
                            Debug.Log(lightAttackTime);
                            //m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim


                        }

                        if (lightComboState == LightComboState.LIGHT_2)
                        {
                            LookAtTarget();
                            // Joue attaque 1 du combo de coup légé
                            Debug.Log("is attacking light 2");
                            //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
                            swordAttacks.damage = 8;
                            swordAttacks.attackType = "Light";
                            // ChangeAnimationState(m_Punch);
                            m_Animator.SetTrigger("LightAttack2");
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






            if (heavyAttackButtonPressed && !isAttacking && !isParing && !isRunAttacking)
            {
                if (heavyCanAutoCancel)
                {
                    playerController.isRunning = false;
                    Vector3 direction = LookAtTarget();
                    heavyAttackButtonPressed = false;
                    isAttacking = true;
                    // Cela retirerait le fait de pouvoir choisir frame par frame si on applique un coup mais serait peut être plus performant ?
                    Debug.Log("is attacking heavy");
                    // m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // bloque les déplacements horizontaux
                    swordAttacks.damage = 20;
                    swordAttacks.attackType = "Heavy";
                    // ChangeAnimationState(m_Punch);
                    m_Animator.SetTrigger("HeavyAttack");
                    StartCoroutine(ForwardAttack(0.2f, direction, 0.30f));
                    //StartCoroutine(AttackAutoCancel(heavyAttackTime, heavyCanAutoCancel));
                    Invoke("AttackComplete", heavyAttackTime - 0.7f);
                    
                }
            }

            if (bottomHeavyAttackButtonPressed && !isAttacking && !isParing && !isRunAttacking)
            {
                Vector3 direction = LookAtTarget();
                bottomHeavyAttackButtonPressed = false;
                isAttacking = true;
                // Cela retirerait le fait de pouvoir choisir frame par frame si on applique un coup mais serait peut être plus performant ?
                Debug.Log("is attacking bottom heavy");
                // m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // bloque les déplacements horizontaux
                swordAttacks.damage = 20;
                // à changer pê
                swordAttacks.attackType = "Heavy";
                // ChangeAnimationState(m_Punch);
                // à changer
                m_Animator.SetTrigger("BottomHeavyAttack");
                StartCoroutine(ForwardAttack(heavyAttackTime - 0.5f, direction, 0.05f));
                Invoke("AttackComplete", heavyAttackTime-0.5f);
            }

            if (paradeButtonPressed && !isAttacking && !isParing && !isRunAttacking)
            {
                LookAtTarget();
                isParing = true;
                Debug.Log("is Paring");
                //m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // bloque les déplacements horizontaux
                m_Animator.SetBool("IsParing", true);
            }

            if (!paradeButtonPressed && !isAttacking && isParing && !isRunAttacking)
            {
                isParing = false;
                Debug.Log("has stopped paring");
                m_Animator.SetBool("IsParing", false);
            }
        }
        else
        {
            isParing = false;
            m_Animator.SetBool("IsParing", false);
        }
    }

    public void AttackComplete()
    {
        Debug.Log("testeuu");
        isAttacking = false;
        isRunAttacking = false;
    }
    void RunLightAttack1Complete()
    {
        m_Animator.SetBool("RunLightAttack", false);
    }
    void RunLightAttack2Complete()
    {
        m_Animator.SetBool("RunLightAttack2", false);
    }
    void RunBottomLightAttack1Complete()
    {
        m_Animator.SetBool("RunBottomLightAttack", false);
    }
    void RunBottomLightAttack2Complete()
    {
        m_Animator.SetBool("RunBottomLightAttack2", false);
    }

    void ResetComboState()
    {
        if (isInCombo)
        {
            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {
                lightComboState = LightComboState.NONE;
                runLightComboState = RunLightComboState.NONE;
                isInCombo = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }
    void ResetBottomComboState()
    {
        if (isInCombo)
        {
            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {
                bottomLightComboState = BottomLightComboState.NONE;
                runBottomLightComboState = RunBottomLightComboState.NONE;
                isInCombo = false;
                current_Combo_Timer = default_BottomCombo_Timer;
            }
        }
    }
    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = m_Animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Light1Yuetsu":
                    lightAttackTime = clip.length / 1.5f;
                    break;
                case "HeavyYuetsu":
                    heavyAttackTime = clip.length;
                    break;
                case "Light2Yuetsu":
                    light2AttackTime = clip.length / 1.5f;
                    break;
                case "RunLightAtkYuetsu":
                    runLightAtkTime = clip.length;
                    break;
                case "RunLightAtk2Yuetsu":
                    runLightAtk2Time = clip.length;
                    break;
                case "BottomLight1":
                    lightAttackTime = clip.length / 1.5f;
                    break;
                case "BottomHeavy":
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
    public void AttackedWhileParing()
    {
        swordAttacks.damage = 30;
        swordAttacks.attackType = "Paring";
        isParing = false;
        m_Animator.SetBool("IsParing", false);
        m_Animator.SetTrigger("CounterAttack");
        paradeButtonPressed = false;


        Debug.Log("bonjour");
    }

    public void LightAttackButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("pressedLight");
            lightAttackButtonPressed = true;
        }
        else if (ctx.canceled)
        {
            Debug.Log("releasedLight");
            lightAttackButtonPressed = false;
        }

    }
    public void UltimateAttackButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!player.isTakingDamage && !isAttacking && !isParing && !isRunAttacking && !playerController.isRunning)
            {
                LookAtTarget();
                GetComponent<UltimateAttack>().PerformUltimateAttack();
            }
            
        }
    }
    public void HeavyAttackButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("pressedHeavy");
            heavyAttackButtonPressed = true;
        }
        else if (ctx.canceled)
        {
            Debug.Log("releasedHeavy");
            heavyAttackButtonPressed = false;
        }
    }
    public void BottomLightAttackButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("pressedBottomLight");
            bottomLightAttackButtonPressed = true;
        }
        else if (ctx.canceled)
        {
            Debug.Log("releasedBottomLight");
            bottomLightAttackButtonPressed = false;
        }

    }
    public void BottomHeavyAttackButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("pressedBottomHeavy");
            bottomHeavyAttackButtonPressed = true;
        }
        else if (ctx.canceled)
        {
            Debug.Log("releasedBottomHeavy");
            bottomHeavyAttackButtonPressed = false;
        }
    }
    public void ParadeButtonPressed(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("pressedParade");
            paradeButtonPressed = true;
        }
        else if (ctx.canceled)
        {
            Debug.Log("releasedParade");
            paradeButtonPressed = false;
        }
    }

    public Vector3 LookAtTarget()
    {
        Vector3 dir = target.position - transform.position;
        dir.Normalize();
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
        return dir;
    }

    IEnumerator ForwardAttack(float attackTime, Vector3 direction, float attackSpeed)
    {
        float startTime = Time.time;
        while (Time.time < startTime + attackTime)
        {
            controller.Move(direction * attackSpeed);
            yield return null;
        }
    }

    //IEnumerator AttackAutoCancel(float time, bool canAuto)
    //{
    //    canAuto = false;
    //    yield return new WaitForSeconds(time);
    //    canAuto = true;
    //}


    public void CheckPerformFullCombo()
    {
        Debug.Log("test");
        if (lightComboState == LightComboState.LIGHT_4 && playerHit != null)
        {
            isAttacking = true;
            playerController.isRunning = false;
            StartCoroutine(InfuseSword(0.15f));
            StartCoroutine(FullScreenCamera(7.5f));
            Invoke("AttackComplete", 3.45f);
            GetComponent<TimeLineController>().PerformFullCombo(m_Animator, playerHit.GetComponent<Animator>(), playerData.cam.GetComponent<CinemachineBrain>());
        }
    }

    public IEnumerator FullScreenCamera(float time)
    {
        posCam = playerData.cam.rect;
        posCamOpponent = playerData.target.GetComponentInParent<PlayerData>().cam.rect;
        playerData.cam.rect = new Rect(0f, 0f, 1f, 1f);
        playerData.target.GetComponentInParent<PlayerData>().cam.rect = new Rect(0f, 0f, 0f, 0f);
        yield return new WaitForSeconds(time);
        playerData.cam.rect = posCam;
        playerData.target.GetComponentInParent<PlayerData>().cam.rect = posCamOpponent;
    }

    public IEnumerator InfuseSword(float time)
    {
        yield return new WaitForSeconds(time);
        vfxSword.SetActive(true);
    }

}

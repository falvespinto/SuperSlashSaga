using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum LightComboState
{
    NONE,
    LIGHT_1,
    LIGHT_2
}

public enum RunLightComboState
{
    NONE,
    RUN_LIGHT_1,
    RUN_LIGHT_2
}

public class PlayerAttack : MonoBehaviour
{

    public bool isAttacking;
    public bool isRunAttacking;
    public Attack swordAttacks;
    public LightComboState lightComboState;
    public RunLightComboState runLightComboState;

    private Rigidbody m_Rigidbody;

    public float default_Combo_Timer = 2f;
    public float default_Combo_Timer_Run = 2f;
    public float current_Combo_Timer;
    public Animator m_Animator;
    public bool isInCombo;
    public PlayerController playerController;
    public bool isParing;

    public float lightAttackTime;
    public float heavyAttackTime;
    public float light2AttackTime;
    public float runLightAtkTime;
    public float runLightAtk2Time;

    public bool lightAttackButtonPressed;
    public bool heavyAttackButtonPressed;
    public bool paradeButtonPressed;
    public bool paradeButtonReleased;

    private bool canLight;
    private bool canHeavy;
    private bool canParade;

    private bool neverPared;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }
    public void Start()
    {
        UpdateAnimClipTimes();
        default_Combo_Timer = lightAttackTime + light2AttackTime-1.2f;
        default_Combo_Timer_Run = runLightAtkTime + runLightAtk2Time;
        canLight = true;
        canHeavy = true;
        canParade = true;
        isInCombo = false;
        isAttacking = false;
        isRunAttacking = false;
        lightComboState = LightComboState.NONE;
        current_Combo_Timer = default_Combo_Timer;
        lightAttackButtonPressed = false;
        heavyAttackButtonPressed = false;
        paradeButtonPressed = false;
        paradeButtonReleased = false;
        neverPared = true;
        
    }

    private void Update()
    {

        ResetComboState();

        if (lightAttackButtonPressed && !isAttacking && !isParing && !isRunAttacking)
        {
            lightAttackButtonPressed = false;
            if ((int)lightComboState >= 2 || lightComboState == null || (int)runLightComboState >= 2 || runLightComboState == null)
            {

            }
            else {
            
            isInCombo = true;
            m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
            // Si on veut avoir un timer différent entre chaques combo, il faut bouger l'afféctation du current combo timer dans les if ci-dessous et affecter current combo timer avec des valeurs paramétrés au préalable
            

            if (playerController.isRunning)
            {
                    isRunAttacking = true;
                    current_Combo_Timer = default_Combo_Timer_Run;
                    runLightComboState++;
                    if (runLightComboState == RunLightComboState.RUN_LIGHT_1)
                    {
                        // Joue attaque 1 du combo de coup légé pendant un sprint
                        Debug.Log("Run light atk 1");
                        m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux bloqués
                        swordAttacks.damage = 5;
                        m_Animator.SetBool("RunLightAttack",true);
                        Invoke("RunLightAttack1Complete", runLightAtkTime);
                        Invoke("AttackComplete", runLightAtkTime-0.4f);
                    }

                    if (runLightComboState == RunLightComboState.RUN_LIGHT_2)
                    {
                        Debug.Log("Run light atk 2");
                        m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux bloqués
                        
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
                        // Joue attaque 1 du combo de coup légé
                        Debug.Log("is attacking light");
                        m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux bloqués
                        swordAttacks.damage = 7;
                        // ChangeAnimationState(m_Punch);
                        m_Animator.SetTrigger("LightAttack");
                        Invoke("AttackComplete", lightAttackTime - 0.75f);
                        Debug.Log(lightAttackTime);
                        //m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim


                    }

                    if (lightComboState == LightComboState.LIGHT_2)
                    {
                        // Joue attaque 1 du combo de coup légé
                        Debug.Log("is attacking light 2");
                        m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
                        swordAttacks.damage = 10;
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
            heavyAttackButtonPressed = false;
            isAttacking = true;
            // Cela retirerait le fait de pouvoir choisir frame par frame si on applique un coup mais serait peut être plus performant ?
            Debug.Log("is attacking heavy");
            m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // bloque les déplacements horizontaux
            swordAttacks.damage = 20;
            // ChangeAnimationState(m_Punch);
            m_Animator.SetTrigger("HeavyAttack");
            Invoke("AttackComplete", heavyAttackTime);
        }

        if (paradeButtonPressed && !isAttacking && !isParing && !isRunAttacking)
        {

            isParing = true;
            Debug.Log("is Paring");
            m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // bloque les déplacements horizontaux
            m_Animator.SetBool("IsParing", true);
        }

        if (!paradeButtonPressed && !isAttacking && isParing && !isRunAttacking)
        {
            isParing = false;
            Debug.Log("has stopped paring");
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
    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = m_Animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Light1Yuetsu":
                    lightAttackTime = clip.length;
                    break;
                case "HeavyYuetsu":
                    heavyAttackTime = clip.length;
                    break;
                case "Light2Yuetsu":
                    light2AttackTime = clip.length;
                    break;
                case "RunLightAtkYuetsu":
                    runLightAtkTime = clip.length;
                    break;
                case "RunLightAtk2Yuetsu":
                    runLightAtk2Time = clip.length;
                    break;
            }
        }
    }
    public void AttackedWhileParing()
    {
        swordAttacks.damage = 30;
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

}

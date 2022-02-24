using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System;
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
    public List<Attack> attacksPoints;
    public LightComboState lightComboState;
    public RunLightComboState runLightComboState;
    public BottomLightComboState bottomLightComboState;
    public RunBottomLightComboState runBottomLightComboState;

    public Collider stopArea;

    private Rigidbody m_Rigidbody;

    public float default_Combo_Timer = 2f;
    public float default_Combo_Timer_Run = 2f;
    public float default_BottomCombo_Timer = 2f;
    public float current_Combo_Timer;
    public Animator m_Animator;
    public bool isInCombo;
    public PlayerController playerController;
    public bool isParing;
    public Player player;
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
    public LightAttack lightAttack;
    public HeavyAttack heavyAttack;
    public Parade parade;
    public bool lightAttackButtonPressed;
    public bool heavyAttackButtonPressed;
    public bool bottomLightAttackButtonPressed;
    public bool bottomHeavyAttackButtonPressed;
    public bool paradeButtonPressed;
    private Rect posCam;
    private Rect posCamOpponent;
    public GameObject playerHit;

    private bool canLight;
    private bool canHeavy;
    private bool canParade;
    public ComboCamera comboCam;
    private bool neverPared;
    public UltimateAttack ultimateAttack;
    public CharacterController controller;

    // Compteurs pour log
    public static Action<int> OnLightAtk;
    public static Action<int> OnHeavyAtk;
    public static Action<int> OnUltimateAtk;
    public static Action<int> OnParadeUsed;
    public static Action<int> OnParadeTriggered;
    private bool heavyCanAutoCancel;

    public bool test = false;
    private void Awake()
    {
        //   m_Rigidbody = GetComponent<Rigidbody>();
        playerData = GetComponentInParent<PlayerData>();
        playerController = GetComponent<PlayerController>();
        ultimateAttack = GetComponent<UltimateAttack>();
    }
    public void Start()
    {
        //comboCam.gameObject.SetActive(false);
        default_Combo_Timer = light3AttackTime;
        default_Combo_Timer_Run = runLightAtkTime + runLightAtk2Time;
        default_BottomCombo_Timer = bottomLightAttackTime + bottomLight2AttackTime - 1.2f;
        canLight = true;
        canHeavy = true;
        canParade = true;
        isInCombo = false;
        isAttacking = false;
        lightComboState = LightComboState.NONE;
        bottomLightComboState = BottomLightComboState.NONE;
        current_Combo_Timer = default_Combo_Timer;
        lightAttackButtonPressed = false;
        heavyAttackButtonPressed = false;
        bottomLightAttackButtonPressed = false;
        bottomHeavyAttackButtonPressed = false;
        paradeButtonPressed = false;
        neverPared = true;
        heavyCanAutoCancel = true;
        target = playerData.target;
    }

    private void Update()
    {
        if (target == null) target = playerData.target;
    }

    public void AttackComplete() => isAttacking = false;

    public void AttackedWhileParing()
    {
        OnParadeTriggered?.Invoke(player.playerIndex);
        SetAttacksData(30,"Paring");
        isParing = false;
        parade.shield.SetActive(false);
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
            if (!player.isInCombo && !player.isTakingDamage && !isAttacking && !isParing && !ultimateAttack.isPerformingUltimate && !GameManager.instance.IsLocked)
            {
                OnLightAtk?.Invoke(player.playerIndex);
                lightAttack.PerformedLightAttack("normal");
            }
        }
    }

    public void HeavyAttackButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("pressedHeavy");
            if (!isAttacking && !player.manaUp && !isParing && !player.isInCombo && !player.isTakingDamage && !ultimateAttack.isPerformingUltimate && !GameManager.instance.IsLocked)
            {
                OnHeavyAtk?.Invoke(player.playerIndex);
                heavyAttack.PerformedHeavyAttack("normal");
            }
            
            
        }
    }

    public void ParadeButtonPressed(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!player.isTakingDamage && !isAttacking && !player.manaUp && !isParing && !ultimateAttack.isPerformingUltimate && !player.isInCombo && !GameManager.instance.IsLocked)
            {
                Debug.Log("pressedParade");
                OnParadeUsed?.Invoke(player.playerIndex);
                paradeButtonPressed = true;
                parade.InitializedParadeAttack();
            }
        }
        else if (ctx.canceled)
        {
            Debug.Log("releasedParade");
            paradeButtonPressed = false;
            parade.FinalizedParadeAttack();
        }
    }
    public void UltimateAttackButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!player.isTakingDamage && !isAttacking && !player.manaUp && !isParing && !ultimateAttack.isPerformingUltimate && !player.isInCombo && !GameManager.instance.IsLocked)
            {
                LookAtTarget();
                OnUltimateAtk?.Invoke(player.playerIndex);
                ultimateAttack.PerformUltimateAttack();
            }
        }
    }
    //IEnumerator AttackAutoCancel(float time, bool canAuto)
    //{
    //    canAuto = false;
    //    yield return new WaitForSeconds(time);
    //    canAuto = true;
    //}

    public Vector3 LookAtTarget()
    {
        Vector3 dir = target.position - transform.position;
        dir.Normalize();
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
        return dir;
    }


    public IEnumerator ResetCombo(float time)
    {
        yield return new WaitForSeconds(time);
        if (StartGame.managerIA.bIsIA)
        {
            player.isInCombo = false;
            playerHit.GetComponent<IA>().isInCombo = false;
        }
        else
        {
            player.isInCombo = false;
            playerHit.GetComponent<Player>().isInCombo = false;
        }

    }
    public IEnumerator ForwardAttack(float attackTime, Vector3 direction, float attackSpeed)
    {
        if (!ultimateAttack.isPerformingUltimate)
        {
            float startTime = Time.time;
            while (Time.time < startTime + attackTime)
            {
                controller.Move(direction * attackSpeed);
                yield return null;
            }
        }

    }

    public bool isHeNearEnemy()
    {
        bool tempBool = false;
        Collider[] hit = Physics.OverlapBox(stopArea.bounds.center, stopArea.bounds.extents, stopArea.transform.rotation, gameObject.GetComponentInParent<PlayerData>().enemyLayer);
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                tempBool = true;
                break;
            }
        }
        return tempBool;
    }

    public void SetAttacksData(int damage, string attackType)
    {
        foreach (var attackPoint in attacksPoints)
        {
            attackPoint.damage = damage;
            attackPoint.attackType = attackType;
        }
    }
}

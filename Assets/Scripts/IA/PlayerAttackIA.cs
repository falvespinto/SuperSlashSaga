using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public enum LightComboStateIA
{
    NONE,
    LIGHT_1,
    LIGHT_2,
    LIGHT_3,
    LIGHT_4
}

public enum RunLightComboStateIA
{
    NONE,
    RUN_LIGHT_1,
    RUN_LIGHT_2
}
public enum BottomLightComboStateIA
{
    NONE,
    BOTTOM_LIGHT_1,
    BOTTOM_LIGHT_2
}

public enum RunBottomLightComboStateIA
{
    NONE,
    RUN_BOTTOM_LIGHT_1,
    RUN_BOTTOM_LIGHT_2
}

public class PlayerAttackIA : MonoBehaviour
{

    public bool isAttacking;
    public bool isRunAttacking;
    public Attack swordAttacks;
    public LightComboStateIA lightComboStateIA;
    public RunLightComboStateIA runLightComboStateIA;
    public BottomLightComboStateIA bottomLightComboStateIA;
    public RunBottomLightComboStateIA runBottomLightComboStateIA;

    private Rigidbody m_Rigidbody;

    public float default_Combo_Timer = 2f;
    public float default_Combo_Timer_Run = 2f;
    public float default_BottomCombo_Timer = 2f;
    public float current_Combo_Timer;
    public Animator m_Animator;
    public bool isInCombo;
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
    public LightAttackIA lightAttackIA;
    public HeavyAttackIA heavyAttackIA;
    public ParadeIA paradeIA;
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

    private bool neverPared;
    private UltimateAttack ultimateAttack;
    private ComboCamera comboCam;
    private bool heavyCanAutoCancel;
    private void Awake()
    {
        //   m_Rigidbody = GetComponent<Rigidbody>();
        playerData = GetComponentInParent<PlayerData>();
        player = GetComponent<Player>();
        ultimateAttack = GetComponent<UltimateAttack>();
        comboCam = GetComponentInChildren<ComboCamera>();
    }
    public void Start()
    {
        comboCam.gameObject.SetActive(false);
        default_Combo_Timer = light3AttackTime;
        default_Combo_Timer_Run = runLightAtkTime + runLightAtk2Time;
        default_BottomCombo_Timer = bottomLightAttackTime + bottomLight2AttackTime - 1.2f;
        canLight = true;
        canHeavy = true;
        canParade = true;
        isInCombo = false;
        isAttacking = false;
        isRunAttacking = false;
        lightComboStateIA = LightComboStateIA.NONE;
        bottomLightComboStateIA = BottomLightComboStateIA.NONE;
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
        if (target == null)
        {
            target = playerData.target;
        }
        //else
        //{
        //    isParing = false;
        //    m_Animator.SetBool("IsParing", false);
        //}
    }

    public void AttackComplete()
    {
        Debug.Log("testeuu");
        isAttacking = false;
        isRunAttacking = false;
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
            lightAttackIA.PerformedLightAttack("normal");
        }
    }
    public void BottomLightAttackButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("pressedBottomLight");
            lightAttackIA.PerformedLightAttack("bottom");
        }
    }

    public void HeavyAttackButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("pressedHeavy");
            heavyAttackIA.PerformedHeavyAttack("normal");

        }
    }

    public void BottomHeavyAttackButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("pressedBottomHeavy");
            heavyAttackIA.PerformedHeavyAttack("bottom");
        }
    }
    public void ParadeButtonPressed(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("pressedParade");
            paradeButtonPressed = true;
            paradeIA.InitializedParadeAttack();
        }
        else if (ctx.canceled)
        {
            Debug.Log("releasedParade");
            paradeButtonPressed = false;
            paradeIA.FinalizedParadeAttack();
        }
    }
    public void UltimateAttackButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!player.isTakingDamage && !isAttacking && !isParing && !isRunAttacking && /*!playerController.isRunning &&*/ !ultimateAttack.isPerformingUltimate)
            {
                FindObjectOfType<AudioManager>().Play("ultimate");
                LookAtTarget();
                GetComponent<UltimateAttack>().PerformUltimateAttack();
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
    public IEnumerator SwitchCamera(float time)
    {
        //playerData.cam.enabled = false;
        comboCam.gameObject.SetActive(true); //comboCam.enabled = true;
        lightAttackIA.isInCombo = true;
        yield return new WaitForSeconds(time);
        comboCam.gameObject.SetActive(false); //comboCam.enabled = false;
        //playerData.cam.enabled = true;
        lightAttackIA.isInCombo = false;

    }

    public IEnumerator FullScreenCamera(float time)
    {
       // posCam = playerData.cam.rect;
       // posCamOpponent = playerData.target.GetComponentInParent<PlayerData>().cam.rect;
       // playerData.cam.rect = new Rect(0f, 0f, 1f, 1f);
      //  playerData.target.GetComponentInParent<PlayerData>().cam.rect = new Rect(0f, 0f, 0f, 0f);
        yield return new WaitForSeconds(time);
      //  playerData.cam.rect = posCam;
       // playerData.target.GetComponentInParent<PlayerData>().cam.rect = posCamOpponent;
    }
    public IEnumerator ForwardAttack(float attackTime, Vector3 direction, float attackSpeed)
    {
        float startTime = Time.time;
        while (Time.time < startTime + attackTime)
        {
            /*controller.Move(direction * attackSpeed);*/
            yield return null;
        }
    }


}

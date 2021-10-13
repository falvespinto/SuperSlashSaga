using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class UltimateAttack : MonoBehaviour
{

    public const string ATTACK_TYPE = "Engage";
    public const float attackDamage = 25;

    public float cooldown;
    public Vector3 positionParticles;
    public float ultimateDuration;
    public PlayableDirector timeline;
    public bool isPerformingUltimate = false;
    public bool isOnCooldown = false;
    public float effectTime;
    private bool isDealingDamages = false;
    public float beforeEffectTime;
    public GameObject playerHit;
    private bool startFullWhenReady;
    private PlayerAttack playerAttack;
    public float hurtTime;
    private testUltiVFX playerFX;
    public PlayerData player;
    private PlayerData playerData;
    public ManaBar manaBar;
    public bool performFullUltimate = false;
    public bool isEngaging = false;
    public bool hasTouched = false;
    public Collider engageArea;

    public float attackTimeEngage = 0.5f;
    public float attackSpeedEngage = 0.5f;
    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerFX = GetComponent<testUltiVFX>();
        playerData = GetComponentInParent<PlayerData>();
        manaBar = playerData.manabar;
    }
    private void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(0,7,0), transform.forward * 10, Color.red);
        if (performFullUltimate)
        {
            performFullUltimate = false;
            
            //Faire l'ult
        }
        if (isDealingDamages)
        {
            //areaOfEffect.gameObject.SetActive(true);
            //Collider[] hit = Physics.OverlapBox(areaOfEffect.bounds.center, areaOfEffect.bounds.extents, areaOfEffect.transform.rotation, gameObject.GetComponentInParent<PlayerData>().enemyLayer);
            //if (hit.Length > 0)
            //{
            //    for (int i = 0; i < hit.Length; i++)
            //    {
            //        hit[i].GetComponentInParent<Player>().hurtTimeUltimate = hurtTime;
            //        hit[i].GetComponentInParent<Player>().TakeDamage(attackDamage, attackType);
            //        Debug.Log(hit[i].GetComponentInParent<Player>().playerIndex);
            //        Debug.Log(hit[i].gameObject.layer);
            //        playerHit = hit[i].gameObject;
            //        isDealingDamages = false;
            //        startFullWhenReady = true;
            //        areaOfEffect.gameObject.SetActive(false);
            //        break;
            //    }
            //}
        }
        
        if (isEngaging)
        {
            engageArea.gameObject.SetActive(true);
            Collider[] hit = Physics.OverlapBox(engageArea.bounds.center, engageArea.bounds.extents, engageArea.transform.rotation, gameObject.GetComponentInParent<PlayerData>().enemyLayer);
            if (hit.Length > 0)
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    hit[i].GetComponentInParent<Player>().hurtTimeUltimate = hurtTime;
                    Debug.Log(hit[i].GetComponentInParent<Player>().playerIndex);
                    Debug.Log(hit[i].gameObject.layer);
                    playerHit = hit[i].gameObject;
                    hasTouched = true;
                    isEngaging = false;
                    Debug.Log("Ultimate ENGAGE : touché");
                    engageArea.gameObject.SetActive(false);
                    break;
                }
            }
        }

        if (startFullWhenReady && !isPerformingUltimate)
        {
            //startFullWhenReady = false;
            //PerformFullUltimate();
        }

    }
    public void PerformUltimateAttack()
    {
        if (!isPerformingUltimate && !isOnCooldown && manaBar.mana >= 50)
        {
            manaBar.SetMana(manaBar.mana - 50);
            Vector3 direction = playerAttack.LookAtTarget();
            StartCoroutine(ForwardEngageAttack(attackTimeEngage, direction, attackSpeedEngage));
            playerAttack.m_Animator.applyRootMotion = false;
            playerAttack.swordAttacks.damage = 0;
            playerAttack.swordAttacks.attackType = ATTACK_TYPE;
            playerAttack.m_Animator.SetTrigger("EngageUltYuetsu");
            playerAttack.m_Animator.applyRootMotion = true;
            StartCoroutine(isPerformingUltimateAttackReset());
            //timeline.Play();
            //StartCoroutine(DealDamage());
        }
    }

    IEnumerator isPerformingUltimateAttackReset()
    {
        isEngaging = true;
        isPerformingUltimate = true;
        yield return new WaitForSeconds(ultimateDuration);
        isPerformingUltimate = false;
        isEngaging = false;
    }
    IEnumerator Cooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }

    IEnumerator DealDamage()
    {
        yield return new WaitForSeconds(beforeEffectTime);
        isDealingDamages = true;
        yield return new WaitForSeconds(effectTime);
        isDealingDamages = false;
        engageArea.gameObject.SetActive(false);
    }

    public void PerformFullUltimate()
    {
        timeline.Stop();
        //gameObject.transform.position = GameObject.Find("UltPointYuetsuAtk").transform.position;
        //gameObject.transform.position = GameObject.Find("UltPointYuetsuDef").transform.position;
        GetComponentInParent<PlayerData>().gameObject.transform.position = GameObject.Find("UltPointYuetsuAtk").transform.position;
        playerHit.GetComponentInParent<PlayerData>().gameObject.transform.position = GameObject.Find("UltPointYuetsuDef").transform.position;
        GetComponent<TimeLineController>().PerformFinalUlt(playerHit.GetComponent<Animator>());
    }
    public IEnumerator waitBeforeFinalUlt()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
    }

    public IEnumerator waitMaterialSwap()
    {
        yield return new WaitForSeconds(6.05f);
        playerFX.startFlash();
        yield return new WaitForSeconds(0.816666666666666f);
        playerFX.stopFlash();


    }

    public IEnumerator ForwardEngageAttack(float attackTime, Vector3 direction, float attackSpeed)
    {
        if (!isPerformingUltimate)
        {
            float startTime = Time.time;
            while (Time.time < startTime + attackTime)
            {
                if (hasTouched)
                {
                    hasTouched = false;
                    break;
                }
                playerAttack.controller.Move(direction * attackSpeed);
                yield return null;
            }
        }
    }

    public IEnumerator ProcFullUlt()
    {
        playerData.blurPanel.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 1f;
        playerData.blurPanel.SetActive(false);
    }

    public void HandleFullUlt() {
        StartCoroutine(ProcFullUlt());
    }

}

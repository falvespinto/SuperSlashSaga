using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class UltimateAttack : MonoBehaviour
{

    public float cooldown;
    public Vector3 positionParticles;
    public float attackDamage;
    public float ultimateDuration;
    public PlayableDirector timeline;
    public bool isPerformingUltimate = false;
    public bool isOnCooldown = false;
    public float effectTime;
    private bool isDealingDamages = false;
    public Collider areaOfEffect;
    public string attackType;
    public float beforeEffectTime;
    public GameObject playerHit;
    private bool startFullWhenReady;
    private PlayerAttack playerAttack;
    private testUltiVFX playerFX;

    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerFX = GetComponent<testUltiVFX>();
    }
    private void Update()
    {
        if (isDealingDamages)
        {
            areaOfEffect.gameObject.SetActive(true);
            Collider[] hit = Physics.OverlapBox(areaOfEffect.bounds.center, areaOfEffect.bounds.extents, areaOfEffect.transform.rotation, gameObject.GetComponentInParent<PlayerData>().enemyLayer);
            if (hit.Length > 0)
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    hit[i].GetComponentInParent<Player>().TakeDamage(attackDamage, attackType);
                    Debug.Log(hit[i].GetComponentInParent<Player>().playerIndex);
                    Debug.Log(hit[i].gameObject.layer);
                    playerHit = hit[i].gameObject;
                    isDealingDamages = false;
                    startFullWhenReady = true;
                    areaOfEffect.gameObject.SetActive(false);
                    break;
                }
            }
        }

        if (startFullWhenReady && !isPerformingUltimate)
        {
            startFullWhenReady = false;
            PerformFullUltimate();
        }

    }
    public void PerformUltimateAttack()
    {
        if (!isPerformingUltimate && !isOnCooldown)
        {
            StartCoroutine(isPerformingUltimateAttackReset());
            timeline.Play();
            StartCoroutine(DealDamage());

        }
    }

    IEnumerator isPerformingUltimateAttackReset()
    {
        isPerformingUltimate = true;
        yield return new WaitForSeconds(ultimateDuration);
        isPerformingUltimate = false;
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
        areaOfEffect.gameObject.SetActive(false);
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


}

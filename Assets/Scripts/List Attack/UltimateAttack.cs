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

    public void PerformUltimateAttack()
    {
        if (!isPerformingUltimate && !isOnCooldown)
        {
            StartCoroutine(isPerformingUltimateAttackReset());
            timeline.Play();
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


}

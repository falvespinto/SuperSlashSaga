using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject m_RightHandAttackPoint;
    public GameObject m_LeftHandAttackPoint;
    public GameObject m_RightLegAttackPoint;
    public GameObject m_RightHandFlameAttackPoint;
    public GameObject m_LeftHandFlameAttackPoint;
    public GameObject m_vfx;
    public GameObject m_vfxFinal;
    public Transform spawnPointFinalVfx;
    public float vfxScale = 3f;
    public float vfxSpeed = 10f;
    public float vfxLifeTime = 0.5f;
    public bool debugIsMoving = true;
    public float finalVfxScale = 10f;
    public float finalVfxSpeed = 20f;
    public float finalVfxLifeTime = 2f;
    void RightHandFlameAttackOn()
    {
        m_RightHandFlameAttackPoint.SetActive(true);
        GameObject flame = Instantiate(m_vfx, m_RightHandFlameAttackPoint.transform.position,m_RightHandFlameAttackPoint.transform.rotation);
        flame.transform.localScale = flame.transform.localScale * vfxScale;
        if (debugIsMoving)
        {
            StartCoroutine(VfxMovement(flame, vfxSpeed, vfxLifeTime));
        }
    }
    void RightHandFlameAttackOff()
    {
        if (m_RightHandFlameAttackPoint.activeInHierarchy)
        {
            m_RightHandFlameAttackPoint.SetActive(false);
        }
    }
    void LeftHandFlameAttackOn()
    {
        m_RightHandFlameAttackPoint.SetActive(true);
        GameObject flame = Instantiate(m_vfx, m_LeftHandFlameAttackPoint.transform.position, m_LeftHandFlameAttackPoint.transform.rotation);
        flame.transform.localScale = flame.transform.localScale * vfxScale;
        if (debugIsMoving)
        {
            StartCoroutine(VfxMovement(flame, vfxSpeed, vfxLifeTime));
        }
    }
    void LeftHandFlameAttackOff()
    {
        if (m_RightHandFlameAttackPoint.activeInHierarchy)
        {
            m_RightHandFlameAttackPoint.SetActive(false);
        }
    }
    void RightHandAttackOn()
    {
        Debug.Log("attack on");
        m_RightHandAttackPoint.SetActive(true);
    }
    void RightHandAttackOff()
    {
        if (m_RightHandAttackPoint.activeInHierarchy)
        {
            m_RightHandAttackPoint.SetActive(false);
        }
    }
    void LeftHandAttackOn()
    {
        Debug.Log("attack on");
        m_LeftHandAttackPoint.SetActive(true);
    }
    void LeftHandAttackOff()
    {
        if (m_LeftHandAttackPoint.activeInHierarchy)
        {
            m_LeftHandAttackPoint.SetActive(false);
        }
    }
    void RightLegAttackOn()
    {
        Debug.Log("attack on");
        m_RightLegAttackPoint.SetActive(true);
    }
    void RightLegAttackOff()
    {
        if (m_RightLegAttackPoint.activeInHierarchy)
        {
            m_RightLegAttackPoint.SetActive(false);
        }
    }
    void RightHandFlameFinalAttackOn()
    {
        m_RightHandFlameAttackPoint.SetActive(true);
        GameObject flame = Instantiate(m_vfxFinal, spawnPointFinalVfx);//Instantiate(m_vfxFinal, spawnPointFinalVfx.position, spawnPointFinalVfx.rotation * Quaternion.Euler(0,180,0));
        flame.transform.localScale = flame.transform.localScale * finalVfxScale;
        StartCoroutine(VfxMovementFinal(flame, finalVfxSpeed, finalVfxLifeTime));
    }
    void RightHandFlameFinalAttackOff()
    {
        if (m_RightHandFlameAttackPoint.activeInHierarchy)
        {
            m_RightHandFlameAttackPoint.SetActive(false);
        }
    }

    void RightHandFinalElectricOn()
    {
        Debug.Log("attack on");
        m_vfxFinal.SetActive(true);
        m_RightHandAttackPoint.SetActive(true);
    }

    void RightHandFinalElectricOff()
    {
        if (m_RightHandAttackPoint.activeInHierarchy)
        {
            m_RightHandAttackPoint.SetActive(false);
        }
    }

    IEnumerator VfxMovement(GameObject vfx, float speed, float lifeTIme)
    {
        float timer = 0;
        while (timer < lifeTIme)
        {
            vfx.transform.Translate(vfx.transform.up * Time.deltaTime * speed, Space.World);
            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(vfx);
    }

    IEnumerator VfxMovementFinal(GameObject vfx, float speed, float lifeTIme)
    {
        float timer = 0;
        while (timer < lifeTIme)
        {
            vfx.transform.Translate(-vfx.transform.forward * Time.deltaTime * speed, Space.World);
            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(vfx);
    }
}

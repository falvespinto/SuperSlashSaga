using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{

    public GameObject m_RightHandAttackPoint;
    public GameObject m_LeftHandAttackPoint;
    public GameObject m_RightLegAttackPoint;

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

}

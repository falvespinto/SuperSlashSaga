using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{

    public GameObject m_RightHandAttackPoint;

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

}

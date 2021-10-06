using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image manaBar;
    public float maxMana;
    public float mana;

    public void SetMana(float mana)
    {
        mana = Mathf.Clamp(mana, 0, maxMana);
        this.mana = mana;
        float mFraction =  mana / maxMana;
        manaBar.fillAmount = mFraction;
    }

}

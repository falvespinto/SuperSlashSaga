using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboIndicatorManager : MonoBehaviour
{

    public ComboIndicator J1;
    public ComboIndicator J2;

    private void OnEnable()
    {
        Attack.onComboIncrease += IncreaseCombo;
        LightAttack.onComboReset += ResetCombo;
        LightAttackIA.onComboReset += ResetCombo;
    }

    private void OnDisable()
    {
        Attack.onComboIncrease -= IncreaseCombo;
        LightAttack.onComboReset -= ResetCombo;
        LightAttackIA.onComboReset -= ResetCombo;
    }

    public void IncreaseCombo(int playerIndex)
    {
        if (playerIndex == 0)
        {
            J1.IncreaseCombo();
        }
        else
        {
            J2.IncreaseCombo();
        }
    }

    public void ResetCombo(int playerIndex)
    {
        if (playerIndex == 0)
        {
            J1.ResetCombo();
        }
        else
        {
            J2.ResetCombo();
        }
    }

}

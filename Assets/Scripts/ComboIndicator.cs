using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ComboIndicator : MonoBehaviour
{

    public TextMeshProUGUI textUnder;
    public TextMeshProUGUI textOver;

    public GameObject comboIndicator;
    private int comboState = 0;

    public void IncreaseCombo()
    {
        //animation
        comboState++;
        if (comboState == 1)
        {
            comboIndicator.SetActive(true);
        }
        textUnder.text = "X" + comboState;
        textOver.text = "X" + comboState;
        LeanTween.rotateAround(comboIndicator, transform.forward , -360f, 0.2f).setEaseInSine();
        Vector3 newScale = comboIndicator.transform.localScale * 1.2f;
        LeanTween.scale(comboIndicator, newScale, 0.3f).setEaseInBounce();
    }

    public void ResetCombo()
    {
        comboState = 0;
        comboIndicator.SetActive(false);
        comboIndicator.transform.localScale = new Vector3(1, 1, 1);
        textUnder.text = "X" + comboState;
        textOver.text = "X" + comboState;
    }

}

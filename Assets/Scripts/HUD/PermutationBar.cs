using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PermutationBar : MonoBehaviour
{
    public Image permutationBar;
    public float maxPermutationStacks;
    public float remainingPermutation;

    public void SetPermutation(float permutation)
    {
        permutation = Mathf.Clamp(permutation, 0, maxPermutationStacks);
        remainingPermutation = permutation;
        float pFraction = remainingPermutation / maxPermutationStacks;
        permutationBar.fillAmount = pFraction;
    }





}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermutationIA : MonoBehaviour
{
    public float timeAfterPermute;
    public bool canPermute;
    public IA ia;
    public PlayerData playerData;
    public float permutationOffSet;
    public GameObject VFXPrefab;
    public Vector3 offSet;
    public float backwardOffSet;
    public bool hasPermuted = false;

    public static Action<int> onPermutation;
    private void Awake()
    {
        canPermute = false;
        playerData = GetComponentInParent<PlayerData>();
    }
    private void Start()
    {
        StartCoroutine(AddPermutation());
    }
    public void pressedPermutaion()
    {
        StartCoroutine(willPermute());

    }


    public IEnumerator willPermute()
    {
        canPermute = true;
        yield return new WaitForSeconds(1f);
        canPermute = false;
    }

    public void Permute()
    {
        // Will permute
        if (playerData.permutationBar.remainingPermutation >= 1 && !ia.isDead)
        {
            onPermutation?.Invoke(ia.playerIndex);
            StartCoroutine(HasPermuted());
            ia.isTakingDamage = false;
            ia.isInEnemyCombo = false;
            playerData.permutationBar.SetPermutation(playerData.permutationBar.remainingPermutation - 1);
            Instantiate(VFXPrefab, transform.position + offSet - transform.forward * backwardOffSet, transform.rotation);
            Debug.Log("Would have permuted");
            Vector3 newPos = playerData.target.position - playerData.target.forward * permutationOffSet;
            transform.position = newPos;
        }
    }

    private void Update()
    {
        //Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.blue);
        //            Permute();
        //canPermute = false;

    }

    public IEnumerator AddPermutation()
    {
        yield return new WaitForSeconds(15f);
        playerData.permutationBar.SetPermutation(playerData.permutationBar.remainingPermutation + 1);
        StartCoroutine(AddPermutation());
    }
    public IEnumerator HasPermuted()
    {
        hasPermuted = true;
        yield return new WaitForSeconds(0.3f);
        hasPermuted = false;
    }
}

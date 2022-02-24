using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Permutation : MonoBehaviour
{
    public float timeAfterPermute;
    public bool canPermute;
    public Player player;
    public PlayerData playerData;
    public float permutationOffSet;
    public CharacterController characterController;
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
        if (playerData.permutationBar.remainingPermutation >= 1 && !player.isDead)
        {
            onPermutation?.Invoke(player.playerIndex);
            StartCoroutine(HasPermuted());
            player.isTakingDamage = false;
            player.isInEnemyCombo = false;
            playerData.permutationBar.SetPermutation(playerData.permutationBar.remainingPermutation - 1);
            Instantiate(VFXPrefab, transform.position + offSet - transform.forward * backwardOffSet , transform.rotation);
            Debug.Log("Would have permuted");
            player.playerAudio.playSoundPermutation();
            characterController.enabled = false;
            Vector3 newPos = playerData.target.position - playerData.target.forward * permutationOffSet;
            transform.position = newPos;
            characterController.enabled = true;
        }
    }

    private void Update()
    {
        //Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.blue);
        if (player.canPermute && canPermute && !player.isInCombo)
        {
            Permute();
            player.canPermute = false;
            canPermute = false;
        }
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

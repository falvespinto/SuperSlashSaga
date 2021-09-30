using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        canPermute = false;
        playerData = GetComponentInParent<PlayerData>();
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
        Instantiate(VFXPrefab, transform.position + offSet - transform.forward * backwardOffSet , transform.rotation);
        Debug.Log("Would have permuted");
        characterController.enabled = false;
        Vector3 newPos = playerData.target.position - playerData.target.forward * permutationOffSet;
        transform.position = newPos;
        characterController.enabled = true;
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.blue);
        if (player.canPermute && canPermute)
        {
            Permute();
            player.canPermute = false;
            canPermute = false;
        }
    }
}

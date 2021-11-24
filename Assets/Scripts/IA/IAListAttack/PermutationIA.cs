using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermutationIA : MonoBehaviour
{
    public float timeAfterPermute;
    public bool canPermute;
    public PlayerData playerData;
    public float permutationOffSet;
    public GameObject VFXPrefab;
    public Vector3 offSet;
    public float backwardOffSet;
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
        if (playerData.permutationBar.remainingPermutation >= 1)
        {
            playerData.permutationBar.SetPermutation(playerData.permutationBar.remainingPermutation - 1);
            Instantiate(VFXPrefab, transform.position + offSet - transform.forward * backwardOffSet, transform.rotation);
            Debug.Log("Would have permuted");
            //characterController.enabled = false;
            Vector3 newPos = playerData.target.position - playerData.target.forward * permutationOffSet;
            transform.position = newPos;
            //characterController.enabled = true;
        }
    }

    private void Update()
    {
        //Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.blue);
            Permute();
            canPermute = false;
        
    }

    public IEnumerator AddPermutation()
    {
        yield return new WaitForSeconds(15f);
        playerData.permutationBar.SetPermutation(playerData.permutationBar.remainingPermutation + 1);
        StartCoroutine(AddPermutation());
    }
}

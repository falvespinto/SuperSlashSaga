﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float halfExtent;
    public int damage;
    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }
    void Update()
    {

        Collider[] hit = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, gameObject.GetComponentInParent<Player>().hurtBox);
        Debug.Log(gameObject.GetComponentInParent<Player>().playerIndex);
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                
                hit[i].GetComponentInParent<Player>().TakeDamage(damage);
                Debug.Log(hit[i].GetComponentInParent<Player>().playerIndex);
                Debug.Log(hit[i].gameObject.layer);
            }
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, new Vector3(0.1f, 0.1f, 0.1f));
    }
}

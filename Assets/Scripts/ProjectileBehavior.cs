using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public PlayerData playerData;
    public float projectileDamage;
    public string attackType;
    private void OnTriggerEnter(Collider col)
    {
        //Implement Behavior
        if (col.GetComponentInParent<PlayerData>().playerLayer != playerData.playerLayer)
        {
            if (col.GetComponentInParent<PlayerData>().playerLayer == playerData.enemyLayer)
            {
                col.GetComponentInParent<Player>().TakeDamage(projectileDamage, attackType);
            }
            Destroy(gameObject);
        }
        
    }
}

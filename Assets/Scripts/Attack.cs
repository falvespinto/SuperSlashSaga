using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float halfExtent;
    public int damage;
    public float damageMultiplier = 1;
    public string attackType;
    public string attackName;
    private Collider col;
    public PlayerAttack playerAttack;
    public PlayerAttackIA playerIA;
    public UltimateAttack ultimateAttack;
    public bool isIA = false;
    public float stunTime;
    public static Action<int> onComboIncrease;
    private void Awake()
    {
        col = GetComponent<Collider>();
        ultimateAttack = GetComponentInParent<UltimateAttack>();
    }

    public void SetDamageMultiplier(float multiplier)
    {
        damageMultiplier = multiplier;
    }

    private void FixedUpdate()
    {
        Collider[] hit = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, gameObject.GetComponentInParent<PlayerData>().enemyLayer);
        //Debug.Log(gameObject.GetComponentInParent<Player>().playerIndex);
        if (hit.Length > 0)
        {
            if (attackType == "Light" && !StartGame.managerIA.bIsIA)
            {
                onComboIncrease?.Invoke(playerAttack.player.playerIndex);
            }
            if (attackType == "Light" && StartGame.managerIA.bIsIA && GetComponentInParent<PlayerData>().playerIndex == 0)
            {
                onComboIncrease?.Invoke(playerAttack.player.playerIndex);
            }
            if (attackType == "Light" && StartGame.managerIA.bIsIA && GetComponentInParent<PlayerData>().playerIndex == 1)
            {
                onComboIncrease?.Invoke(playerIA.player.playerIndex);
            }
            for (int i = 0; i < hit.Length; i++)
            {
                if (isIA && GetComponentInParent<PlayerData>().playerIndex == 0)
                {
                    hit[i].GetComponentInParent<IA>().TakeDamage(damage * damageMultiplier, attackType);
                    playerAttack.playerHit = hit[i].GetComponentInParent<IA>().gameObject;
                    gameObject.SetActive(false);
                    break;
                }
                else if (isIA && GetComponentInParent<PlayerData>().playerIndex == 1)
                {
                    hit[i].GetComponentInParent<Player>().TakeDamage(damage * damageMultiplier, attackType);
                    playerIA.playerHit = hit[i].GetComponentInParent<Player>().gameObject;
                    gameObject.SetActive(false);
                    break;
                }
                else
                {
                    hit[i].GetComponentInParent<Player>().TakeDamage(damage * damageMultiplier, attackType);
                    Debug.Log(hit[i].GetComponentInParent<Player>().playerIndex);
                    Debug.Log(hit[i].gameObject.layer);
                    playerAttack.playerHit = hit[i].GetComponentInParent<Player>().gameObject;
                    if (attackType == "Engage") ultimateAttack.HandleFullUlt();
                    gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, new Vector3(0.1f, 0.1f, 0.1f));
    }
}

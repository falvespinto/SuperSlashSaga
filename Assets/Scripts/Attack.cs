using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float halfExtent;
    public int damage;
    public string attackType;
    private Collider col;
    public PlayerAttack player;
    public PlayerAttackIA playerIA;
    public UltimateAttack ultimateAttack;
    public bool isIA = false;
    public float stunTime;

    private void Start()
    {
        col = GetComponent<Collider>();
        
    }
    void Update()
    {

        //Collider[] hit = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, gameObject.GetComponentInParent<Player>().hurtBox);
        ////Debug.Log(gameObject.GetComponentInParent<Player>().playerIndex);
        //if (hit.Length > 0)
        //{
        //    for (int i = 0; i < hit.Length; i++)
        //    {
        //        hit[i].GetComponentInParent<Player>().TakeDamage(damage, attackType);
        //        Debug.Log(hit[i].GetComponentInParent<Player>().playerIndex);
        //        Debug.Log(hit[i].gameObject.layer);
        //        gameObject.SetActive(false);
        //        break;
        //    }
        //}
    }

    private void FixedUpdate()
    {
        Collider[] hit = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, gameObject.GetComponentInParent<PlayerData>().enemyLayer);
        //Debug.Log(gameObject.GetComponentInParent<Player>().playerIndex);
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                if (isIA && GetComponentInParent<PlayerData>().playerIndex == 0)
                {
                    hit[i].GetComponentInParent<IA>().TakeDamage(damage, attackType);
                    player.playerHit = hit[i].GetComponentInParent<IA>().gameObject;
                    gameObject.SetActive(false);
                    break;
                }
                else if (isIA && GetComponentInParent<PlayerData>().playerIndex == 1)
                {
                    hit[i].GetComponentInParent<Player>().TakeDamage(damage, attackType);
                    playerIA.playerHit = hit[i].GetComponentInParent<Player>().gameObject;
                    gameObject.SetActive(false);
                    break;
                }
                else
                {
                    hit[i].GetComponentInParent<Player>().TakeDamage(damage, attackType);
                    Debug.Log(hit[i].GetComponentInParent<Player>().playerIndex);
                    Debug.Log(hit[i].gameObject.layer);
                    player.playerHit = hit[i].GetComponentInParent<Player>().gameObject;
                    if (attackType == "Engage")
                    {
                        ultimateAttack.performFullUltimate = true;
                    }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public PlayerData playerData;
    public float projectileDamage;
    public string attackType;
    public float lifeTime = 3;
    public Vector3 hauteurTarget = new Vector3(0,-5,0);
    public float maxTurnSpeed = 60f;
    public float projectileSpeed = 20f;
    private void OnTriggerEnter(Collider col)
    {
        //Implement Behavior
        if (col.GetComponentInParent<PlayerData>().playerLayer != playerData.playerLayer)
        {
            if (col.GetComponentInParent<PlayerData>().playerLayer == playerData.enemyLayer)
            {
                if (StartGame.managerIA.bIsIA)
                {
                    if(col.GetComponentInParent<PlayerData>().playerIndex == 0)
                        col.GetComponentInParent<Player>().TakeDamage(projectileDamage, attackType);
                    if (col.GetComponentInParent<PlayerData>().playerIndex == 1)
                        col.GetComponentInParent<IA>().TakeDamage(projectileDamage, attackType);
                }

                else
                    col.GetComponentInParent<Player>().TakeDamage(projectileDamage, attackType);
                gameObject.SetActive(false);
            }  
        }
        
    }

    private void Start()
    {
        StartCoroutine(DestroyBulletAfterTime());
    }

    void OnDisable()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        Vector3 directionToTarget = playerData.target.position - (transform.position + hauteurTarget);
        Vector3 newdirectionToTarget = new Vector3(directionToTarget.x, transform.position.y, directionToTarget.z);
        Vector3 currentDirection = transform.forward;
        Vector3 resultingDirection = Vector3.RotateTowards(currentDirection, directionToTarget.normalized, maxTurnSpeed * Mathf.Deg2Rad * Time.deltaTime, 1f);
        transform.rotation = Quaternion.LookRotation(resultingDirection);
    }

    private IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(lifeTime);
        //currentProjectiles.Remove(projectile);
        //Destroy(projectile);
        gameObject.SetActive(false);
    }

}


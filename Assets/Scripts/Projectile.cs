using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileBehavior projectilePrefab;
    public Transform projectileSpawnPoint;
    public float projectileSpeed = 20;
    public float lifeTime = 3;
    private PlayerData playerData;
    public PlayerAttack playerAttack;
    public bool isShooting;
    public float coolDown;
    public Animator m_animator;
    public float timeBeforeShoot;
    public bool canShoot;
    public float isShootingCooldown;
    void Start()
    {
        playerData = gameObject.GetComponentInParent<PlayerData>();
        isShooting = false;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PrepareFire()
    {
        if (canShoot)
        {
            m_animator.SetBool("projectile", true);
            playerAttack.LookAtTarget();
            StartCoroutine(Cooldown());
            StartCoroutine(IsShooting());
            StartCoroutine(Fire());
        }

    }

    public IEnumerator Fire()
    {
        yield return new WaitForSeconds(timeBeforeShoot);
        FindObjectOfType<AudioManager>().Play("epee");
        ProjectileBehavior projectile = Instantiate(projectilePrefab);
        projectile.playerData = playerData;
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(),
            projectileSpawnPoint.parent.GetComponent<Collider>());

        projectile.transform.position = projectileSpawnPoint.position;
        Vector3 rotation = projectile.transform.rotation.eulerAngles;

        projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        projectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileSpeed, ForceMode.VelocityChange);

        StartCoroutine(DestroyBulletAfterTime(projectile));
    }
    private IEnumerator DestroyBulletAfterTime(ProjectileBehavior projectile)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(projectile);
    }

    private IEnumerator IsShooting()
    {
        
        isShooting = true;
        yield return new WaitForSeconds(isShootingCooldown);
        isShooting = false;
        m_animator.SetBool("projectile", false);
    }

    private IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
}

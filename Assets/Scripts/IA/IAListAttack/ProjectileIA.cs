using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileIA : MonoBehaviour
{
    public ProjectileBehavior projectilePrefab;
    public Transform projectileSpawnPoint;
    public float projectileSpeed = 120f;
    public float lifeTime = 3;
    private PlayerData playerData;
    public PlayerAttackIA playerAttack;
    public bool isShooting;
    public Vector3 hauteurTarget;
    public float maxTurnSpeed = 60f;
    public float coolDown;
    public Animator m_animator;
    public float timeBeforeShoot;
    public bool canShoot;
    public float isShootingCooldown;
    public List<ProjectileBehavior> currentProjectiles = new List<ProjectileBehavior>();
    public IA player;
    public UltimateAttack ultimateAttack;


    private void Awake()
    {
        playerData = GetComponentInParent<PlayerData>();
    }

    void Start()
    {
        playerData = gameObject.GetComponentInParent<PlayerData>();
        isShooting = false;
        canShoot = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentProjectiles.Count > 0)
        {
            //FollowTarget(); 
        }
    }
    
    public void PrepareFire()
    {
        if (canShoot && !player.isInCombo && !playerAttack.isAttacking)
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
        projectilePrefab.maxTurnSpeed = maxTurnSpeed;
        projectilePrefab.projectileSpeed = projectileSpeed;
        projectilePrefab.lifeTime = lifeTime;
        projectilePrefab.hauteurTarget = hauteurTarget;

        ProjectileBehavior projectile = Instantiate(projectilePrefab);
        projectile.playerData = playerData;
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(),
            projectileSpawnPoint.parent.GetComponent<Collider>());

        projectile.transform.position = projectileSpawnPoint.position;
        Vector3 rotation = projectile.transform.rotation.eulerAngles;

        projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        //currentProjectiles.Add(projectile);
        //StartCoroutine(DestroyBulletAfterTime(projectile));
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

    private void FollowTarget()
    {
        foreach (var projectile in currentProjectiles)
        {
            if (projectile.gameObject.activeSelf == true)
            {
                projectile.transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
                Vector3 directionToTarget = playerData.target.position - (projectile.transform.position + hauteurTarget);
                Vector3 newdirectionToTarget = new Vector3(directionToTarget.x, projectile.transform.position.y, directionToTarget.z);
                Vector3 currentDirection = projectile.transform.forward;
                Vector3 resultingDirection = Vector3.RotateTowards(currentDirection, directionToTarget.normalized, maxTurnSpeed * Mathf.Deg2Rad * Time.deltaTime, 1f);
                projectile.transform.rotation = Quaternion.LookRotation(resultingDirection);
            }
        }
    }
}
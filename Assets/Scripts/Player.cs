using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public int playerIndex;
    public LayerMask hurtBox;
    public HealthBar healthBar;
    public PlayerAttack playerAttack;
    public PlayerController playerController;
    public static int winner;
    public float GuardBreakTime;
    public bool isTakingDamage;
    private Rigidbody m_rigidbody;
    public Animator animator;
    public Transform target;
    void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerController = GetComponent<PlayerController>();
        //m_rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        UpdateAnimClipTimes();
        currentHealth = maxHealth;
        isTakingDamage = false;
        FindObjectOfType<AudioManager>().Play("combat");
    }
    public void TakeDamage(float damage, string attackType)
    {
        Vector3 dir = target.position - transform.position;
        dir.Normalize();
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
        if (playerAttack.isParing)
        {
            if (attackType == "Heavy")
            {
                isTakingDamage = true;
                Invoke("ResetIsTakingDamage", GuardBreakTime);
                animator.SetTrigger("Guard_Break");
               // m_rigidbody.velocity = new Vector2(0f, m_rigidbody.velocity.y); // déplacements horizontaux bloqués
                currentHealth -= damage * 1.1f;
                healthBar.SetHealth(currentHealth);
                if (currentHealth <= 0)
                {
                    animator.SetTrigger("Dead");
                    Invoke("Die", 3f);
                }
            }
            else
            {
                playerAttack.AttackedWhileParing();
            }

        }
        else
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                animator.SetTrigger("Dead");
                Invoke("Die", 3f);
            }
        }
    }
    void Die()
    {
        SceneManager.LoadScene("MenuVictoire");
        Debug.Log("arg je suis mor PLAYER");
        if (playerIndex == 1)
        {
            winner = 1;
        }
        else
        {
            winner = 2;
        }
    }
    void ResetIsTakingDamage()
    {
        isTakingDamage = false;
    }

    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Guard_BreakYuetsu":
                    GuardBreakTime = clip.length / 1.5f;
                    break;
            }
        }
    }
}

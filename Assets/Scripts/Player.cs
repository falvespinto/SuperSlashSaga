using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    public PlayerAttack playerAttack;
    void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        if (playerAttack.isParing)
        {
            playerAttack.AttackedWhileParing();
        }
        else
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }

    }
    void Die()
    {
        Debug.Log("arg je suis mor PLAYER");
    }
}

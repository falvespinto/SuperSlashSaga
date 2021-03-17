using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        FindObjectOfType<AudioManager>().Play("combat");
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Je prend des dégats");
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("arg je suis mor PLAYER");
    }
}

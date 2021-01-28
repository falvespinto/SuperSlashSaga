using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest2 : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("arg j'ai pris " + damage + " de dégats");
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("arg je suis mor");
    }
}

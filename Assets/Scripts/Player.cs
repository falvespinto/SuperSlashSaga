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
    public static int winner;
    void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }
    void Start()
    {
        currentHealth = maxHealth;

        FindObjectOfType<AudioManager>().Play("combat");
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
}

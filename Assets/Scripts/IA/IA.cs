using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IA : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public int playerIndex;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public PlayerAttackIA playerAttackIA;
    public static int winner;
    public float GuardBreakTime;
    public bool isTakingDamage;
    public float GetHitTime;
    private Rigidbody m_rigidbody;
    public Animator animator;
    public Transform target;
    public bool isInCombo;
    public PlayerData playerData;
    public bool canPermute;
    public bool isInEnemyCombo;
    public bool isDead;
    public Sprite faceSprite;
    public GameObject HitVFXPrefab;
    public GameObject HitHeavyPrefab;
    public Vector3 offSet;
    public PlayerAudioManager playerAudio;
    public string characterName;
    void Awake()
    {
        isDead = false;
        isInEnemyCombo = false;
        playerData = GetComponentInParent<PlayerData>();
        playerAttackIA = GetComponent<PlayerAttackIA>();
        healthBar = playerData.healthBar;
        manaBar = playerData.manabar;
        playerIndex = playerData.playerIndex;
        //GetComponentInParent<PlayerData>().target = GetComponentInParent<PlayerData>().playerTarget.GetComponentInChildren<Player>().transform;
        //m_rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        UpdateAnimClipTimes();
        currentHealth = maxHealth;
        isTakingDamage = false;
        isInCombo = false;
        canPermute = false;
        target = playerData.target;
    }
    void Update()
    {
        if (target == null)
        {
            target = playerData.target;
        }
    }
    public void TakeDamage(float damage, string attackType)
    {

        if (attackType == "Light")
        {
            Instantiate(HitVFXPrefab, transform.position + offSet, transform.rotation);
            //playerAudio.playSoundImpact();
        }
        else if (attackType == "Heavy")
        {
            Instantiate(HitHeavyPrefab, transform.position + offSet, transform.rotation);
            //playerAudio.playSoundLourd();
        }
        Vector3 dir = target.position - transform.position;
        dir.Normalize();
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
        if (playerAttackIA.isParing)
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
                playerAttackIA.AttackedWhileParing();
            }

        }
        else
        {
            if (attackType == "Combo")
            {
                isTakingDamage = true;
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
            }
            else
            {
                StartCoroutine(willPermute());
                isTakingDamage = true;
                Invoke("ResetIsTakingDamage", GetHitTime);
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
                if (currentHealth <= 0)
                {
                    animator.SetTrigger("Dead");
                    isDead = true;
                    Invoke("Die", 3f);
                }
                else
                {
                    animator.SetTrigger("GetHit");
                }

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
                case "GetHitYuetsu":
                    GetHitTime = clip.length;
                    break;
            }
        }
    }

    public IEnumerator willPermute()
    {
        canPermute = true;
        yield return new WaitForSeconds(1f);
        canPermute = false;
    }

    public IEnumerator goInEnemyCombo(float time)
    {
        isInEnemyCombo = true;
        yield return new WaitForSeconds(time);
        isInEnemyCombo = false;

    }

}

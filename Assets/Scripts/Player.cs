using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public int playerIndex;
    public HealthBar healthBar;
    public ManaBar manabar;
    public PlayerAttack playerAttack;
    public PlayerController playerController;
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
    public Parade parade;
    public Permutation permutation;
    public PlayerAudioManager playerAudio;
    public GameObject HitVFXPrefab;
    public GameObject HitHeavyPrefab;
    public float hurtTimeHeavy;
    public float hurtTimeLight;
    public float hurtTimeUltimate;
    public Vector3 offSet;
    public float hurtTime = 0;
    public string characterName;
    public Sprite faceSprite;
    public bool manaUp = false;
    private bool askedForHelp = false;
    private int sendHelpState = 0;

    public GameObject mousseObject;
    public GameObject weapon;
    public static Action<int> OnDeath;
    public static Action<int> onGuardBroke;
    public static Action<Dictionary<string, int>, float, Action<string>, Action<string,int>> onHelpAsked;
    public Action<string> whenVoteStopped;
    public Dictionary<string, int> choixHelp = new Dictionary<string, int>
    {
        {"oui", 0},
        {"non", 0}
    };
    void Awake()
    {
        isDead = false;
        isInEnemyCombo = false;
        playerData = GetComponentInParent<PlayerData>();
        playerController = GetComponent<PlayerController>();
        healthBar = playerData.healthBar;
        manabar = playerData.manabar;
        playerIndex = playerData.playerIndex;
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
    private void OnEnable()
    {
        whenVoteStopped += OnVoteStopped;
    }
    private void OnDisable()
    {
        whenVoteStopped -= OnVoteStopped;
    }
    void Update()
    {
        if (target == null)
        {
            target = playerData.target;
        }
        if (isTakingDamage)
        {
            if (hurtTime > 0)
            {
                hurtTime = hurtTime - Time.deltaTime;
            }
            if (hurtTime <= 0)
            {
                isTakingDamage = false;
                hurtTime = 0;
            }
        }

    }
    private void FixedUpdate()
    {
        if (manaUp) manabar.SetMana(manabar.mana + 1);


    }

    public void TakeDamage(float damage, string attackType)
    {

        if (attackType == "Light")
        {
            Vector3 newPos = transform.position + offSet;
            Instantiate(HitVFXPrefab, newPos , transform.rotation);
            playerAudio.playSoundImpact();
        }
        else if(attackType == "Heavy")
        {
            Instantiate(HitHeavyPrefab, transform.position + offSet, transform.rotation);
            playerAudio.playSoundLourd();
        }

        Vector3 dir = target.position - transform.position;
        dir.Normalize();
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
        
        if (playerAttack.isParing)
        {
            if (attackType == "Heavy")
            {
                //StopCoroutine(ResetIsTakingDamage(GuardBreakTime));
                //StartCoroutine(ResetIsTakingDamage(GuardBreakTime));
                onGuardBroke?.Invoke(playerIndex);
                stunTime(GuardBreakTime);
                Invoke("ResetIsTakingDamage", GuardBreakTime);
                animator.SetTrigger("Guard_Break");
                parade.shield.SetActive(false);
                // m_rigidbody.velocity = new Vector2(0f, m_rigidbody.velocity.y); // déplacements horizontaux bloqués
                currentHealth -= damage * 1.1f;
                healthBar.SetHealth(currentHealth);
                if (currentHealth <= 0)
                {
                    OnDeath?.Invoke(playerIndex);
                    isDead = true;
                    animator.SetTrigger("Dead");
                    playerAudio.playSoundMort();
                    Invoke("Die", 3f);
                }
            }
            else
            {
                if (attackType != "Combo" && attackType != "Ultimate")
                {
                    playerAttack.AttackedWhileParing();
                    playerAudio.playSoundParade();
                }
                
            }

        }
        else
        {

            if (attackType == "Combo")
            {
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
            }
            else
            {
                StartCoroutine(willPermute());
                if (!permutation.canPermute)
                {
                    switch (attackType)
                    {
                        case "Heavy":
                            //StopCoroutine(ResetIsTakingDamage(hurtTimeHeavy));
                            //StartCoroutine(ResetIsTakingDamage(hurtTimeHeavy));
                            stunTime(hurtTimeHeavy);
                            break;
                        case "Light":
                            //StopCoroutine(ResetIsTakingDamage(hurtTimeLight));
                            //StartCoroutine(ResetIsTakingDamage(hurtTimeLight));
                            stunTime(hurtTimeLight);
                            break;
                        case "Engage":
                            //StopCoroutine(ResetIsTakingDamage(hurtTimeUltimate));
                            //StartCoroutine(ResetIsTakingDamage(hurtTimeUltimate));
                            stunTime(hurtTimeUltimate);
                            break;

                    }
                    currentHealth -= damage;
                    //if(currentHealth <= 0 && count == 1)
                    //{
                    //    playerAudio.playSoundCoupFinalLourd();
                    //}
                    //else if(currentHealth <= 0 && count == 2)
                    //{
                    //    playerAudio.playSoundCoupFinalLeger();
                    //}
                    healthBar.SetHealth(currentHealth);
                    if (currentHealth <= 0)
                    {
                        OnDeath?.Invoke(playerIndex);
                        animator.SetTrigger("Dead");
                        playerAudio.playSoundMort();
                        isDead = true;
                        Invoke("Die", 3f);
                    }
                    else
                    {
                        animator.SetInteger("RandomHit", UnityEngine.Random.Range(0,2));
                        animator.SetTrigger("GetHit");
                    }
                }
            }
        }
    }
    void Die()
    {
        SceneManager.LoadScene("MenuVictoire");
        Debug.Log("arg je suis mor PLAYER");
        winner = playerIndex == 1 ? 1 : 2;
        //if (playerIndex == 1)
        //{
        //    winner = 1;
        //}
        //else
        //{
        //    winner = 2;
        //}
    }
    public IEnumerator ResetIsTakingDamage(float hurtTime)
    {
        isTakingDamage = true;
        yield return new WaitForSeconds(hurtTime);
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

    public void ChargeUpMana(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            manaUp = true;
        }
        if (ctx.canceled)
        {
            manaUp = false;
        }
    }

    public void LetsDance()
    {
        animator.SetTrigger("Dance");
    }

    public void bumped(float time)
    {
        //StopCoroutine(ResetIsTakingDamage(time));
        //StartCoroutine(ResetIsTakingDamage(time));
        stunTime(time);
        playerAttack.LookAtTarget();
        animator.SetTrigger("Bumped");
    }

    public void stunTime(float time)
    {
        isTakingDamage = true;
        hurtTime = time;
    }

    public void AnimTest()
    {
        animator.SetTrigger("test");
    }

    public void AskForHelp()
    {
        if (!askedForHelp)
        {
            askedForHelp = true;
            onHelpAsked?.Invoke(choixHelp, 60f, whenVoteStopped, null);
            TwitchChat.Instance.SendIRCMessage("Le joueur " + (playerIndex + 1) + " vous demande de l'aide, mais le mérite-t-il ? Oui ou Non ?");
        }
    }
    public void OnVoteStopped(string result)
    {
        choixHelp = new Dictionary<string, int>
        {
            {"oui", 0},
            {"non", 0}
        };
        Debug.Log(result);
        if (result == "oui")
        {

        }
        else
        {
            StartCoroutine(StartMousseMalus());
        }
    }

    public IEnumerator StartMousseMalus()
    {
        mousseObject.SetActive(true);
        if (weapon != null) weapon.GetComponent<SkinnedMeshRenderer>().enabled = false;
        yield return new WaitForSeconds(10f);
        if (weapon != null) weapon.GetComponent<SkinnedMeshRenderer>().enabled = true;
        mousseObject.SetActive(false);
    }
}
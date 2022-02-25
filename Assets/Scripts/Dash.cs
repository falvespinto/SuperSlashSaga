using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    private Vector2 movementInput;
    private CharacterController controller;
    public float dashSpeed;
    public float dashDuration;
    public bool isDashing;
    public Vector3 dashDirection;
    public Transform cam;
    public Vector3 moveDirection;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public Animator m_animator;
    public PlayerAttack playerAttack;
    public float infuseTime = 1.5f;
    private UltimateAttack ultimateAttack;
    public bool isInfusing = false;
    public bool hasTouched = false;
    public bool isEngaging = false;
    public Player player;
    public Collider engageArea;
    public float maxTurnSpeed = 60f;
    public static Action<int> OnDash;
    public PlayerAudioManager playerAudio;
    public float dashTime = 1f;
    public float manaCost = 25f; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        ultimateAttack = GetComponent<UltimateAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            //engageArea.gameObject.SetActive(true);
            Collider[] hit = Physics.OverlapBox(engageArea.bounds.center, engageArea.bounds.extents, engageArea.transform.rotation, gameObject.GetComponentInParent<PlayerData>().enemyLayer);
            if (hit.Length > 0 && !StartGame.managerIA.bIsIA)
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    hit[i].GetComponentInParent<Player>().bumped(0.8f);
                    Debug.Log(hit[i].GetComponentInParent<Player>().playerIndex);
                    Debug.Log(hit[i].gameObject.layer);
                    hasTouched = true;
                    isDashing = false;
                    //engageArea.gameObject.SetActive(false);
                    break;
                }
            }
            else if(hit.Length > 0 && StartGame.managerIA.bIsIA)
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    hit[i].GetComponentInParent<IA>().bumped(0.8f);
                    hasTouched = true;
                    isDashing = false;
                    //engageArea.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }

    public void dashButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!isDashing && !playerAttack.isAttacking && !playerAttack.isParing && !ultimateAttack.isPerformingUltimate && !player.isInCombo)
            {
                if (player.manabar.mana >= 25 )
                {
                    player.manabar.SetMana(player.manabar.mana - 25);
                    OnDash?.Invoke(player.playerIndex);
                    StartCoroutine(DashMovement());
                }
            }
        }
    }


    public void ControllerDirection(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public IEnumerator DashMovement()
    {
        // ANCIEN SAUT/DASH je garde pour l'instant FIX
        //m_animator.SetBool("isDashing", true);
        //isDashing = true;
        //float startTime = Time.time;
        //while (Time.time < startTime + dashDuration)
        //{
        //    Debug.Log("dashMovement");
        //    controller.Move(transform.forward * dashSpeed * Time.deltaTime);
        //    yield return null;
        //}
        ////yield return new WaitForSeconds(0.25f);
        //isDashing = false;
        //m_animator.SetBool("isDashing", false);

        // Regarde vers l'adversaire
        float timeElapsed = 0;
        Vector3 direction = playerAttack.LookAtTarget();
        m_animator.SetBool("isDashing", true);
        playerAudio.playSoundDash();
        isDashing = true;
        while (!hasTouched && timeElapsed < 1f && !player.isTakingDamage)
        {
            Vector3 directionToTarget = playerAttack.playerData.target.position - (transform.position);
            Vector3 currentDirection = transform.forward;
            Vector3 resultingDirection = Vector3.RotateTowards(currentDirection, directionToTarget.normalized, maxTurnSpeed * Mathf.Deg2Rad * Time.deltaTime, 1f);
            transform.rotation = Quaternion.LookRotation(resultingDirection);
            controller.Move(transform.forward * dashSpeed * Time.deltaTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        controller.Move(Vector3.zero);
        //yield return new WaitForSeconds(0.25f);
        isDashing = false;
        hasTouched = false;
        m_animator.SetBool("isDashing", false);
    }

    public IEnumerator Infuse() {
        isInfusing = true;
        yield return new WaitForSeconds(infuseTime);
        isInfusing = false;
    }
}


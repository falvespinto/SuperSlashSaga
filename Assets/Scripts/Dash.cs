using System.Collections;
using System.Collections.Generic;
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
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        ultimateAttack = GetComponent<UltimateAttack>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void dashButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!isDashing && !playerAttack.isAttacking && !playerAttack.isParing && !ultimateAttack.isPerformingUltimate && !player.isInCombo)
            {
                StartCoroutine(DashMovement());
            }
        }
    }


    public void ControllerDirection(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public IEnumerator DashMovement()
    {
        m_animator.SetBool("isDashing", true);
        isDashing = true;
        float startTime = Time.time;
        while (Time.time < startTime + dashDuration)
        {
            Debug.Log("dashMovement");
            controller.Move(transform.forward * dashSpeed * Time.deltaTime);
            yield return null;
        }
        //yield return new WaitForSeconds(0.25f);
        isDashing = false;
        m_animator.SetBool("isDashing", false);
    }

    public IEnumerator Infuse() {
        isInfusing = true;
        yield return new WaitForSeconds(infuseTime);
        isInfusing = false;
    }
}


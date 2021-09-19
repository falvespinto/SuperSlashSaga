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
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void dashButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!isDashing)
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
            controller.Move(transform.forward * dashSpeed);
            yield return null;
        }
        //yield return new WaitForSeconds(0.25f);
        isDashing = false;
        m_animator.SetBool("isDashing", false);
    }
}


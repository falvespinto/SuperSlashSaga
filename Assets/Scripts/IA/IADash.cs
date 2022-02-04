using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class IADash : MonoBehaviour
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
    public PlayerAttackIA playerAttack;
    public float infuseTime = 1.5f;
    private UltimateAttack ultimateAttack;
    public bool isInfusing = false;
    public bool hasTouched = false;
    public bool isEngaging = false;
    public bool isDashingOn = false;
    public IA ia;
    public Collider engageArea;
    public GameObject gameObjectIA;
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

    public void DashOn()
    {

        engageArea.gameObject.SetActive(true);
        Collider[] hit = Physics.OverlapBox(engageArea.bounds.center, engageArea.bounds.extents, engageArea.transform.rotation, gameObject.GetComponentInParent<PlayerData>().enemyLayer);
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                hit[i].GetComponentInParent<Player>().bumped(0.8f);
                Debug.Log(hit[i].GetComponentInParent<Player>().playerIndex);
                Debug.Log(hit[i].gameObject.layer);
                hasTouched = true;
                isDashing = false;
                engageArea.gameObject.SetActive(false);
                break;
            }
        }
    }
    public void ControllerDirection(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void DashMovement()
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
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        Vector3 direction = playerAttack.LookAtTarget();
        m_animator.SetBool("isDashing", true);
        isDashing = true;
        while (!hasTouched)
        {
            agent.Move(transform.forward * dashSpeed * Time.deltaTime);
        }
        //yield return new WaitForSeconds(0.25f);
        isDashing = false;
        hasTouched = false;
        m_animator.SetBool("isDashing", false);
    }

    public IEnumerator Infuse()
    {
        isInfusing = true;
        yield return new WaitForSeconds(infuseTime);
        isInfusing = false;
    }
}


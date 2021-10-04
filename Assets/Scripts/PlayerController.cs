using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Runtime;
public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Player player;
    private bool isAttacking;
    public Attack punch;
    public bool firstTimeRunning;
    public PlayerAttack playerAttack;
    public bool isRunning = false;

    private Vector2 movementInput;
    public bool isParing;
    private Vector3 direction;
    public Vector3 moveDirection;
    public float gravity;
    public UltimateAttack ultimate;
    public Dash dashState;
    public Projectile projectile;
    public float rotationSpeed;

    public CharacterController controller;

    // Temps d'une animation
    float lightAttackTime;
    public Transform cam;
    public PlayerData playerData;

    [SerializeField] public float translationSpeed; // Vitesse de déplacement
    private void Awake()
    {
        playerData = GetComponentInParent<PlayerData>();
    }
    void Start()
    {
        firstTimeRunning = true;
        cam = playerData.camera;
        isAttacking = false;
    }
    void Update()
    {
        isAttacking = playerAttack.isAttacking;
        isParing = playerAttack.isParing;
        moveDirection = new Vector3();

        if (!isAttacking && !isParing && !player.isTakingDamage && !player.isInCombo && !ultimate.isPerformingUltimate && !dashState.isDashing && !projectile.isShooting && !player.isInEnemyCombo && !player.isDead)
        {
            Movement(movementInput);
        }
        else
        {
            isRunning = false;
            animator.SetBool("IsRunning", false);
        }


        moveDirection.y -= gravity;
        controller.Move(moveDirection);

    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    // retourne 1 si number superrieur à 0 retourne -1 si inférieur à 0 retourne 0 si = 0
    public void Movement(Vector2 movementInputs)
    {
        direction = new Vector3(movementInputs.x, 0f, movementInputs.y);
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);//Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, targetAngle, 0f), rotationSpeed);
            moveDirection = direction.x * cam.right + direction.z * cam.forward;
            moveDirection.y = 0f;
            moveDirection *= translationSpeed;

        }
        if (movementInputs.x != 0f || movementInputs.y != 0f)
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsWalking", false);
            isRunning = true;
            if (firstTimeRunning)
            {
                firstTimeRunning = false;
            }
        }
        else
        {
            firstTimeRunning = true;
            isRunning = false;
            animator.SetBool("IsRunning", false);
        }
    }
}


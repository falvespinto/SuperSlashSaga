using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Runtime;
public class PlayerController : MonoBehaviour
{

    private Rigidbody m_Rigidbody;
    private Transform m_Transform;
    public Animator m_Animator;
    public Player player;
    private bool isAttacking;
    private string m_AnimationCurrentState; // l'animation en cours
    public Attack punch;
    public bool firstTimeRunning;
    // temporaire 
    const string m_Run = "Run";
    const string m_Punch = "Punch";
    const string m_Idle = "Idle";
    public PlayerAttack m_PlayerAttack;
    public bool isRunning = false;
    // Variables en rapport avec l'utilisation des JoyCons

    public Quaternion orientation;
    public bool isJoyconPluggued;
    private Vector2 movementInput;
    public bool isParing;
    private Vector3 direction;
    public Vector3 moveDirection;
    public float gravity;
    public UltimateAttack ultimate;
    public Dash dashState;
    public Projectile projectile;
    //public JoyconController joyconController;


    private AnimationClip clip;
    public CharacterController controller;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    // Temps d'une animation
    float lightAttackTime;
    public Transform cam;
    public PlayerData playerData;

    [SerializeField] public float m_TranslationSpeed; // Vitesse de déplacement
    private void Awake()
    {
  //      m_Rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();
        playerData = GetComponentInParent<PlayerData>();
        ultimate = GetComponent<UltimateAttack>();
        dashState = GetComponent<Dash>();
        projectile = GetComponent<Projectile>();
    }
    void Start()
    {
        firstTimeRunning = true;
        cam = playerData.camera;
        isAttacking = false;
        // setup des variables en rapport avec les joycons
        //gyroscop = new Vector3(0, 0, 0);
        //accel = new Vector3(0, 0, 0);
        //m_Joycons = JoyconManager.Instance.j;
        //if (m_Joycons.Count < jc_ind + 1)
        //{
        //    isJoyconPluggued = false;
        //}
        //else
        //{
        //    isJoyconPluggued = true;
        //}

    }
    void Update()
    {
        isAttacking = m_PlayerAttack.isAttacking;
        isParing = m_PlayerAttack.isParing;
        moveDirection = new Vector3();


        if (isJoyconPluggued)
        {

        }
        if (!isAttacking && !isParing && !player.isTakingDamage && !player.isInCombo && !ultimate.isPerformingUltimate && !dashState.isDashing && !projectile.isShooting && !player.isInEnemyCombo && !player.isDead)
        {
            //if (joyconController.isJoyconPluggued)
            //{
            //    Movement(joyconController.movementInput);
            //}
            //else
            //{
                Movement(movementInput);
            //}
        }
        else
        {
            isRunning = false;
            m_Animator.SetBool("IsRunning", false);
        }


        moveDirection.y -= gravity;
        controller.Move(moveDirection);

    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    // retourne 1 si number superrieur à 0 retourne -1 si inférieur à 0 retourne 0 si = 0
    public void Movement(Vector2 movementInputs)
    {
        // Attention c'est vraiment moche a modifier bientôt
        //if (playerData.playerIndex == 1)
        //{
        //    direction = new Vector3(-movementInputs.x, 0f, -movementInputs.y);
        //}
        //else
        //{
            direction = new Vector3(movementInputs.x, 0f, movementInputs.y);
        //}
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            moveDirection = direction.x * cam.right + direction.z * cam.forward;//Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDirection.y = 0f;
            moveDirection *= m_TranslationSpeed;

        }
        if (movementInputs.x != 0f || movementInputs.y != 0f)
        {
            m_Animator.SetBool("IsRunning", true);
            m_Animator.SetBool("IsWalking", false);
            isRunning = true;
            if (firstTimeRunning)
            {
                FindObjectOfType<AudioManager>().Play("deplacement");
                firstTimeRunning = false;
            }
            //ChangeAnimationState(m_Run);
        }
        else
        {
            if (!firstTimeRunning)
            {
                FindObjectOfType<AudioManager>().Stop("deplacement");
            }
            firstTimeRunning = true;
            // ChangeAnimationState(m_Idle);
            isRunning = false;
            m_Animator.SetBool("IsRunning", false);
        }
    }
}


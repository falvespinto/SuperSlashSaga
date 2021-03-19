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
    private bool isAttacking;
    private bool isRunAttacking;
    private string m_AnimationCurrentState; // l'animation en cours
    public Attack punch;
    // temporaire 
    const string m_Run = "Run";
    const string m_Punch = "Punch";
    const string m_Idle = "Idle";
    private PlayerAttack m_PlayerAttack;
    public bool isRunning = false;
    // Variables en rapport avec l'utilisation des JoyCons

    private List<Joycon> m_Joycons;
    public float[] stick;
    public Vector3 gyroscop;
    public Vector3 accel;
    public int jc_ind = 0;
    public Quaternion orientation;
    public bool isJoyconPluggued;
    private Vector2 movementInput;

    private AnimationClip clip;


    // Temps d'une animation
    float lightAttackTime;

    [SerializeField] public float m_TranslationSpeed; // Vitesse de déplacement
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();
        m_PlayerAttack = GetComponent<PlayerAttack>();
    }
    void Start()
    {
        isAttacking = false;
        isRunAttacking = false;
        UpdateAnimClipTimes();
        // setup des variables en rapport avec les joycons
        gyroscop = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        m_Joycons = JoyconManager.Instance.j;
        if (m_Joycons.Count < jc_ind + 1)
        {

            isJoyconPluggued = false;
        }
        else
        {
            isJoyconPluggued = true;

        }
    }

    void Update()
    {
        isAttacking = m_PlayerAttack.isAttacking;
        isRunAttacking = m_PlayerAttack.isRunAttacking;
//        if (isJoyconPluggued)
//        {
//            Joycon j = m_Joycons[jc_ind];
//            if (j.GetButtonDown(Joycon.Button.SHOULDER_2))
//            {
//                Debug.Log("1");
//                // GetStick returns a 2-element vector with x/y joystick components
//                Debug.Log(string.Format("Stick x: {0:N} Stick y: {1:N}", j.GetStick()[0], j.GetStick()[1]));

//                // Joycon has no magnetometer, so it cannot accurately determine its yaw value. Joycon.Recenter allows the user to reset the yaw value.
//                j.Recenter();
//            }


//            // Gyro values: x, y, z axis values (in radians per second)
//            gyroscop = j.GetGyro();

//            // Accel values:  x, y, z axis values (in Gs)
//            accel = j.GetAccel();

//            orientation = j.GetVector();

//            if ((accel.z < -1 || accel.z > 1) && !isAttacking)
//            {
//                isAttacking = true;
////                Attack();
//            }

//            if (j.GetButtonDown(Joycon.Button.DPAD_RIGHT))
//            { 
//                j.SetRumble(160, 320, 0.6f, 200);
//            }

//            j = m_Joycons[1];
//            m_Rigidbody.velocity = new Vector2(Sign(j.GetStick()[0]) * m_TranslationSpeed, m_Rigidbody.velocity.y); // déplacements horizontaux
//            if (Sign(j.GetStick()[0]) != 0)
//            {
//                //ChangeAnimationState(m_Run);
                
//            }
//            else
//            {
//                //ChangeAnimationState(m_Idle);
//            }
//            stick = j.GetStick();


            

//        }

        if (!isAttacking)
        {
            if (isJoyconPluggued)
            {
                
            }
            else
            {
                if (!isRunAttacking)
                {
                    m_Rigidbody.velocity = new Vector2(movementInput.x * m_TranslationSpeed, 0); // déplacements horizontaux
                }
                if (movementInput.x != 0f)
                {
                    if (movementInput.x > 0)
                    {
                        if (!isRunAttacking)
                        {
                            m_Animator.SetBool("IsRunning", true);
                        }
                        else
                        {
                            m_Animator.SetBool("IsRunning", false);
                        }
                        
                        m_Animator.SetBool("IsWalking", false);
                        isRunning = true;
                    }
                    else
                    {
                        isRunning = false;
                        if (!isRunAttacking)
                        {
                            m_Animator.SetBool("IsWalking", true);
                        }
                        else
                        {
                            m_Animator.SetBool("IsWalking", false);
                        }
                        
                        m_Animator.SetBool("IsRunning", false);
                    }
                    //ChangeAnimationState(m_Run);
                }
                else
                {
                    // ChangeAnimationState(m_Idle);
                    isRunning = false;
                    m_Animator.SetBool("IsWalking", false);
                    m_Animator.SetBool("IsRunning", false);
                }
            }
            

        }


        //if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
        //{
        //    isAttacking = true;
        //    Attack("light");

        //}

        //if (Input.GetKeyDown(KeyCode.M) && !isAttacking)
        //{

        //    isAttacking = true;
        //    Attack("heavy");

        //}

        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    m_Animator.SetTrigger("IsRangingSonArme");
        //}
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    // retourne 1 si number superrieur à 0 retourne -1 si inférieur à 0 retourne 0 si = 0
    int Sign(float number)
    {
        if (number == 0)
        {
            return 0;
        }
        else
        {
            if (number > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }


    private void FixedUpdate()
    {


    }

    void Attack(string attack)
    {

        switch (attack)
        {
            case "light":
// Question importante : les Animation events sont ils fiables ? Si non, peut être un simple setActive dans ce script serait plus performant ? 
// Cela retirerait le fait de pouvoir choisir frame par frame si on applique un coup mais serait peut être plus performant ?
                Debug.Log("is attacking light");
                m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
                punch.damage = 10;
// ChangeAnimationState(m_Punch);
                m_Animator.SetTrigger("LightAttack");
                Invoke("AttackComplete", lightAttackTime);
//m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim
                break;
            case "heavy":
// Question importante : les Animation events sont ils fiables ? Si non, peut être un simple setActive dans ce script serait plus performant ? 
// Cela retirerait le fait de pouvoir choisir frame par frame si on applique un coup mais serait peut être plus performant ?
                Debug.Log("is attacking heavy");
                m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
                punch.damage = 20;
// ChangeAnimationState(m_Punch);
                m_Animator.SetTrigger("HeavyAttack");
                Invoke("AttackComplete", lightAttackTime);
//m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim
                break;
        }

    }

    // Gestion des animations avec le code
    // Permet de lancer une animation instantannément
    void ChangeAnimationState(string newState)
    {
        if (m_AnimationCurrentState == newState) return; // Cette ligne empêche une animation de se supplenter elle même.

        m_Animator.Play(newState);

        m_AnimationCurrentState = newState;
    }

    void AttackComplete()
    {
        isAttacking = false;
       // ChangeAnimationState(m_Idle);
    }


    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = m_Animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Light":
                    lightAttackTime = clip.length;
                    break;
            }
        }
    }

}


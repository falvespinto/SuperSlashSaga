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
    private bool isRunAttacking;
    private string m_AnimationCurrentState; // l'animation en cours
    public Attack punch;
    // temporaire 
    const string m_Run = "Run";
    const string m_Punch = "Punch";
    const string m_Idle = "Idle";
    public PlayerAttack m_PlayerAttack;
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
    public bool isParing;

    public int runningDirection;

    private AnimationClip clip;


    // Temps d'une animation
    float lightAttackTime;

    [SerializeField] public float m_TranslationSpeed; // Vitesse de déplacement
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();
    }
    void Start()
    {
        isAttacking = false;
        isRunAttacking = false;
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

        if (player.playerIndex == 0)
        {
            runningDirection = 1;
        }
        else
        {
            runningDirection = -1;
        }

    }

    void Update()
    {
        isAttacking = m_PlayerAttack.isAttacking;
        isRunAttacking = m_PlayerAttack.isRunAttacking;
        isParing = m_PlayerAttack.isParing;

        if (isJoyconPluggued)
        {
            Joycon j = m_Joycons[jc_ind];
            if (j.GetButtonDown(Joycon.Button.SHOULDER_2))
            {
                Debug.Log("1");
                // GetStick returns a 2-element vector with x/y joystick components
                Debug.Log(string.Format("Stick x: {0:N} Stick y: {1:N}", j.GetStick()[0], j.GetStick()[1]));

                // Joycon has no magnetometer, so it cannot accurately determine its yaw value. Joycon.Recenter allows the user to reset the yaw value.
                j.Recenter();
            }


            // Gyro values: x, y, z axis values (in radians per second)
            gyroscop = j.GetGyro();

            // Accel values:  x, y, z axis values (in Gs)
            accel = j.GetAccel();

            orientation = j.GetVector();

            if ((accel.z < -1 || accel.z > 1) && !isAttacking)
            {
                isAttacking = true;
                //Attack();
            }

            if (j.GetButtonDown(Joycon.Button.DPAD_RIGHT))
            {
                j.SetRumble(160, 320, 0.6f, 200);
            }

            j = m_Joycons[1];
            m_Rigidbody.velocity = new Vector2(Sign(j.GetStick()[0]) * m_TranslationSpeed, m_Rigidbody.velocity.y); // déplacements horizontaux
            if (Sign(j.GetStick()[0]) != 0)
            {
                //ChangeAnimationState(m_Run);

                isParing = m_PlayerAttack.isParing;


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


            }

            //        }
        }
        if (!isAttacking && !isParing && !player.isTakingDamage)
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
                    if (movementInput.x * runningDirection > 0)
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
}


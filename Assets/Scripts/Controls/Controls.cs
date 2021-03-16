using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    Vector2 i_movement;
    


    private Rigidbody m_Rigidbody;
    private Transform m_Transform;
    private string m_AnimationCurrentState; // l'animation en cours
    public Attack punch;
    public Animator m_Animator;
    public bool isPunching;
    // temporaire 
    const string m_Run = "Run";
    const string m_Punch = "Punch";
    const string m_Idle = "Idle";


    // Variables en rapport avec l'utilisation des JoyCons

    private List<Joycon> m_Joycons;
    public float[] stick;
    public Vector3 gyroscop;
    public Vector3 accel;
    public int jc_ind = 0;
    public Quaternion orientation;
    public bool isJoyconPluggued;

    float moveSpeed = 10f; // Vitesse de déplacement

    [SerializeField]
    private int playerIndex = 0;


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    // Start is called before the first frame update
    void Start()
    {
        isPunching = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Gamepad.current.buttonSouth.wasPressedThisFrame && !isPunching)
        {
            isPunching = true;
            Punch();

        }
    }

    private void Move()
    {


        m_Rigidbody.velocity = new Vector2(i_movement.x * moveSpeed, m_Rigidbody.velocity.y);// déplacements horizontaux
        if (i_movement.x != 0f)
        {
            ChangeAnimationState(m_Run);
        }
        else
        {
            ChangeAnimationState(m_Idle);
        }


    }

    public void OnMove(InputValue value)
    {
        i_movement = value.Get<Vector2>();
    }


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

    private void Punch()
    {
        // Question importante : les Animation events sont ils fiables ? Si non, peut être un simple setActive dans ce script serait plus performant ? 
        // Cela retirerait le fait de pouvoir choisir frame par frame si on applique un coup mais serait peut être plus performant ?
        Debug.Log("is Punching");
        m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
        punch.damage = Random.Range(1, 20);
        ChangeAnimationState(m_Punch);
        Invoke("PunchComplete", 0.7f);
        Debug.Log("Le coup est passé");
        //m_Animator.GetCurrentAnimatorStateInfo(0).length ; recup temps de l'anim
    }

    void ChangeAnimationState(string newState)
    {
        if (m_AnimationCurrentState == newState) return; // Cette ligne empêche une animation de se supplenter elle même.

        m_Animator.Play(newState);

        m_AnimationCurrentState = newState;
    }

    void PunchComplete()
    {
        isPunching = false;
        ChangeAnimationState(m_Idle);
    }

}

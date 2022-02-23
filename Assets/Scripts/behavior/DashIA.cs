using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using UnityEngine.AI;

public class DashIA : Action
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
    public Animator m_animator;
    public PlayerAttackIA playerAttack;
    public float infuseTime = 1.5f;
    public bool isInfusing = false;
    public bool hasTouched = false;
    public bool isEngaging = false;
    public bool isDashingOn = false;
    public IA ia;
    public Collider engageArea;
    public float maxTurnSpeed = 60f;
    public float dashTime = 1f;
    public RangeCollider rangeDash;
    public IADash iaDash;
    public bool hasDashed;
    public float timeElapsed;
    public override void OnStart()
    {
        timeElapsed = 0;
        m_animator.SetBool("isDashing", true);
        hasTouched = false;
    }
    public override TaskStatus OnUpdate()
    {

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
                //engageArea.gameObject.SetActive(false);
                break;
            }
        }

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (ia.manaBar.mana <= 25)
        {
            ia.manaBar.SetMana(ia.manaBar.mana - 25);
            isDashing = true;
            if (!hasTouched && timeElapsed < 1f)
            {
                Vector3 directionToTarget = playerAttack.playerData.target.position - (transform.position);
                Vector3 currentDirection = transform.forward;
                Vector3 resultingDirection = Vector3.RotateTowards(currentDirection, directionToTarget.normalized, maxTurnSpeed * Mathf.Deg2Rad * Time.deltaTime, 1f);
                transform.rotation = Quaternion.LookRotation(resultingDirection);
                agent.Move(transform.forward * dashSpeed * Time.deltaTime);
                timeElapsed += Time.deltaTime;
                return TaskStatus.Running;
            }
            else
            {
                m_animator.SetBool("isDashing", false);
                return TaskStatus.Success;
            }
        }
        else
        {
            return TaskStatus.Failure;
        }

    }

}


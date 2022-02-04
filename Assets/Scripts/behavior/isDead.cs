using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class isDead : Conditional
{
    public Player playerhealth;

    public override void OnStart()
    {
        playerhealth = GameObject.Find("Player1").GetComponentInChildren<Player>();

    }
    public override TaskStatus OnUpdate()
    {
        if (playerhealth.currentHealth > 0)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }

}

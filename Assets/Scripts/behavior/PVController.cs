using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class PVController : Conditional
{
    public Player playerhealth;

    public override void OnStart()
    {
        playerhealth = GetComponent<Player>();

    }
    public override TaskStatus OnUpdate()
    {
        if (playerhealth.currentHealth <= 35)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        };
    }

}

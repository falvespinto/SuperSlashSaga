using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class isInCombo : Conditional
{
    public LightAttackIA ia;
    public bool isInComboBehavior;

    public override void OnStart()
    {
        isInComboBehavior = ia.isInCombo;
    }
    public override TaskStatus OnUpdate()
    {
        if (ia.isInCombo)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        };
    }

}

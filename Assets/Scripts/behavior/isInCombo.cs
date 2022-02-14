using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class isInCombo : Conditional
{
    public IA ia;
    public bool isInComboBehavior;

    public override void OnStart()
    {

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

using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IsOnRangeDash : Action
{
    public bool bIsInRange;
    public RangeCollider rangeCollider;
    // Start is called before the first frame update
    public override void OnStart()
    {
        bIsInRange = rangeCollider.bIsInRange;
    }

    // Update is called once per frame
    public override TaskStatus OnUpdate()
    {
        if (!bIsInRange)
            return TaskStatus.Success;
        else
        {
            return TaskStatus.Failure;
        }
    }
}

using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class IAInit : Conditional
// Start is called before the first frame update
{
    public SharedTransform target;
    public string targetTag;

    public override TaskStatus OnUpdate()
    {
        var targetTrans = GameObject.FindGameObjectWithTag(targetTag).transform;
        target.Value = targetTrans;
        if (target.Value != null)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        };
    }

}

using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class HasAttacked : Action
{
    // Start is called before the first frame update
    public RandomAttack randomAttack;
    public override void OnStart()
    {

    }
    public override TaskStatus OnUpdate()
    {
        if (randomAttack.NbAttacks == 0)
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}

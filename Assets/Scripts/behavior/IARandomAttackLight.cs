using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IARandomAttackLight : Action
{
    public float randomAttackLight = Random.Range(0, 100);
    public RandomAttack randomAttack;
    public override void OnStart()
    {

    }
    public override TaskStatus OnUpdate()
    {
        if (randomAttackLight < randomAttack.percentAttacks["Light"])
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}

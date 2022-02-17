using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IARandomAttackHeavy : Action
{
    public float randomAttackHeavy = Random.Range(0, 100);
    public RandomAttack percentHeavy;
    public override void OnStart()
    {

    }
    public override TaskStatus OnUpdate()
    {
        if (randomAttackHeavy < percentHeavy.CalculatePercentHeavy())
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}

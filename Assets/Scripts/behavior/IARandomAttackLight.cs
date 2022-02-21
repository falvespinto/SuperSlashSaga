using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IARandomAttackLight : Action
{
    public float randomAttackLight;
    public RandomAttack percentHeavy;
    public override void OnStart()
    {

    }
    public override TaskStatus OnUpdate()
    {
        randomAttackLight = Random.Range(0, 100);
        if (randomAttackLight < percentHeavy.CalculatePercentHeavy())
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}

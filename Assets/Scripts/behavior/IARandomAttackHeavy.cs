using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IARandomAttackHeavy : Action
{
    public float randomAttackHeavy;
    public RandomAttack percentParade;
    public override void OnStart()
    {

    }
    public override TaskStatus OnUpdate()
    {
        randomAttackHeavy = Random.Range(0, 100);
        if (randomAttackHeavy < percentParade.CalculatePercentParade())
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}

using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IARandomParade : Action
{
    public float randomParade = Random.Range(0, 100);
    public RandomAttack percentParade;
    public override void OnStart()
    {

    }
    public override TaskStatus OnUpdate()
    {
        if (randomParade < percentParade.CalculatePercentParade())
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}

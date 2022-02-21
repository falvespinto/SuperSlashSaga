using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IARandomParade : Action
{
    public float randomParade;
    public RandomAttack percentLight;
    public override void OnStart()
    {

    }
    public override TaskStatus OnUpdate()
    {
        randomParade = Random.Range(0, 100);
        if (randomParade < percentLight.CalculatePercentLight())
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}

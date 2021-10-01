using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IAHeavy : Action
{

    private GameObject prevGameObject;
    public SharedGameObject targetGameObject;
    public HeavyAttackIA heavyAttackIA;
    public override void OnStart()
    {
        var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
        if (currentGameObject != prevGameObject)
        {
            heavyAttackIA = currentGameObject.GetComponent<HeavyAttackIA>();
            prevGameObject = currentGameObject;
        }
    }
    public override TaskStatus OnUpdate()
    {
        if (heavyAttackIA == null)
        {
            Debug.LogWarning("Animator is null");
            return TaskStatus.Failure;
        }

        heavyAttackIA.PerformedHeavyAttack("normal");

        return TaskStatus.Success;
    }

    public override void OnReset()
    {
        targetGameObject = null;
    }


}

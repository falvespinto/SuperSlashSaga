using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IALight : Action
{

    private GameObject prevGameObject;
    public SharedGameObject targetGameObject;
    public LightAttackIA lightAttackIA;
    public override void OnStart()
    {
        var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
        if (currentGameObject != prevGameObject)
        {
            lightAttackIA = currentGameObject.GetComponent<LightAttackIA>();
            prevGameObject = currentGameObject;
        }
    }
    public override TaskStatus OnUpdate()
    {
        if (lightAttackIA == null)
        {
            Debug.LogWarning("Animator is null");
            return TaskStatus.Failure;
        }

        lightAttackIA.PerformedLightAttack("normal");

        return TaskStatus.Success;
    }

    public override void OnReset()
    {
        targetGameObject = null;
    }


}

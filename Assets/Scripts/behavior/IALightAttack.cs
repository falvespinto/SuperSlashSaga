using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IALight : Action
{

    private GameObject prevGameObject;
    public SharedGameObject targetGameObject;
    public LightAttack lightAttack;
    public override void OnStart()
    {
        var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
        if (currentGameObject != prevGameObject)
        {
            lightAttack = currentGameObject.GetComponent<LightAttack>();
            prevGameObject = currentGameObject;
        }
    }
    public override TaskStatus OnUpdate()
    {
        if (lightAttack == null)
        {
            Debug.LogWarning("Animator is null");
            return TaskStatus.Failure;
        }

        lightAttack.PerformedLightAttack("normal");

        return TaskStatus.Success;
    }

    public override void OnReset()
    {
        targetGameObject = null;
    }


}

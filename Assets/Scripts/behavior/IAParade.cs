using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IAParade : Action
{

    private GameObject prevGameObject;
    public SharedGameObject targetGameObject;
    public ParadeIA paradeIA;
    public SharedBool isParing;
    public override void OnStart()
    {
        var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
        if (currentGameObject != prevGameObject)
        {
            paradeIA = currentGameObject.GetComponent<ParadeIA>();
            prevGameObject = currentGameObject;
        }
    }
    public override TaskStatus OnUpdate()
    {
        if (paradeIA == null)
        {
            Debug.LogWarning("Animator is null");
            return TaskStatus.Failure;
        }
        if (isParing.Value)
        {
            paradeIA.InitializedParadeAttack();
        }
        else
        {
            paradeIA.FinalizedParadeAttack();
        }

        return TaskStatus.Success;
    }

    public override void OnReset()
    {
        targetGameObject = null;
    }


}

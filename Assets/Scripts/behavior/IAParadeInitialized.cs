using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IAParadeInitialized : Action
{

    private GameObject prevGameObject;
    public SharedGameObject targetGameObject;
    public ParadeIA paradeIA;
    public SharedBool isParing;
    public LightAttackIA lightAttackIA;
    public PlayerAudioManager playerAudio;
    public IA ia;
    public RangePermute rangeLightAttack;
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
        if (!lightAttackIA.playerAttackIA.isAttacking && !ia.isInCombo && rangeLightAttack.bIsInRange && !ia.isTakingDamage && isParing.Value)
        {
            IALight.dashFirst = false;
            paradeIA.InitializedParadeAttack();
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }

    }

    public override void OnReset()
    {
        targetGameObject = null;
    }


}

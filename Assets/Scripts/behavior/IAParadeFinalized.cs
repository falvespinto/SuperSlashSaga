using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IAParadeFinalized : Action
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
        if (!lightAttackIA.playerAttackIA.isAttacking && !ia.isInCombo && !ia.isTakingDamage && !isParing.Value)
        {
            paradeIA.FinalizedParadeAttack();
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

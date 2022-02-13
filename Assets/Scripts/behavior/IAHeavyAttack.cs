using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IAHeavy : Action
{

    private GameObject prevGameObject;
    public SharedGameObject targetGameObject;
    public PlayerAudioManager playerAudio;
    public HeavyAttackIA heavyAttackIA;
    public RangePermute rangeHeavyAttack;
    public IA ia;
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
        if(!heavyAttackIA.playerAttackIA.isAttacking && !ia.isInCombo && rangeHeavyAttack.bIsInRange && !ia.isTakingDamage)
        {
            heavyAttackIA.PerformedHeavyAttack("normal");
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

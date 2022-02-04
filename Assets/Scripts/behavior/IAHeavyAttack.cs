using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IAHeavy : Action
{

    private GameObject prevGameObject;
    public SharedGameObject targetGameObject;
    public PlayerAudioManager playerAudio;
    public HeavyAttackIA heavyAttackIA;
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
        if (ia.isTakingDamage)
        {
            Debug.LogWarning("Animator is null");
            return TaskStatus.Failure;
        }
        if(!heavyAttackIA.playerAttackIA.isAttacking && !ia.isInCombo){
            heavyAttackIA.PerformedHeavyAttack("normal");
            //playerAudio.playSoundLourdMiss();
        }


        return TaskStatus.Success;
    }

    public override void OnReset()
    {
        targetGameObject = null;
    }


}

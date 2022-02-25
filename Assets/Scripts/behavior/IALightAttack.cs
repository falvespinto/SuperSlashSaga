using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;


public class IALight : Action
{

    private GameObject prevGameObject;
    public SharedGameObject targetGameObject;
    public LightAttackIA lightAttackIA;
    public PlayerAudioManager playerAudio;
    public IA ia;
    public RangePermute rangeLightAttack;
    public static bool dashFirst = true;
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
        if (!lightAttackIA.playerAttackIA.isAttacking && !ia.isInCombo && rangeLightAttack.bIsInRange && !ia.isTakingDamage && !dashFirst)
        {

            lightAttackIA.PerformedLightAttack("normal");
            Debug.Log(lightAttackIA.playerAttackIA.playerHit);
            //playerAudio.playSoundLeger();
            return TaskStatus.Success;
        }
        else
        {
            lightAttackIA.ResetComboState();
            return TaskStatus.Failure;
        }



    }

    public override void OnReset()
    {
        targetGameObject = null;
    }


}

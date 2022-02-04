using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
public class PermuteBad : Action
{
    public IA iaHealth;
    public PlayerData playerData;
    public PermutationIA permutationIA;
    public override void OnStart()
    {
        iaHealth = GetComponent<IA>();
        playerData = permutationIA.playerData;
        permutationIA = GetComponent<PermutationIA>();
    }
    public override TaskStatus OnUpdate()
    {

        if (playerData.permutationBar.remainingPermutation >= 1 && iaHealth.canPermute && !iaHealth.isInCombo)
        {
                permutationIA.Permute();
                return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}

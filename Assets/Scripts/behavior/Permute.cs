using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
public class Permute : Action
{
    public IA iaHealth;
    public int randNum = UnityEngine.Random.Range(0, 1);
    public PlayerData playerData;
    public bool canPermute;
    public PermutationIA permutationIA;
    public override void OnStart()
    {
        iaHealth = GetComponent<IA>();
        playerData = GetComponent<PlayerData>();
        permutationIA = GetComponent<PermutationIA>();
    }
    public override TaskStatus OnUpdate()
    {

        if (iaHealth.currentHealth >= 35 && playerData.permutationBar.remainingPermutation >= 1 && (iaHealth.canPermute && canPermute && !iaHealth.isInCombo))
        {
                permutationIA.Permute();
                return TaskStatus.Success;
        }
        else if(iaHealth.currentHealth<35 && (playerData.permutationBar.remainingPermutation >= 1))
        {
                permutationIA.Permute();
                return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
        return TaskStatus.Failure;
    }
}

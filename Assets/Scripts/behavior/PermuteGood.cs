using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
public class PermuteGood : Action
{
    public IA iaHealth;
    public PermutationIA permutationIA;
    public PlayerAttackIA playerAttackIA;
    public RangePermute rangePermute;
    public PlayerData playerData;
    public PlayerAttack playerAttack;
    public override void OnStart()
    {
        iaHealth = GetComponent<IA>();
        permutationIA = GetComponent<PermutationIA>();
        playerAttackIA = GetComponent<PlayerAttackIA>();
        playerData = GameObject.Find("Player1").GetComponent<PlayerData>();
        playerAttack = playerData.GetComponentInChildren<PlayerAttack>();

    }
    public override TaskStatus OnUpdate()
    {

        if (permutationIA.playerData.permutationBar.remainingPermutation >= 1 && !iaHealth.isInCombo && rangePermute.bIsInRange && playerAttack.isAttacking)
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

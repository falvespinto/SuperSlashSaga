using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;

public class IAManaRange : Conditional
{
    private bool isInRange;
    public RangeCollider range;
    private PlayerData playerData;
    private ManaBar manabar;
    public IA ia;
    public override void OnStart()
    {
        isInRange = range.bIsInRange;
        playerData = ia.playerData;
        manabar = playerData.manabar;
        Debug.Log(manabar);
    }
    public override TaskStatus OnUpdate()
    {
        if (!isInRange && manabar.mana < 50)
        {
            manabar.SetMana(manabar.mana + 1);
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        };
    }
}

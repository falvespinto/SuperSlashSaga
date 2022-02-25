using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class isDead : Conditional
{
    public Player player;
    public IA ia;
    public override void OnStart()
    {
        player = GameObject.Find("Player1").GetComponentInChildren<Player>();

    }
    public override TaskStatus OnUpdate()
    {
        if (player.currentHealth > 0 && ia.currentHealth > 0)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }

}

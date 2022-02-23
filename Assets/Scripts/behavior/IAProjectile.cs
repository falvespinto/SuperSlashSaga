using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class IAProjectile : Action
{
    // Start is called before the first frame update
    public ProjectileIA projectileIA;
    public override TaskStatus OnUpdate()
    {
        projectileIA.PrepareFire();
        return TaskStatus.Success;
    }
}

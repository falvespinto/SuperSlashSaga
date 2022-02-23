using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
public class RandomIA : Action
{
    public int randNum;
    public int chance;
    public override TaskStatus OnUpdate()
    {
        randNum = UnityEngine.Random.Range(0, 100);
        if (randNum <= chance)
        {
           return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    [TaskDescription("Seek the target specified using the Unity NavMesh.")]
    [TaskCategory("Movement")]
    [HelpURL("https://www.opsive.com/support/documentation/behavior-designer-movement-pack/")]
    [TaskIcon("Assets/Behavior Designer Movement/Editor/Icons/{SkinColor}SeekIcon.png")]
    public class Seek : NavMeshMovement
    {
        [Tooltip("The GameObject that the agent is seeking")]
        public SharedGameObject target;
        [Tooltip("If target is null then use the target position")]
        public SharedVector3 targetPosition;
        public string targetTag;
        public RangeCollider rangeCollider;
        public bool bIsInRange;
        public override void OnAwake()
        {

        }
        public override void OnStart()
        {
            target.Value = GameObject.FindGameObjectWithTag(targetTag);
            base.OnStart();
            SetDestination(Target());

        }

        // Seek the destination. Return success once the agent has reached the destination.
        // Return running if the agent hasn't reached the destination yet
        public override TaskStatus OnUpdate()
        {
            bIsInRange = rangeCollider.bIsInRange;
            if (HasArrived())
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Failure;

            SetDestination(Target());
            return TaskStatus.Running;




        }

        // Return targetPosition if target is null
        private Vector3 Target()
        {
            return GameObject.FindGameObjectWithTag(targetTag).transform.position;
        }

        public override void OnReset()
        {
            base.OnReset();
            target = null;
            targetPosition = Vector3.zero;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetLock : MonoBehaviour
{
    public Transform follow;
    public Transform target;
    public int yOffSet;
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        dir.Normalize();
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);

    }
    private void LateUpdate()
    {
        transform.position = new Vector3(follow.position.x, follow.position.y + yOffSet, follow.position.z);
    }
}

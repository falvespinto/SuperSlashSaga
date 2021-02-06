using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // METHODE 1
    public Transform[] playerTransform;
    [SerializeField] float minDistance;
    [SerializeField] float yOffset;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    private float xMiddle;
    private float yMiddle;
    private float distance;
    void LateUpdate()
    {
        if (playerTransform.Length == 0)
        {
            Debug.Log("Pas de joueurs trouvés, fait gaffe au tag");
            return;
        }
        xMin = xMax = playerTransform[0].position.x;
        yMin = yMax = playerTransform[0].position.y;
        for (int i = 1; i < playerTransform.Length; i++)
        {
            if (playerTransform[i].position.x < xMin)
                xMin = playerTransform[i].position.x;
            if (playerTransform[i].position.x > xMax)
                xMax = playerTransform[i].position.x;
            if (playerTransform[i].position.y < yMin)
                yMin = playerTransform[i].position.y;
            if (playerTransform[i].position.y > yMax)
                yMax = playerTransform[i].position.y;
        }
        xMiddle = (xMin + xMax) / 2;
        yMiddle = (yMin + yMax) / 2;
        distance = xMax - xMin;
        if (distance < minDistance)
            distance = minDistance;
        transform.position = new Vector3(xMiddle, yMiddle + yOffset, -distance);

    }

    //public Transform leftTarget;
    //public Transform rightTarget;
    //public float minDistance;
    //private void Update()
    //{
    //    float distanceBetweentargets = Mathf.Abs(leftTarget.position.x - rightTarget.position.x) * 2;
    //    float centerPosition = (leftTarget.position.x + rightTarget.position.x) / 2;
    //    transform.position = new Vector3(centerPosition, transform.position.y, distanceBetweentargets > minDistance ? -distanceBetweentargets : -minDistance);
    //}
}

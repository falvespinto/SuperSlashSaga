using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultiTargetCamera : MonoBehaviour
{
    public Transform[] playersTransforms;
    public Vector3 offset;
    private Vector3 velocity;
    public float smoothTime = .5f;
    private GameObject[] allPlayers;
    private Camera cam;
    public Vector3 test;
    public Vector3 planarDirection;
    private float targetVerticalAngle;
    public Quaternion targetRotation;
    public float minZoom = -240f;
    public float maxZoom = -215f;
    public float zoomLimiter = 5f;

    public float rotationSharpness = 25f;
    public float defaultVerticalAngle = 20f;
    [Range(-90, 90)] public float minVerticalAngle = -90;
    [Range(-90, 90)] public float maxVerticalAngle = 90;


    public float maxRangeBeforeSwitch;

    //private float xMin, xMax, yMin, yMax;




    private void Start()
    {
        cam = GetComponent<Camera>();
        playersTransforms = getAllPlayersTransforms(playersTransforms);
    }

    private void Update()
    {
        if (playersTransforms.Length != 2)
        {
            playersTransforms = getAllPlayersTransforms(playersTransforms);
        }
    }

    private void LateUpdate()
    {

        if (playersTransforms.Length == 0)
        {
            return;
        }
        Move();
        //xMin = xMax = playersTransforms[0].position.x;
        //yMin = yMax = playersTransforms[0].position.y;
        //for (int i = 1; i < playersTransforms.Length; i++)
        //{
        //    if (playersTransforms[i].position.x < xMin)
        //    {
        //        xMin = playersTransforms[i].position.x;
        //    }
        //    if (playersTransforms[i].position.x > xMax)
        //    {
        //        xMax = playersTransforms[i].position.x;
        //    }
        //    if (playersTransforms[i].position.y < yMin)
        //    {
        //        yMin = playersTransforms[i].position.y;
        //    }
        //    if (playersTransforms[i].position.y < yMax)
        //    {
        //        xMin = playersTransforms[i].position.y;
        //    }

        //    float xMiddle = (xMin + xMax) / 2;
        //    float yMiddle = (yMin + yMax) / 2;
        //    float distance = xMax - xMin;
        //    if (distance < minDistance)
        //    {
        //        distance = minDistance;
        //    }

            //transform.position = new Vector3(xMiddle, yMiddle + yOffset, -distance);
        //Move();
        
    }

    void Zoom()
    {
        //float newZoom = Mathf.Lerp(maxZoom, minZoom,  / zoomLimiter)
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;


        Vector3 camToTarget = centerPoint - cam.transform.position;
        Vector3 planarCamToTarget = Vector3.ProjectOnPlane(camToTarget, Vector3.up);
        Quaternion lookRotation = Quaternion.LookRotation(camToTarget, Vector3.up);

        planarDirection = planarCamToTarget != Vector3.zero ? planarCamToTarget.normalized : planarDirection;
        targetVerticalAngle = Mathf.Clamp(lookRotation.eulerAngles.x, minVerticalAngle, maxVerticalAngle);


        targetRotation = Quaternion.LookRotation(planarDirection); //* Quaternion.Euler(targetVerticalAngle,0,0);

        Quaternion newRotation = Quaternion.Slerp(cam.transform.rotation, targetRotation, Time.deltaTime * rotationSharpness);
        cam.transform.rotation = newRotation;
        float newZ = newPosition.z - GetGreatestDistance();
        if (newZ > maxZoom)
        {
            newZ = maxZoom;
        }
        else if (newZ < minZoom)
        {
            newZ = minZoom;
        }

        test = new Vector3(newPosition.x, newPosition.y, newZ + zoomLimiter);

        transform.position = Vector3.SmoothDamp(transform.position, test, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(playersTransforms[0].position, Vector3.zero);
        for (int i = 0; i < playersTransforms.Length; i++)
        {
            bounds.Encapsulate(playersTransforms[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (playersTransforms.Length == 1)
        {
            return playersTransforms[0].position;
        }

        var bounds = new Bounds(playersTransforms[0].position, Vector3.zero);
        for (int i = 0; i < playersTransforms.Length; i++)
        {
            bounds.Encapsulate(playersTransforms[i].position);
        }
        return bounds.center;
    }
    Transform[] getAllPlayersTransforms(Transform[] players)
    {
        allPlayers = GameObject.FindGameObjectsWithTag("Player");
        players = new Transform[allPlayers.Length];
        for (int i = 0; i < allPlayers.Length; i++)
        {
            players[i] = allPlayers[i].transform;
        }
        return players;
    }
}

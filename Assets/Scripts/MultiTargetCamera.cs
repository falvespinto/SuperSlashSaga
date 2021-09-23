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
    public Vector3 finalPosition;
    public Vector3 planarDirection;
    private float targetVerticalAngle;
    public Quaternion targetRotation;
    public float minZoom = -240f;
    public float maxZoom = -215f;
    public float zoomLimiter = 5f;

    public float defualtHorizontalAngleFree = 45f;

    public float fixedDistanceToPlayer = 50f;
    public float fixedDistanceToPlayerFree = 50f;
    public float maxDistanceBeforeSwap = 500f;

    public float rotationSharpness = 25f;
    public float defaultVerticalAngle = 20f;
    [Range(-90, 90)] public float verticalAngle = 1;


    public float maxRangeBeforeSwitch;

    //private float xMin, xMax, yMin, yMax;




    private void Start()
    {
        cam = GetComponent<Camera>();
        playersTransforms = GetAllPlayersTransforms(playersTransforms);
    }

    private void Update()
    {
        if (playersTransforms.Length != 2)
        {
            playersTransforms = GetAllPlayersTransforms(playersTransforms);
        }
    }

    private void LateUpdate()
    {
        GetAngleCam();
        if (playersTransforms.Length == 0)
        {
            return;
        }
        Move();
        
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


        targetRotation = Quaternion.LookRotation(planarDirection) * Quaternion.Euler(verticalAngle,0,0);

        Quaternion newRotation = Quaternion.Slerp(cam.transform.rotation, targetRotation, Time.deltaTime * rotationSharpness);
        cam.transform.rotation = newRotation;

        //float newZ = newPosition.z - GetGreatestDistance();
        //if (newZ > maxZoom)
        //{
        //    newZ = maxZoom;
        //}
        //else if (newZ < minZoom)
        //{
        //    newZ = minZoom;
        //




        if (GetGreatestDistance() >= maxDistanceBeforeSwap)
        {
            finalPosition = new Vector3(GetClosestPlayerToCamera().x + fixedDistanceToPlayerFree, newPosition.y, GetClosestPlayerToCamera().z - fixedDistanceToPlayer);
        }
        else
        {
            finalPosition = new Vector3(newPosition.x, newPosition.y, GetClosestPlayerToCamera().z - fixedDistanceToPlayer);
        }
        Vector3 direction = (GetClosestPlayerToCamera() - GetFarthestPlayer()).normalized;
        GetAngleBehingClosest(GetClosestPlayerToCamera() + direction*10);
        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref velocity, smoothTime);
        
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
    Transform[] GetAllPlayersTransforms(Transform[] players)
    {
        allPlayers = GameObject.FindGameObjectsWithTag("Player");
        players = new Transform[allPlayers.Length];
        for (int i = 0; i < allPlayers.Length; i++)
        {
            players[i] = allPlayers[i].transform;
        }
        return players;
    }

    Vector3 GetClosestPlayerToCamera()
    {
        Transform closestPlayer = null;
        //var bounds = new Bounds();
        float closestDistance = 99999999999;
        //if (playersTransforms.Length == 1)
        //{
        //    return playersTransforms[0].position;
        //}
        //for (int i = 0; i < playersTransforms.Length; i++)
        //{
        //   bounds = new Bounds(playersTransforms[i].position, Vector3.zero);
        //   bounds.Encapsulate(gameObject.transform.position);
        //    Debug.Log(bounds.size.x);
        //    if (bounds.size.x <= closestDistance)
        //    {
        //        closestDistance = bounds.size.x;
        //        closestPlayer = playersTransforms[i];
        //    }
        //}

        for (int i = 0; i < playersTransforms.Length; i++)
        {
            float distance = Vector3.Distance(playersTransforms[i].position,cam.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = playersTransforms[i];
            }
        }

        return closestPlayer.position;

    }

    Vector3 GetFarthestPlayer()
    {
        Transform farthestPlayer = null;
        float farthestDistance = 0;

        for (int i = 0; i < playersTransforms.Length; i++)
        {
            float distance = Vector3.Distance(playersTransforms[i].position, cam.transform.position);
            if (distance > farthestDistance)
            {
                farthestDistance = distance;
                farthestPlayer = playersTransforms[i];
            }
        }

        return farthestPlayer.position;
    }

    Vector3 GetAngleCam()
    {
        Vector3 direction = (playersTransforms[0].position - playersTransforms[1].position).normalized;
        Debug.DrawLine(GetCenterPoint(), GetCenterPoint() + direction * 100, Color.red,0.1f);
        Quaternion spreadAngle = Quaternion.AngleAxis(-15, new Vector3(0, 1, 0));
        Vector3 newDirection = spreadAngle * direction;
        Debug.DrawLine(GetCenterPoint(), GetCenterPoint() + newDirection * 100, Color.red, 0.1f);
        return newDirection;
    }

    Vector3 GetAngleBehingClosest(Vector3 pos)
    {
        Vector3 direction = (GetClosestPlayerToCamera() - GetFarthestPlayer()).normalized;
        Vector3 perp = Vector3.Cross(direction, Vector3.up).normalized;
        Debug.DrawLine(pos, pos + perp * 100, Color.blue, 0.1f);
        //Debug.DrawLine(pos, pos + Vector3.up.normalized * 100, Color.blue, 0.1f);
        //Debug.DrawLine(pos, pos + Vector3.right.normalized * 100, Color.black, 0.1f);
        //Debug.DrawLine(pos, pos + Vector3.down.normalized * 100, Color.green, 0.1f);
        //Debug.DrawLine(pos, pos + Vector3.left.normalized * 100, Color.magenta, 0.1f);
        return new Vector3();

    }
    //void 
}

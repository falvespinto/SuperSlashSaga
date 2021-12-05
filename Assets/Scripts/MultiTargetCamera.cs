using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultiTargetCamera : MonoBehaviour
{
    public List<Transform> playersTransforms;
    public Vector3 offset;
    public Vector3 camPositionOffSet;
    private Vector3 velocity;
    public float shortSmoothTime = .5f;
    public float longSmoothTime = 5f;
    private GameObject[] allPlayers;
    private Camera cam;
    public Vector3 finalPosition;
    public Vector3 planarDirection;
    private float targetVerticalAngle;
    public Quaternion targetRotation;
    public float minZoom = -240f;
    public float maxZoom = -215f;
    public float zoomLimiter = 5f;
    private string camState;
    public float smoothTime;

    public float angleOffSet = 15f;
    public float distanceBehindLockOffSet = 10f;

    public float defualtHorizontalAngleFree = 45f;

    public float fixedDistanceToPlayer = 50f;
    public float fixedDistanceToPlayerFree = 50f;
    public float maxDistanceBeforeSwap = 500f;

    public float rotationSharpness = 25f;
    public float defaultVerticalAngle = 20f;
    [Range(-90, 90)] public float verticalAngle = 1;


    public float maxRangeBeforeSwitch;

    private const string LONG_DISTANCE = "longue distance";
    private const string SHORT_DISTANCE = "courte distance";

    //private float xMin, xMax, yMin, yMax;




    private void Start()
    {
        cam = GetComponent<Camera>();
        playersTransforms = GetAllPlayersTransforms(playersTransforms);
    }

    private void Update()
    {
        if (playersTransforms.Count != 2)
        {
            playersTransforms = GetAllPlayersTransforms(playersTransforms);
        }
    }

    private void LateUpdate()
    {
        if (playersTransforms.Count == 0)
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


        //Debug.Log(GetGreatestDistance());

        if (GetGreatestDistance() >= maxDistanceBeforeSwap)
        {
            if (camState == LONG_DISTANCE)
            {
                smoothTime = shortSmoothTime;
            }
            else
            {
                smoothTime = longSmoothTime;
            }
            finalPosition = GetCamPos();// new Vector3(GetClosestPlayerToCamera().x + fixedDistanceToPlayerFree, newPosition.y, GetClosestPlayerToCamera().z - fixedDistanceToPlayer);
            camState = LONG_DISTANCE;
        }
        else
        {
            if (camState == SHORT_DISTANCE)
            {
                smoothTime = shortSmoothTime;
            }
            else
            {
                smoothTime = longSmoothTime;
            }
            finalPosition = new Vector3(newPosition.x, newPosition.y, GetClosestPlayerToCamera().z - fixedDistanceToPlayer);
            camState = SHORT_DISTANCE;
        }
        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        //var bounds = new Bounds(playersTransforms[0].position, Vector3.zero);
        //for (int i = 0; i < playersTransforms.Length; i++)
        //{
        //    bounds.Encapsulate(playersTransforms[i].position);
        //}

        return Vector3.Distance(playersTransforms[0].position, playersTransforms[1].position);
    }

    Vector3 GetCenterPoint()
    {
        if (playersTransforms.Count == 1)
        {
            return playersTransforms[0].position;
        }

        var bounds = new Bounds(playersTransforms[0].position, Vector3.zero);
        for (int i = 0; i < playersTransforms.Count; i++)
        {
            bounds.Encapsulate(playersTransforms[i].position);
        }
        return bounds.center;
    }
    List<Transform> GetAllPlayersTransforms(List<Transform> players)
    {
        allPlayers = GameObject.FindGameObjectsWithTag("Player");
        players = new List<Transform>();
        for (int i = 0; i < allPlayers.Length; i++)
        {
            players.Add(allPlayers[i].transform);
        }
        if (players.Count == 1)
        {
            players.Add(GameObject.FindGameObjectWithTag("IA").transform);
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

        for (int i = 0; i < playersTransforms.Count; i++)
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

        for (int i = 0; i < playersTransforms.Count; i++)
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

    Vector3 GetCamPos()
    {
        Vector3 direcBehind = (GetClosestPlayerToCamera() - GetFarthestPlayer()).normalized;
        Vector3 positionBehind = GetClosestPlayerToCamera() + direcBehind * distanceBehindLockOffSet;
        Debug.DrawLine(GetCenterPoint(), GetCenterPoint() + direcBehind * 100, Color.red,0.1f);
        Quaternion spreadAngleRight = Quaternion.AngleAxis(-angleOffSet, new Vector3(0, 1, 0));
        Quaternion spreadAngleLeft = Quaternion.AngleAxis(angleOffSet, new Vector3(0, 1, 0));
        Vector3 newDirectionBehindRight = spreadAngleRight * direcBehind;
        Vector3 newDirectionBehindLeft =  spreadAngleLeft * direcBehind;
        Debug.DrawLine(GetCenterPoint(), GetCenterPoint() + newDirectionBehindRight * 100, Color.red, 0.1f);
        Debug.DrawLine(GetCenterPoint(), GetCenterPoint() + newDirectionBehindLeft * 100, Color.cyan, 0.1f);

        Vector3 perpDirection = Vector3.Cross(direcBehind, Vector3.up).normalized;
        Debug.DrawLine(positionBehind, positionBehind + perpDirection * 100, Color.blue, 0.1f);
        Debug.DrawLine(positionBehind, positionBehind - perpDirection * 100, Color.green, 0.1f);
        Vector3 intersectionPointRight = new Vector3();
        Vector3 intersectionPointLeft = new Vector3();

        LineLineIntersection(out intersectionPointRight, GetCenterPoint(), newDirectionBehindRight, positionBehind, perpDirection);
        LineLineIntersection(out intersectionPointLeft, GetCenterPoint(), newDirectionBehindLeft, positionBehind, -perpDirection);

        intersectionPointRight += camPositionOffSet;
        intersectionPointLeft += camPositionOffSet;

        float distanceRight = Vector3.Distance(cam.transform.position, intersectionPointRight);
        float distanceLeft = Vector3.Distance(cam.transform.position, intersectionPointLeft);

        if (Vector3.Distance(cam.transform.position, intersectionPointRight) < Vector3.Distance(cam.transform.position, intersectionPointLeft))
        {
            return intersectionPointRight;
        }
        else
        {
            return intersectionPointLeft;
        }
    }

    Vector3 GetAngleBehingClosest(Vector3 pos)
    {
        Vector3 direction = (GetClosestPlayerToCamera() - GetFarthestPlayer()).normalized;
        Vector3 perpDirection = Vector3.Cross(direction, Vector3.up).normalized;
        
        //Debug.DrawLine(pos, pos + Vector3.up.normalized * 100, Color.blue, 0.1f);
        //Debug.DrawLine(pos, pos + Vector3.right.normalized * 100, Color.black, 0.1f);
        //Debug.DrawLine(pos, pos + Vector3.down.normalized * 100, Color.green, 0.1f);
        //Debug.DrawLine(pos, pos + Vector3.left.normalized * 100, Color.magenta, 0.1f);
        return new Vector3();

    }


    bool LineLineIntersection(out Vector3 intersection,Vector3 point1, Vector3 direction1, Vector3 point2, Vector3 direction2)
    {
        Vector3 direction3 = point2 - point1;
        Vector3 crossVec1and2 = Vector3.Cross(direction1, direction2);
        Vector3 crossVec3and2 = Vector3.Cross(direction3, direction2);

        float planarFactor = Vector3.Dot(direction3, crossVec1and2);

        if (Mathf.Abs(planarFactor) < 1f && crossVec1and2.sqrMagnitude > 0.0001f)
        {
            float s = Vector3.Dot(crossVec3and2, crossVec1and2) / crossVec1and2.sqrMagnitude;
            intersection = point1 + (direction1 * s);
            return true;
        }
        else
        {
            intersection = Vector3.zero;
            return false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Threading.Tasks;
public class EmoteHandler : MonoBehaviour
{
    public Vector3 lerpOffSet;
    public RawImage thisRawImage;
    public float lerpTime = 300f;
    private float _timer = 0f;
    public AnimationCurve lerpCurve;
    public Transform targetA;
    public Transform targetB;

    public void Awake()
    {
        targetA = GameObject.Find("EmoteSpawner").transform;
        targetB = GameObject.Find("EmoteTarget").transform;
    }

    public void Start()
    {
        StartCoroutine(DestroyTimer());
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > lerpTime)
        {
            _timer = lerpTime;
        }
        float lerpRatio = _timer / lerpTime;

        Vector3 positionOffSet = lerpCurve.Evaluate(lerpRatio) * lerpOffSet;

        transform.position = Vector3.Lerp(targetA.position, targetB.position, lerpRatio) + positionOffSet;
    }

    public IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}

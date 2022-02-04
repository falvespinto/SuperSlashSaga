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
    public Transform targetA;
    public Transform targetB;
    private float frequence = 15f;
    private float magnitude = 10f;
    private float speed = 400f;
    private float lifeTime = 2.1f;
    private float startY;
    public void Awake()
    {
        targetA = GameObject.Find("EmoteSpawner").transform;
        targetB = GameObject.Find("EmoteTarget").transform;
    }

    public void Start()
    {
        StartCoroutine(DestroyTimer());
        transform.position = targetA.position;
        startY = transform.position.y;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > lerpTime)
        {
            _timer = lerpTime;
        }
        float lerpRatio = _timer / lerpTime;
        Vector3 newPos = new Vector3(transform.position.x + speed * Time.deltaTime,startY + Mathf.Sin(Time.time * frequence) * magnitude,0);
        transform.position = newPos;//Vector3.Lerp(targetA.position, targetB.position, lerpRatio) + new Vector3(0, Mathf.Sin(Time.time) * Time.deltaTime * magnitude, 0)*force;
    }

    public IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(lifeTime); //3f
        Destroy(gameObject);
    }

}

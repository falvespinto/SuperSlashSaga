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
    public Transform targetA2;
    public Transform targetB;
    private float frequence = 15f;
    private float magnitude = 10f;
    private float speed = 400f;
    private float lifeTime = 1f;
    private float startY;
    private int currentSpawner;
    public void Awake()
    {
        targetA = GameObject.Find("EmoteSpawner").transform;
        targetA2 = GameObject.Find("EmoteSpawner2").transform;
        targetB = GameObject.Find("EmoteTarget").transform;
    }

    public void Start()
    {
        StartCoroutine(DestroyTimer());
        if (EmotesSpawner.currentSpawner == 0)
        {
            transform.position = targetA.position;
            currentSpawner = 0;
        }
        else
        {
            transform.position = targetA2.position;
            currentSpawner = 1;
        }
        
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
        Vector3 newPos;
        if (currentSpawner == 0)
        {
            newPos = new Vector3(transform.position.x + speed * Time.deltaTime, startY + Mathf.Sin(Time.time * frequence) * magnitude, 0);
        }
        else
        {
            newPos = new Vector3(transform.position.x - speed * Time.deltaTime, startY + Mathf.Sin(Time.time * frequence) * magnitude, 0);
        }
        
        transform.position = newPos;//Vector3.Lerp(targetA.position, targetB.position, lerpRatio) + new Vector3(0, Mathf.Sin(Time.time) * Time.deltaTime * magnitude, 0)*force;
    }

    public IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(lifeTime); //3f
        Destroy(gameObject);
    }

}

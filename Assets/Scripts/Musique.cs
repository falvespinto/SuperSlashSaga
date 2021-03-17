using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musique : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("voixHomme");
        StartCoroutine(Test());
        FindObjectOfType<AudioManager>().Play("combat");
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

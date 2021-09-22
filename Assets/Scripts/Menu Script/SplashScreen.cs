using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    public GameObject boutton;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(clignotement());
    }

    public void OnStart()
    {
        SceneManager.LoadScene("Menu Principal");
    }

    IEnumerator clignotement()
    {
        boutton.SetActive(true);
        yield return new WaitForSeconds(1);
        boutton.SetActive(false);
        yield return new WaitForSeconds(1);
    }

}

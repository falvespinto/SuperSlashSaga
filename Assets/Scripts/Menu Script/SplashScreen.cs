using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    public GameObject boutton;

    void Start()
    {
        StartCoroutine(clignotement());
    }



    public void OnStart()
    {
        SceneManager.LoadScene("Menu Principal");
    }

    IEnumerator clignotement()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            boutton.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            boutton.SetActive(false);
        }
        
    }




}

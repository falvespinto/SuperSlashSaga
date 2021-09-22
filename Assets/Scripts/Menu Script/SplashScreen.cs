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
       StartCoroutine(clignotement());
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
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

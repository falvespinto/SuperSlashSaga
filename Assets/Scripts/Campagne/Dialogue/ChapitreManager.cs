using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapitreManager : MonoBehaviour
{


    public static ChapitreManager instance;
    public int chapitreCombat = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chapitre()
    {
        instance.chapitreCombat++;
        Time.timeScale = 1f;
        if (instance.chapitreCombat == 1)
        {
            Debug.Log(instance.chapitreCombat);
            SceneManager.LoadScene("SuiteManequin");
            Debug.Log("Mannequin");
        }
        if (instance.chapitreCombat == 2)
        {
            Debug.Log(instance.chapitreCombat);
            SceneManager.LoadScene("Flashback");
            Debug.Log("flash");
        }
        if (instance.chapitreCombat == 3)
        {
            Debug.Log(instance.chapitreCombat);
            SceneManager.LoadScene("Pouvoir");
            Debug.Log("pouvoir");
        }
    }


}

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
            instance.chapitreCombat = PlayerPrefs.GetInt("LastChapterFinished");
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
            PlayerPrefs.SetInt("LastChapterFinished", instance.chapitreCombat);
            Debug.Log(instance.chapitreCombat);
            SceneManager.LoadScene("SuiteManequin");
            Debug.Log("Mannequin");
        }
        if (instance.chapitreCombat == 2)
        {
            PlayerPrefs.SetInt("LastChapterFinished", instance.chapitreCombat);
            Debug.Log(instance.chapitreCombat);
            SceneManager.LoadScene("Flashback");
            Debug.Log("flash");
        }
        if (instance.chapitreCombat == 3)
        {
            PlayerPrefs.SetInt("LastChapterFinished", instance.chapitreCombat);
            Debug.Log(instance.chapitreCombat);
            SceneManager.LoadScene("Pouvoir");
            Debug.Log("pouvoir");
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        if (instance.chapitreCombat == 0)
        {
            PlayerPrefs.SetInt("LastChapterFinished", instance.chapitreCombat);
            Debug.Log(instance.chapitreCombat);
            SceneManager.LoadScene("DebutHistoire");
            Debug.Log("Mannequin");
        }
        if (instance.chapitreCombat == 1)
        {
            PlayerPrefs.SetInt("LastChapterFinished", instance.chapitreCombat);
            Debug.Log(instance.chapitreCombat);
            SceneManager.LoadScene("SuiteManequin");
            Debug.Log("Mannequin");
        }
        if (instance.chapitreCombat == 2)
        {
            PlayerPrefs.SetInt("LastChapterFinished", instance.chapitreCombat);
            Debug.Log(instance.chapitreCombat);
            SceneManager.LoadScene("Flashback");
            Debug.Log("flash");
        }
        if (instance.chapitreCombat == 3)
        {
            PlayerPrefs.SetInt("LastChapterFinished", instance.chapitreCombat);
            Debug.Log(instance.chapitreCombat);
            SceneManager.LoadScene("Pouvoir");
            Debug.Log("pouvoir");
        }
    }


}

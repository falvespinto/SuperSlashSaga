using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            PlayerPrefs.SetInt("LastChapterFinished",0);
            if (ChapitreManager.instance != null)
            {
                ChapitreManager.instance.chapitreCombat = 0;
            }
            SceneManager.LoadScene("DebutHistoire");
        }
    }
}

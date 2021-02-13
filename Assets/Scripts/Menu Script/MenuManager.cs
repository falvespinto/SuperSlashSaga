using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static void GoToMenu(MenuName name)
    {
        switch(name)
        {
            case MenuName.Main:

                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:

                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
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
}

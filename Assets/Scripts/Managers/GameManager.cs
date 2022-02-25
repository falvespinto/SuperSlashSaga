using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int winner;
    public GameObject popUpDeath;
    public RetryMenu retryMenu;
    bool m_IsLocked = false;
    public bool IsLocked { get { return m_IsLocked; } }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    public void LockPlayers()
    {
        m_IsLocked = true;
    }

    public void UnlockPlayers()
    {
        m_IsLocked = false;
    }

    public void EndGame(int w)
    {
        
        winner = w;
        if (StartGame.isCampagne)
        {
           if(winner == 1)
            {
                ChapitreManager.instance.chapitre();
            }
            else
            {
                Time.timeScale = 0f;
                popUpDeath.SetActive(true);
                retryMenu.isOpen = true;
            }
        }
        else
        {
           SceneManager.LoadScene("MenuVictoire");
        }

    }


}

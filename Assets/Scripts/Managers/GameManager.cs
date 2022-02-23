using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int winner;

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
        SceneManager.LoadScene("MenuVictoire");
    }


}

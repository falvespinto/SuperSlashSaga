using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float time;
    public TextMeshProUGUI timerTextOver;
    public TextMeshProUGUI timerTextUnder;
    public PlayerData P1Data;
    public PlayerData P2Data;

    void Start()
    {
        StartCoroutine(StartTimer(time));
    }

    IEnumerator StartTimer(float seconds)
    {
        while (seconds > 0)
        {
            int s = (int)seconds;
            timerTextOver.text = s.ToString();
            timerTextUnder.text = s.ToString();
            seconds -= Time.deltaTime;
            if (seconds < 0)
            {
                timerTextOver.text = "0";
                timerTextUnder.text = "0";
            }   
            yield return null;
        }
        GameManager.instance.LockPlayers();
        StartCoroutine(EndTimerMovement());
    }

    int DetermineWinner()
    {
        float healthP1 = P1Data.GetComponentInChildren<Player>().currentHealth;
        float healthP2 = P2Data.GetComponentInChildren<Player>().currentHealth;

        return healthP1 < healthP2 ? 2 : 1;
    }

    IEnumerator EndTimerMovement()
    {
        LeanTween.scale(gameObject, transform.localScale*1.1f, 1f).setEaseInBounce();
        yield return new WaitForSeconds(1f);
        GameManager.instance.EndGame(DetermineWinner());
    }
}

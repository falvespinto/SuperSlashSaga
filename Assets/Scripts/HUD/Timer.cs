using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float time;
    public TextMeshProUGUI timerTextOver;
    public TextMeshProUGUI timerTextUnder;
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    [SerializeField]
    private OneShotAudio Round1;
    [SerializeField]
    private OneShotAudio Round2;
    [SerializeField]
    private OneShotAudio Round3;
    [SerializeField]
    private OneShotAudio Go;


    public void playSoundOne()
    {
        Round1.PlayTheSound();
    }

    public void playSoundTwo()
    {
        Round2.PlayTheSound();
    }
    public void playSoundThree()
    {
        Round3.PlayTheSound();
    }

    public void playSoundGo()
    {
        Go.PlayTheSound();
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

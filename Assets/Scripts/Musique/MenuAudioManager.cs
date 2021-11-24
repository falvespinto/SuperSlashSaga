using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    [SerializeField]
    private OneShotAudio percution;
    [SerializeField]
    private OneShotAudio selection;


    public void playSoundPercution()
    {
        percution.PlayTheSound();
    }

    public void playSoundSelection()
    {
        selection.PlayTheSound();
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

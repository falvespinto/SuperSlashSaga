using System.Collections;
using System.Collections.Generic;
using UnityEngine.Timeline;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;
public class tempScript : MonoBehaviour
{
    public PlayableDirector currentTrack;
    void Update()
    {
        if (Keyboard.current.oKey.isPressed)
        {
            currentTrack.Play();
        }
    }
}

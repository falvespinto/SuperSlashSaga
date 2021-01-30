using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] randomSounds;
    private Sound randomSound;
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
        foreach (Sound rs in randomSounds)
        {
            rs.source = gameObject.AddComponent<AudioSource>();
            rs.source.clip = rs.clip;
            rs.source.volume = rs.volume;
            rs.source.pitch = rs.pitch;
            rs.source.loop = rs.loop;
   
        }

    }

    void Start()
    {
        //Play("Main Theme");
    }

    public void RandomPlay()
    {
        int index = Random.Range(0, randomSounds.Length);
        randomSound = randomSounds[index];
        randomSound.source.Play();
    }

    public void Play (string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
       s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}

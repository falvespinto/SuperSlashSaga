using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    //playoneshot 
    public Sound[] sounds;

    public bool verifIncreased = false;
    public bool verifDecreased = false;
    public bool cooldown = false;
    public BarreSon son;
    public MenuScript menuScript;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;


        }

    }



    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
    public void UpdateVolume(float volume)
    {
        foreach (Sound schange in sounds)
        {
            schange.source.volume = volume;
        }
    }
    public void IncreaseVolume(float volume)
    {
        if (!cooldown && menuScript.optionActive)
        {
            cooldown = true;
            Invoke("setCooldown", 0.3f);
            Debug.Log(sounds);
            son.IncreasedSlider();
            foreach (Sound schange in sounds)
            {
                Debug.Log(schange.source.volume);
                schange.source.volume += volume;
            }
        }
    }


    public void DecreaseVolume(float volume)
    {
        if (!cooldown && menuScript.optionActive)
        {
            cooldown = true;
            Invoke("setCooldown", 0.3f);
            son.DecreasedSlider();
            foreach (Sound schange in sounds)
            {
                Debug.Log(schange.source.volume);
                schange.source.volume -= volume;
            }
        }
    }
    private void setCooldown()
    {
        cooldown = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioOption : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("musique", Mathf.Log10(1) * 20);//remplacer le 1 par ce quon veut
        audioMixer.SetFloat("sfx", Mathf.Log10(1) * 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

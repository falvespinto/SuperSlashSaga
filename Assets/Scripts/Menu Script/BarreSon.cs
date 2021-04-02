using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreSon : MonoBehaviour
{
    AudioManager musique = new AudioManager();
    static Image Barre;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(musique.verifIncreased)
        {
            Barre.fillAmount += 0.1f;
            
        }
        else if(musique.verifDecreased)
        {
            Barre.fillAmount -= 0.1f;
        }
    }
}

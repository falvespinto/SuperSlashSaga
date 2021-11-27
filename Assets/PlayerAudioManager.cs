using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private OneShotAudio coupLeger;
    [SerializeField]
    private OneShotAudio coupLourd;
    [SerializeField]
    private OneShotAudio parade;
    [SerializeField]
    private OneShotAudio kunai;
    [SerializeField]
    private OneShotAudio ultimate;
    [SerializeField]
    private OneShotAudio impact;
    [SerializeField]
    private OneShotAudio coupFinalLourd;
    [SerializeField]
    private OneShotAudio coupFinalLeger;


    public void playSoundLeger()
    {
        coupLeger.PlayTheSound();
    }

    public void playSoundLourd()
    {
        coupLourd.PlayTheSound();
    }
    public void playSoundKunai()
    {
        kunai.PlayTheSound();
    }
    public void playSoundParade()
    {
        parade.PlayTheSound();
    }

    public void playSoundUltimate()
    {
        ultimate.PlayTheSound();
    }
    public void playSoundImpact()
    {
        impact.PlayTheSound();
    }

    public void playSoundCoupFinalLourd()
    {
        coupFinalLourd.PlayTheSound();
    }

    public void playSoundCoupFinalLeger()
    {
        coupFinalLeger.PlayTheSound();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

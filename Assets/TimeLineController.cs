using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Cinemachine;

public class TimeLineController : MonoBehaviour
{

    public PlayableDirector fullCombo;

    public void PerformFullCombo(Animator attaquant, Animator defenseur, CinemachineBrain camera)
    {
        TimelineAsset timeline = (TimelineAsset)fullCombo.playableAsset;
        foreach (var track in timeline.GetOutputTracks())
        {
            if (track.name == "Attaquant")
            {
                fullCombo.SetGenericBinding(track, attaquant);
            }
            if (track.name == "Defenseur")
            {
                fullCombo.SetGenericBinding(track, defenseur);
            }
            if (track.name == "Camera")
            {
                fullCombo.SetGenericBinding(track, camera);
            }
        }
        fullCombo.Play();
    }
}

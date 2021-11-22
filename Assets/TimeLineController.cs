using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Cinemachine;

public class TimeLineController : MonoBehaviour
{

    public PlayableDirector fullCombo;
    public PlayableDirector finalUlt;
    private PlayerAttack playerAttack;
    private UltimateAttack ultimateAttack;

    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
        ultimateAttack = GetComponent<UltimateAttack>();
    }

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

    public void PerformFinalUlt(Animator def)
    {
        TimelineAsset timeline = (TimelineAsset)finalUlt.playableAsset;
        StartCoroutine(ultimateAttack.SwitchCamera((float)timeline.duration));
        StartCoroutine(ultimateAttack.HasProcFullUlt((float)timeline.duration));
        foreach (var track in timeline.GetOutputTracks())
        {
            if (track.name == "Def")
            {
                finalUlt.SetGenericBinding(track, def);
            }
        }
        finalUlt.Play();
    }
    public IEnumerator waitBeforeDash(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Vector3 direction = playerAttack.LookAtTarget();
        StartCoroutine(playerAttack.ForwardAttack(0.12f, direction, 8f));
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UltimateAttack
{
    public bool isPerformingUltimate { get; set; }
    public void HandleFullUlt();
    public void PerformUltimateAttack();
    public IEnumerator SwitchCamera(float time);
    public IEnumerator HasProcFullUlt(float time);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public Player health;
    public float burn ;
    public HealthBar healthBarManager;
    private bool isBurning;
    private Coroutine PlayBurn;

    private void Start()
    {
        isBurning = false;
        PlayBurn = null;
    }

    public void ApplyBurn()
    {
        if (!isBurning)
        { 
            isBurning = true;
            PlayBurn = StartCoroutine(Burn());
        }
    }
    public void StopBurn()
    {
        isBurning = false;
        if(PlayBurn != null)
        {
            StopCoroutine(PlayBurn);
        }
    }
    IEnumerator Burn()
    {
            while (health.GetComponent<Player>().currentHealth > 0)
            {
                yield return new WaitForSeconds(0.5f);
                burn = 2.5f;
                health.GetComponent<Player>().TakeDamage(burn,"terrain");
            }
    }
}

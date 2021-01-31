using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public Player health;
    public int burn ;
    public HealthBar healthBarManager;
    private bool isBurning;

    private void Start()
    {
        isBurning = false;
    }

    public void ApplyBurn()
    {
        isBurning = true;
        StopCoroutine(Burn());
        StartCoroutine(Burn());
    }
    public void StopBurn()
    {
        isBurning = false;
    }
    IEnumerator Burn()
    {
        
        while (health.GetComponent<Player>().currentHealth > 0 && isBurning == true)
        {
                burn = 5;
                health.GetComponent<Player>().TakeDamage(burn);
                Debug.Log("arg j'ai pris " + 5 + " de dégats");
                yield return new WaitForSeconds(1f);
        }
        

    }
}

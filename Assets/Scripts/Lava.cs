using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<StatusManager>() != null)
            other.GetComponent<StatusManager>().ApplyBurn();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<StatusManager>() != null)
            other.GetComponent<StatusManager>().StopBurn();
    }
}

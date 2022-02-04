using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangePermute : MonoBehaviour
{
    public bool bIsInRange;

    private void Start()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            bIsInRange = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            bIsInRange = false;
        }
    }
}

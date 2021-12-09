using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFx : MonoBehaviour
{
    public Text effect_name;
    public GameObject[] effect;
    public float _TimeDel = 2.0f;
    private static int numSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        effect = Resources.LoadAll<GameObject>("Prefabs");
        effect_name.text = effect[0].name;
    }

    // Update is called once per frame

    public void ChangedFx()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 6.0f;       // we want 2m away from the camera position
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        GameObject fx = Instantiate(effect[numSpawned], objectPos, Quaternion.identity);
        Destroy(fx, _TimeDel);
    }

    void changeTextLabel(int numSpawned)
    {
        effect_name.text = effect[numSpawned].name;
    }

    public void nextEf()
    {
        if (numSpawned < effect.Length - 1)
        {
            numSpawned++;
            //effect_name.text = effect[numSpawned].name;
            changeTextLabel(numSpawned);
        }
        else if(numSpawned >= effect.Length - 1)
        {
            numSpawned = 0;
            changeTextLabel(numSpawned);
        }
    }

    public void prevEf()
    {
        if (numSpawned > 0)
        {
            numSpawned--;
            //effect_name.text = effect[numSpawned].name;
            changeTextLabel(numSpawned);
        }
        else if(numSpawned == 0)
        {
            numSpawned = effect.Length - 1;
            changeTextLabel(numSpawned);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconController : MonoBehaviour
{
    public bool isJoyconPluggued;
    private List<Joycon> m_Joycons;
    public float[] stick;
    public Vector3 gyroscop;
    public Vector3 accel;
    public Vector2 movementInput;
    public int jc_ind = 0;
    public Quaternion orientation;

    void Start()
    {
        // setup des variables en rapport avec les joycons
        gyroscop = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        m_Joycons = JoyconManager.Instance.j;
        if (m_Joycons.Count < jc_ind + 1)
        {
            isJoyconPluggued = false;
        }
        else
        {
            isJoyconPluggued = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isJoyconPluggued)
        {
            // a voir mais ça va surement changer
            Joycon j = m_Joycons[jc_ind];

            j = m_Joycons[1];

            if (Sign(j.GetStick()[0]) != 0)
            {

            }



        }

    }

    int Sign(float number)
    {
        if (number == 0)
        {
            return 0;
        }
        else
        {
            if (number > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}

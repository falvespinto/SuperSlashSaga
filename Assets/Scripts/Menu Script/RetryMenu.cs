using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RetryMenu : MonoBehaviour
{
    private int SelectedButton = 1;
    public Transform ButtonPosition1;
    public Transform ButtonPosition2;
    public bool isOpen = false;
    public GameObject Point;
    public void Play()
    {
        if (SelectedButton == 1)
        {
            //Retry
            ChapitreManager.instance.Restart();
            Debug.Log("Retry");

        }
        else if (SelectedButton == 2)
        {
            // Leave
            SceneManager.LoadScene("Menu Principal");
            Debug.Log("Leave");
        }
    }

    public void ButtonUp()
    {
        if (isOpen)
        {
            SelectedButton = 1;
            MoveThePointer();
            return;
        }
    }
    public void ButtonDown()
    {
        if (isOpen)
        {
            SelectedButton = 2;
            MoveThePointer();
            return;
        }
    }

    private void MoveThePointer()
    {
        // Moves the pointer
        if (SelectedButton == 1)
        {
            Point.transform.position = ButtonPosition1.position;
        }
        else if (SelectedButton == 2)
        {
            Point.transform.position = ButtonPosition2.position;
        }
    }
}

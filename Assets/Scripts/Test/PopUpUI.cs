using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp
{
    public string Message;
}
public class PopUpUI : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Text messageUIText;
    public bool isBusy = false;
    PopUp popUp = new PopUp();

    public static PopUpUI Instance;

    private void Awake()
    {
        Instance = this;
    }

    public PopUpUI SetMessage(string message)
    {
        popUp.Message = message;
        return Instance;
    }

    public void Show()
    {
        messageUIText.text = popUp.Message;
        canvas.SetActive(true);
        isBusy = true;
        Invoke("Hide", 3f);
    }

    public void Hide()
    {
        isBusy = false;
        canvas.SetActive(false);
        popUp = new PopUp();
    }
}

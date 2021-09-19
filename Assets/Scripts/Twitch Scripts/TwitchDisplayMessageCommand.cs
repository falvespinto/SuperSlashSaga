using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchDisplayMessageCommand : ITwitchCommandHandler
{
    public void HandleCommand(TwitchCommandData data)
    {
        int index = data.Message.IndexOf(" ")+1;
        string text = data.Author + " dit : " + data.Message.Substring(index);
        if (!PopUpUI.Instance.isBusy && data.Argument != "none")
        {
            PopUpUI.Instance.SetMessage(text);
            PopUpUI.Instance.Show();

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITwitchCommandHandler
{
    void HandleCommand(TwitchCommandData data);
}

public struct TwitchCommandData
{
    public string Author;
    public string Message;
    public string Argument;
}

public struct TwitchCredentials
{
    public string ChannelName;
    public string Username;
    public string Password;
}
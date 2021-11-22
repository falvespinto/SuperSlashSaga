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



public class CommandCollection
{
    private Dictionary<string, ITwitchCommandHandler> _commands;
    public CommandCollection()
    {
        _commands = new Dictionary<string, ITwitchCommandHandler>();
        _commands.Add(TwitchCommands.CommandMessage, new TwitchDisplayMessageCommand());
        _commands.Add(TwitchCommands.CommandDamage, new TwitchDmgCommand());
        // m_commands.Add(TwitchCommands.CommandDamage, ) class dmg
    }
    public bool HasCommand(string command)
    {
        return _commands.ContainsKey(command) ? true : false;
    }

    public void ExecuteCommand(string command, TwitchCommandData data)
    {
        command = command.Substring(1); // retire le préfix
        if (HasCommand(command))
        {
            _commands[command].HandleCommand(data);
        }
    }

}
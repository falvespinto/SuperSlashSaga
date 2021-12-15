using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchCommandCollection : MonoBehaviour
{
    private Dictionary<string, ITwitchCommandHandler> _commands;
    public TwitchDisplayMessageCommand twitchDisplayMessageCommand;
    public TwitchDmgCommand twitchDmgCommand;
    public TwitchHypeCommand twitchHypeCommand;
    public TwitchVoteCommand twitchVoteCommand;

    public void Awake()
    {
        _commands = new Dictionary<string, ITwitchCommandHandler>();
        _commands.Add(TwitchCommands.CommandMessage, twitchDisplayMessageCommand);
        _commands.Add(TwitchCommands.CommandDamage, twitchDmgCommand);
        _commands.Add(TwitchCommands.CommandHype, twitchHypeCommand);
        _commands.Add(TwitchCommands.CommandVote, twitchVoteCommand);
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

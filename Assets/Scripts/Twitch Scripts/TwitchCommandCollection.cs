using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCollection : MonoBehaviour
{
    private Dictionary<string, ITwitchCommandHandler> _commands;
    public PlayerData J1;
    public PlayerData J2;
    public CommandCollection(PlayerData J1, PlayerData J2)
    {
        this.J1 = J1;
        this.J2 = J2;
        _commands = new Dictionary<string, ITwitchCommandHandler>();
        _commands.Add(TwitchCommands.CommandMessage, new TwitchDisplayMessageCommand());
        _commands.Add(TwitchCommands.CommandDamage, new TwitchDmgCommand());
        _commands.Add(TwitchCommands.CommandHype, new TwitchHypeCommand(J1,J2));
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

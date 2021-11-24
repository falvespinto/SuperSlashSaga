using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;

public class TwitchChat : MonoBehaviour
{
    private static TwitchChat _instance;
    private CommandCollection _commands;
    private TcpClient _twitchClient;
    private StreamReader _reader;
    private StreamWriter _writer;
    public static TwitchChat Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TwitchChat();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }

    // DEBUT FIX : A bouger vers une classe TwitchConnectUI qui contiendra une interface de connexion, pour l'instant on le fait en dure.
    private void Start()
    {
        TwitchCredentials credentials = new TwitchCredentials
        {
            ChannelName = "Ellixyy",
            Username = "Ellixyy",
            Password = "oauth:obvbopsvqm8775nhgah0hfopqagd2p"
        };
        Connect(credentials, new CommandCollection());
    }
    // FIN FIX

    void Update()
    {
        if (_twitchClient != null && _twitchClient.Connected)
        {
            ReadChat();
        }
      //else
     // {
            // FIX : Si les logs sont dans les playerprefs alors tenter une reconnexion.
      //}
    }

    public void Connect(TwitchCredentials credentials, CommandCollection commands)
    {
        _commands = commands;
        _twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        _reader = new StreamReader(_twitchClient.GetStream());
        _writer = new StreamWriter(_twitchClient.GetStream());

        _writer.WriteLine("PASS " + credentials.Password);
        _writer.WriteLine("NICK " + credentials.Username.ToLower());
        _writer.WriteLine("USER " + credentials.Username + " 8 * :" + credentials.Username);
        _writer.WriteLine("JOIN #" + credentials.ChannelName.ToLower());
        _writer.Flush();
    }

    private void ReadChat()
    {
        Debug.Log(_twitchClient.Available);
        if (_twitchClient.Available > 0)
        {
            string message = _reader.ReadLine();
            Debug.Log(message);
            if (message.Contains("PING"))
            {
                _writer.WriteLine("PONG");
                _writer.Flush();
                return;
            }
            
            if (message.Contains("PRIVMSG"))
            {
                var splitPoint = message.IndexOf("!", 1);
                var author = message.Substring(0, splitPoint);
                author = author.Substring(1);

                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);
                if (message.StartsWith(TwitchCommands.CommandPrefix))
                {
                    int index = message.IndexOf(" ");
                    string command = index > -1 ? message.Substring(0, index) : message;
                    string argument = index > -1 ? message.Split(' ')[1] : "none";
                    Debug.Log("Twitch : argument : " + argument);
                    Debug.Log("Twitch : Command : " + command);
                    _commands.ExecuteCommand(
                        command,
                        new TwitchCommandData
                        {
                            Author = author,
                            Message = message,
                            Argument = argument
                        });
                }
            }

        }
    }

}

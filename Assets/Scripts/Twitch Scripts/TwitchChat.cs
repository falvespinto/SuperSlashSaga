<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Linq;
using UnityEngine.Networking;
using SimpleJSON;
using System.Text.RegularExpressions;


public class TwitchChat : MonoBehaviour
{
    private string clientIdAPP = "v5wr5b8y0dfjouivn5b0t6tou0auhn";
    private string clientSecret = "1eocdpaksx61dsezqnm4za3ym0zwoy";
    private string oauthHelix = "ipxxf91uyb82ehtzddxiwzvm3wksr8";
    private static TwitchChat _instance;
    [SerializeField] private TwitchCommandCollection _commands;
    private TcpClient _twitchClient;
    private StreamReader _reader;
    private StreamWriter _writer;
    private bool gotEmotes = false;
    private string authJson;
    private EmotesData emotesData;
    private TwitchCredentials credentials;
    private List<string> emoteQueue = new List<string>();
    public EmotesSpawner emotesSpawner;
    public bool canSpawnEmote = true;
    public string json_folder;
    public bool userExist = false;
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
    }

    private void Start()
    {
        credentials = new TwitchCredentials
        {
            ChannelName = "Ellixyy",
            Username = "Ellixyy",
            Password = "oauth:kgtnyxxfzxz5qb7sivwc6oca526klc"
        };
        StartCoroutine(CheckIfUserExist(MenuScript.nomDeChaine));

    }
    // FIN FIX

    void Update()
    {
        if (_twitchClient != null && _twitchClient.Connected)
        {
            if (emotesData == null)
            {
                string emotesJson = "";
                if (File.Exists(Application.streamingAssetsPath + "/emotes.json"))
                {
                    emotesJson = File.ReadAllText(Application.streamingAssetsPath + "/emotes.json");
                }
                if (emotesJson != "")
                {
                    emotesData = ParseGlobalsEmotes(emotesJson);
                }
            }
            ReadChat();

        }
        else
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Linq;
using UnityEngine.Networking;
using SimpleJSON;
using System.Text.RegularExpressions;


public class TwitchChat : MonoBehaviour
{
    private string clientIdAPP = "v5wr5b8y0dfjouivn5b0t6tou0auhn";
    private string clientSecret = "1eocdpaksx61dsezqnm4za3ym0zwoy";
    private string oauthHelix = "ipxxf91uyb82ehtzddxiwzvm3wksr8";
    private static TwitchChat _instance;
    [SerializeField] private TwitchCommandCollection _commands;
    private TcpClient _twitchClient;
    private StreamReader _reader;
    private StreamWriter _writer;
    private bool gotEmotes = false;
    private string authJson;
    private EmotesData emotesData;
    private TwitchCredentials credentials;
    private List<string> emoteQueue = new List<string>();
    public EmotesSpawner emotesSpawner;
    public bool canSpawnEmote = true;
    public string json_folder;
    public bool userExist = false;
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
    }

    private void Start()
    {
        // logs du bot
        credentials = new TwitchCredentials
        {
            ChannelName = "Ellixyy",
            Username = "Ellixyy",
            Password = "oauth:kgtnyxxfzxz5qb7sivwc6oca526klc"
        };
        StartCoroutine(CheckIfUserExist(MenuScript.nomDeChaine)); //Vérification du nom d'user

    }
    // FIN FIX

    void Update()
    {
        if (_twitchClient != null && _twitchClient.Connected)
>>>>>>> Stashed changes
        {
            if (userExist)
            {
                Connect(credentials);
            }
            else
            {
                StartCoroutine(CheckIfUserExist(MenuScript.nomDeChaine));
<<<<<<< Updated upstream
            }
        }

        if (emoteQueue.Count >= 1 && canSpawnEmote)
        {
            emotesSpawner.StartInstantiate(emoteQueue[0]);
            emoteQueue.RemoveAt(0);
            StartCoroutine(WaitBeforeSpawnEmote());
        }
    }

    public void Connect(TwitchCredentials credentials)
    {
        _twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        _reader = new StreamReader(_twitchClient.GetStream());
        _writer = new StreamWriter(_twitchClient.GetStream());

        _writer.WriteLine("PASS " + credentials.Password);
        _writer.WriteLine("NICK " + credentials.Username.ToLower());
        _writer.WriteLine("USER " + credentials.Username + " 8 * :" + credentials.Username);
        _writer.WriteLine("JOIN #" + MenuScript.nomDeChaine.ToLower());
        _writer.Flush();
    }

    public void SendIRCMessage(string message)
    {
        _writer.WriteLine("PRIVMSG #" + MenuScript.nomDeChaine.ToLower() + " :" + message);
        _writer.Flush();
    }

    private void ReadChat()
    {
        if (_twitchClient.Available > 0)
        {
            Debug.Log("debut avail");
            Debug.Log(_twitchClient.Available);
            string message = _reader.ReadLine();
            Debug.Log(message);
            if (message.Contains("PING"))
            {
                _writer.WriteLine("PONG");
                _writer.Flush();
                return;
            }
            Debug.Log("apres ping");

            if (message.Contains("PRIVMSG"))
            {
                Debug.Log("privmsg");
                var splitPoint = message.IndexOf("!", 1);
                var author = message.Substring(0, splitPoint);
                author = author.Substring(1);

                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);
                if (author != credentials.Username.ToLower())
                {
                    Debug.Log("author");
                    Debug.Log(TwitchCommands.CommandPrefix);
                    if (message.StartsWith(TwitchCommands.CommandPrefix))
=======
            }
        }

        if (emoteQueue.Count >= 1 && canSpawnEmote)
        {
            emotesSpawner.StartInstantiate(emoteQueue[0]);
            emoteQueue.RemoveAt(0);
            StartCoroutine(WaitBeforeSpawnEmote());
        }
    }

    public void Connect(TwitchCredentials credentials)
    {
        _twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        _reader = new StreamReader(_twitchClient.GetStream());
        _writer = new StreamWriter(_twitchClient.GetStream());

        _writer.WriteLine("PASS " + credentials.Password);
        _writer.WriteLine("NICK " + credentials.Username.ToLower());
        _writer.WriteLine("USER " + credentials.Username + " 8 * :" + credentials.Username);
        _writer.WriteLine("JOIN #" + MenuScript.nomDeChaine.ToLower()); // nom de chaine = chaine de l'utilisateurs vers lequel on se connecte
        _writer.Flush();
    }

    public void SendIRCMessage(string message)
    {
        _writer.WriteLine("PRIVMSG #" + MenuScript.nomDeChaine.ToLower() + " :" + message);
        _writer.Flush();
    }

    private void ReadChat()
    {
        if (_twitchClient.Available > 0)
        {
            Debug.Log("debut avail");
            Debug.Log(_twitchClient.Available);
            string message = _reader.ReadLine();
            Debug.Log(message);
            if (message.Contains("PING"))
            {
                _writer.WriteLine("PONG");
                _writer.Flush();
                return;
            }
            Debug.Log("apres ping");

            if (message.Contains("PRIVMSG"))
            {
                Debug.Log("privmsg");
                var splitPoint = message.IndexOf("!", 1);
                var author = message.Substring(0, splitPoint);
                author = author.Substring(1);

                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);
                if (author != credentials.Username.ToLower())
                {
                    Debug.Log("author");
                    Debug.Log(TwitchCommands.CommandPrefix);
                    if (message.StartsWith(TwitchCommands.CommandPrefix))
                    {
                        Debug.Log("if startwith");
                        int index = message.IndexOf(" ");
                        string command = index > -1 ? message.Substring(0, index) : message;
                        string argument = index > -1 ? message.Split(' ')[1] : "none";
                        Debug.Log("Twitch : argument : " + argument);
                        Debug.Log("Twitch : Command : " + command);
                        Debug.Log(_commands);
                        _commands.ExecuteCommand(
                            command,
                            new TwitchCommandData
                            {
                                Author = author,
                                Message = message,
                                Argument = argument,
                                Command = command
                            });
                    }
                    else
>>>>>>> Stashed changes
                    {
                        Debug.Log("if startwith");
                        int index = message.IndexOf(" ");
                        string command = index > -1 ? message.Substring(0, index) : message;
                        string argument = index > -1 ? message.Split(' ')[1] : "none";
                        Debug.Log("Twitch : argument : " + argument);
                        Debug.Log("Twitch : Command : " + command);
                        Debug.Log(_commands);
                        _commands.ExecuteCommand(
                            command,
                            new TwitchCommandData
                            {
                                Author = author,
                                Message = message,
                                Argument = argument,
                                Command = command
                            });
                    }
                    else
                    {
                        Debug.Log("else");
                        MatchCollection words = Regex.Matches(message, @"\b[\w']*\b");
                        foreach (var word in words)
                        {
                            foreach (var emote in emotesData.data)
                            {
                                if (emote.name == word.ToString())
                                {
                                    string resultUrl = getEmoteImage(emote.name);
                                    if (resultUrl != "none")
                                    {
                                        emoteQueue.Add(resultUrl);
                                    }
                                }
                            }
                        }
                    }
                    if (_commands.twitchVoteCommand.voteOnGoing)
                    {
                        int index = message.IndexOf(" ");
                        string command = index > -1 ? message.Substring(0, index) : message;
                        command = command.ToLower();
                        message = message.ToLower();
                        string[] words = message.Split(' ');

                        bool wordMatch = false;
                        string match = "";

                        //string[] words = _commands.twitchVoteCommand.choix.Keys.ToArray();
                        foreach (string word in words)
                        {
                            if (_commands.twitchVoteCommand.choix.ContainsKey(word))
                            {
                                match = word;
                                wordMatch = true;
                                Instance.SendIRCMessage("Le viewver " + author + " a voté " + message);
                                break;
                            }
                            wordMatch = false;
                        }
                        if (wordMatch)
                        {
                            _commands.twitchVoteCommand.HandleCommand(
                                new TwitchCommandData
                                {
                                    Author = author,
                                    Message = message,
                                    Argument = match,
                                    Command = command
                                }
                                );
                        }
                    }

                }
                //foreach (var emote in emotesData.data)
                //{
                //  if (message.Contains(emote.name))
                //  {
                //      string resultUrl = getEmoteImage(emote.name);
                //      if (resultUrl != "none")
                //      {
                //            emoteQueue.Add(resultUrl);
                //      }
                //  }
                //}
            }

        }
        else
        {

        }

    }

    private IEnumerator GetGlobalsEmotes()
    {
        string uri = "https://api.twitch.tv/helix/chat/emotes/global";
        StartCoroutine(GetOathToken());
        yield return new WaitForSeconds(0.5f);
        JSONNode authEmotes = JSON.Parse(authJson);
        string oauthEmotes = authEmotes["access_token"];
        string bearer = "Bearer " + oauthEmotes;
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            request.SetRequestHeader("Authorization", bearer);
            request.SetRequestHeader("Client-ID", clientIdAPP);
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                userExist = false;
            }
            else
            {
                userExist = ParseUserExist(request.downloadHandler.text);
            }
        }
    }



    private IEnumerator GetOathToken()
    {
        string uri = "https://id.twitch.tv/oauth2/token";
        WWWForm form = new WWWForm();
        form.AddField("client_id", clientIdAPP);
        form.AddField("client_secret", clientSecret);
        form.AddField("grant_type", "client_credentials");
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
            }
            else
            {
                authJson = request.downloadHandler.text;
            }
        }
    }

    private EmotesData ParseGlobalsEmotes(string json)
    {
        EmotesData emotesData = JsonUtility.FromJson<EmotesData>(json);
        return emotesData;
    }

    private bool ParseUserExist(string json)
    {
        UserData usersData = JsonUtility.FromJson<UserData>(json);
        return usersData.data[0].id != null ? true : false;
    }

    private string getEmoteImage(string emoteName)
    {
        bool hasFoundImage = false;
        string imageString = "none";
        foreach (var emote in emotesData.data)
        {
            if (emote.name == emoteName)
            {
                hasFoundImage = true;
                imageString = emote.images.url_1x;
            }
        }
        if (hasFoundImage)
        {
            return imageString;
        }
        else
        {
            return "none";
        }

    }


    private IEnumerator WaitBeforeSpawnEmote()
    {
        canSpawnEmote = false;
        yield return new WaitForSeconds(0.2f);
        canSpawnEmote = true;
    }

    private IEnumerator CheckIfUserExist(string name)
    {
        string uri = "https://api.twitch.tv/helix/users?login=" + name;
        string bearer = "Bearer " + oauthHelix;
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            request.SetRequestHeader("Authorization", bearer);
            request.SetRequestHeader("Client-ID", clientIdAPP);
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {

            }
            else
            {
                userExist = ParseUserExist(request.downloadHandler.text);
            }
        }
    }

}
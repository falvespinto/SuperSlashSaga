using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System.Threading.Tasks;
public class TwitchSubCommand : MonoBehaviour, ITwitchCommandHandler
{
    public Transform[] spawnPoints;
    public GameObject[] prefabsBosses;
    private TwitchUserData twitchUser;
    public int index = 0;
    private string clientIdAPP = "v5wr5b8y0dfjouivn5b0t6tou0auhn";
    private string clientSecret = "1eocdpaksx61dsezqnm4za3ym0zwoy";
    private string oauthHelix = "qy18npi82duraimvu81c32adelt6i1";
    private string profileImageUrl;
    private bool goodTexture = false;
    private Texture2D currentTexture;
    public void HandleCommand(TwitchCommandData data)
    {
        if (spawnPoints[index].GetComponentInChildren<Boss>() != null)
        {
            foreach (Transform child in spawnPoints[index])
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        GameObject boss = Instantiate(prefabsBosses[0], spawnPoints[index]);
        boss.transform.localScale *= 10;
        boss.GetComponentInChildren<TextMesh>().text = data.Author;
        StartCoroutine(GetUserData(data.Author, boss));
        index++;
        if (index > 9)
        {
            index = 0;
        }
    }

    private IEnumerator GetUserData(string author, GameObject boss)
    {
        string uri = "https://api.twitch.tv/helix/users?login=" + author;

        string bearer = "Bearer " + oauthHelix;
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            request.SetRequestHeader("Authorization", bearer);
            request.SetRequestHeader("Client-Id", clientIdAPP);
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {

            }
            else
            {
                twitchUser = ParseTwitchUser(request.downloadHandler.text);
                StartCoroutine(SetProfileImage(twitchUser.data[0].profile_image_url, boss));
            }
        }
    }

    private TwitchUserData ParseTwitchUser(string json)
    {
        TwitchUserData twitchUserData = JsonUtility.FromJson<TwitchUserData>(json);
        return twitchUserData;
    }
    private IEnumerator SetProfileImage(string imageURL, GameObject boss)
    {
        LoadProfileImage(imageURL);
        yield return new WaitUntil(() => goodTexture == true);
        if (currentTexture != null)
        {
            boss.GetComponentInChildren<SpriteRenderer>().sprite = Sprite.Create(currentTexture, new Rect(0,0, currentTexture.width, currentTexture.height), new Vector2(0.5f,0.5f), 1000f);
            currentTexture = null;
            goodTexture = false;
        }
    }
    public async void LoadProfileImage(string imageURL)
    {
        Debug.Log("Loading .....");
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageURL))
        {
            var async = request.SendWebRequest();

            while (async.isDone == false)
            {
                await Task.Delay(1000 / 30);
            }

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error + " url : " + request.url);
            }
            else
            {
                currentTexture = DownloadHandlerTexture.GetContent(request);
                goodTexture = true;
            }

        }
    }

}

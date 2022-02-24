using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Threading.Tasks;
public class EmotesSpawner : MonoBehaviour
{
    Texture currentTexture;
    private bool goodPrivateTexture = false;
    public EmoteHandler emote;
    public GameObject emoteSpawner2;
    public static int currentSpawner = 0;
    public async void LoadEmote(string emoteURL)
    {
        Debug.Log("Loading .....");
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(emoteURL))
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
                goodPrivateTexture = true;
            }

        }
    }
    public void StartInstantiate(string emoteURL)
    {
        StartCoroutine(InstantiateEmote(emoteURL));
    }
    public IEnumerator InstantiateEmote(string emoteURL)
    {
        LoadEmote(emoteURL);
        yield return new WaitUntil(() => goodPrivateTexture == true);
        if (currentTexture != null)
        {
            emote.thisRawImage.texture = currentTexture;
        }
        if (currentSpawner == 0)
        {
            EmoteHandler newEmote = Instantiate(emote, transform.position, transform.rotation) as EmoteHandler;
            newEmote.transform.SetParent(this.transform, false);
        }
        else
        {
            EmoteHandler newEmote = Instantiate(emote, emoteSpawner2.transform.position, emoteSpawner2.transform.rotation) as EmoteHandler;
            newEmote.transform.SetParent(emoteSpawner2.transform, false);
        }
        currentSpawner = 1 - currentSpawner;

        
        
        currentTexture = null;
        goodPrivateTexture = false;
    }
}

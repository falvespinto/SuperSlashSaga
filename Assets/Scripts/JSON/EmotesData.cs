using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EmotesData
{
    public dataEmote[] data;
}
[System.Serializable]
public class ImagesData {
    public string url_1x;
    public string url_2x;
    public string url_4x;
}
[System.Serializable]
public class dataEmote {
    public string id;
    public string name;
    public ImagesData images;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TwitchUserData
{
    public data[] data;
}
[System.Serializable]
public class data
{
    public string id;
    public string login;
    public string display_name;
    public string type;
    public string broadcaster_type;
    public string description;
    public string profile_image_url;
    public string offline_image_url;
    public string view_count;
    public string created_at;
}

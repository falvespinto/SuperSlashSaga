using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserData
{
    public DataUser data;
}
[System.Serializable]
public class DataUser
{
    public string id;
    public string login;
    public string display_name;
    public string profile_image_url;
}

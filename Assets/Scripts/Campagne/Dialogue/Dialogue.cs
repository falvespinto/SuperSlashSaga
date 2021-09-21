using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string sName;
    [TextArea(1,10)]
    public string[] sSentences;
}

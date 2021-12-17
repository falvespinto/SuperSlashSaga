using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class LogCreator : MonoBehaviour
{
    public static string logFilePath;
    void Start()
    {
        if (!LogCreated.logHasBeenCreated)
        {
            LogCreated.logHasBeenCreated = true;
            string timestamp = GetTimestamp(DateTime.Now);
            if (!Directory.Exists(Application.persistentDataPath + "/Logs"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Logs");
            }
            logFilePath = Application.persistentDataPath + "/Logs/LOG_" + timestamp + ".txt";
            if (!File.Exists(logFilePath))
            {
                File.WriteAllText(logFilePath, "Fichier de log \n");
            }
        }
    }

    private string GetTimestamp(DateTime value)
    {
        return value.ToString("yyyyMMddHHmmssffff");
    }

    private void OnApplicationQuit()
    {
        File.AppendAllText(logFilePath, "\n" + "Le nombre de combats effectués durant cette session de jeu est de : " + LogManager.combatsTotaux);
        string data = File.ReadAllText(logFilePath);
        string encryptedData = SerializationAndEncryption.Encrypt(data);
        string logBinPath = logFilePath.Replace(".txt", ".sss");
        using (var stream = System.IO.File.OpenWrite(logBinPath))
        using (var writer = new System.IO.BinaryWriter(stream))
        {
            writer.Write(encryptedData);
        }
    }



}
[System.Serializable]
public class LogData
{
    public LogData(string log)
    {
        this.log = log;
    }
    public string log;
}
public static class LogCreated
{
    public static bool logHasBeenCreated = false;
}

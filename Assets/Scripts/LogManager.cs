using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    public int J1Light = 0;
    public int J1Heavy = 0;
    public int J1Ulti = 0;
    public int J1Dash = 0;
    public int J1ParadeUsed = 0;
    public int J1ParadeTriggered = 0;

    public int J2Light = 0;
    public int J2Heavy = 0;
    public int J2Ulti = 0;
    public int J2Dash = 0;
    public int J2ParadeUsed = 0;
    public int J2ParadeTriggered = 0;
    public static string logFilePath;
    private float currentTime;

    private void OnEnable()
    {
        Dash.OnDash += AddDash;
        PlayerAttack.OnLightAtk += AddLightAtk;
        PlayerAttack.OnHeavyAtk += AddHeavyAtk;
        PlayerAttack.OnUltimateAtk += AddUltimateAtk;
        PlayerAttack.OnParadeUsed += AddParadeUsed;
        PlayerAttack.OnParadeTriggered += AddParadeTriggered;
        Player.OnDeath += AddDeath;
    }

    private void Start()
    {
        currentTime = 0;
        StartLog();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    private void AddDash(int playerindex)
    {
        if (playerindex == 0)
            J1Dash += 1;
        else
            J2Dash += 1;
    }
    private void AddLightAtk(int playerindex)
    {
        if (playerindex == 0)
            J1Light += 1;
        else
            J2Light += 1;
    }
    private void AddHeavyAtk(int playerindex)
    {
        if (playerindex == 0)
            J1Heavy += 1;
        else
            J2Heavy += 1;
    }
    private void AddUltimateAtk(int playerindex)
    {
        if (playerindex == 0)
            J1Ulti += 1;
        else
            J2Ulti += 1;
    }
    private void AddParadeUsed(int playerindex)
    {
        if (playerindex == 0)
            J1ParadeUsed += 1;
        else
            J2ParadeUsed += 1;
    }
    private void AddParadeTriggered(int playerindex)
    {
        if (playerindex == 0)
            J1ParadeTriggered += 1;
        else
            J2ParadeTriggered += 1;
    }
    private void AddDeath(int playerindex)
    {
        if (playerindex == 0)
            CreateLog("J2");
        else
            CreateLog("J1");
    }
    private void CreateLog(string winner)
    {
        string content = "Durée du combat : " + TimeSpan.FromSeconds(currentTime).ToString() + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Joueur gagnant : " + winner + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de light effectué par le J1 : " + J1Light + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de light effectué par le J2 : " + J2Light + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de heavy effectué par le J1 : " + J1Heavy + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de heavy effectué par le J2 : " + J2Heavy + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre d'ultimate lancée par le J1 : " + J1Ulti + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre d'ultimate lancée par le J2 : " + J2Ulti + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de dash effectué par le J1 : " + J1Dash + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de dash effectué par le J2 : " + J2Dash + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de parade utilisée par le J1 : " + J1ParadeUsed + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de parade utilisée par le J2 : " + J2ParadeUsed + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de parade du J1 trigger : " + J1ParadeTriggered + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de parade du J2 trigger : " + J2ParadeTriggered + "\n";
        File.AppendAllText(logFilePath, content);
    }
    private void StartLog()
    {
        string timestamp = GetTimestamp(DateTime.Now);
        logFilePath = Application.dataPath + "/Log/LOG_" + timestamp + ".txt";
        if (!File.Exists(logFilePath))
        {
            File.WriteAllText(logFilePath, "Fichier de log \n");
        }
    }
    private string GetTimestamp(DateTime value)
    {
        return value.ToString("yyyyMMddHHmmssffff");
    }
}

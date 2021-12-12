using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    public PlayerData J1;
    public PlayerData J2;
    public int J1Light = 0;
    public int J1Heavy = 0;
    public int J1Ulti = 0;
    public int J1Dash = 0;
    public int J1ParadeUsed = 0;
    public int J1ParadeTriggered = 0;
    public int J1ComboTriggered = 0;
    public int J1GuardBroke = 0;
    public int J1PermutationTriggered = 0;

    public int J2Light = 0;
    public int J2Heavy = 0;
    public int J2Ulti = 0;
    public int J2Dash = 0;
    public int J2ParadeUsed = 0;
    public int J2ParadeTriggered = 0;
    public int J2ComboTriggered = 0;
    public int J2GuardBroke = 0;
    public static string logFilePath;
    private float currentTime;
    public int J2PermutationTriggered = 0;

    public static int combatsTotaux = 0;


    public bool canCreateLog = true;

    private void OnEnable()
    {
        Dash.OnDash += AddDash;
        PlayerAttack.OnLightAtk += AddLightAtk;
        PlayerAttack.OnHeavyAtk += AddHeavyAtk;
        PlayerAttack.OnUltimateAtk += AddUltimateAtk;
        PlayerAttack.OnParadeUsed += AddParadeUsed;
        PlayerAttack.OnParadeTriggered += AddParadeTriggered;
        Player.onGuardBroke += AddGuardBroke;
        Player.OnDeath += AddDeath;
        LightAttack.onComboTriggered += AddComboTriggered;
        Permutation.onPermutation += AddPermutation;
    }
    private void OnDisable()
    {
        Dash.OnDash -= AddDash;
        PlayerAttack.OnLightAtk -= AddLightAtk;
        PlayerAttack.OnHeavyAtk -= AddHeavyAtk;
        PlayerAttack.OnUltimateAtk -= AddUltimateAtk;
        PlayerAttack.OnParadeUsed -= AddParadeUsed;
        PlayerAttack.OnParadeTriggered -= AddParadeTriggered;
        Player.onGuardBroke += AddGuardBroke;
        Player.OnDeath -= AddDeath;
        LightAttack.onComboTriggered -= AddComboTriggered;
        Permutation.onPermutation -= AddPermutation;
    }

    private void Start()
    {
        currentTime = 0;
        combatsTotaux++;
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
    private void AddComboTriggered(int playerindex)
    {
        if (playerindex == 0)
            J1ComboTriggered += 1;
        else
            J2ComboTriggered += 1;
    }
    private void AddGuardBroke(int playerindex)
    {
        if (playerindex == 0)
            J1ComboTriggered += 1;
        else
            J2ComboTriggered += 1;
    }
    private void AddPermutation(int playerindex)
    {
        if (playerindex == 0)
            J1PermutationTriggered += 1;
        else
            J2PermutationTriggered += 1;
    }
    private void AddDeath(int playerindex)
    {
        if (canCreateLog)
        {
            StartCoroutine(CanCreateLog());
            if (playerindex == 0)
                CreateLog("J2");
            else
                CreateLog("J1");
        }
    }
    private void CreateLog(string winner)
    {
        string content = "Dur�e du combat : " + TimeSpan.FromSeconds(currentTime).ToString() + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Joueur gagnant : " + winner + "\n";
        File.AppendAllText(logFilePath, content);
        content = "PV restants du gagnant : " + J1.GetComponentInChildren<Player>().currentHealth + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Personnage choisi par le J1 : " + J1.GetComponentInChildren<Player>().characterName + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Personnage choisi par le J2 : " + J2.GetComponentInChildren<Player>().characterName + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de light effectu� par le J1 : " + J1Light + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de light effectu� par le J2 : " + J2Light + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de heavy effectu� par le J1 : " + J1Heavy + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de heavy effectu� par le J2 : " + J2Heavy + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre d'ultimate lanc�e par le J1 : " + J1Ulti + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre d'ultimate lanc�e par le J2 : " + J2Ulti + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de dash effectu� par le J1 : " + J1Dash + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de dash effectu� par le J2 : " + J2Dash + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de parade utilis�e par le J1 : " + J1ParadeUsed + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de parade utilis�e par le J2 : " + J2ParadeUsed + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de parade du J1 bris�es par le J2 : " + J1GuardBroke + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de parade du J2 bris�es par le J1 : " + J2GuardBroke + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de parade du J1 trigger : " + J1ParadeTriggered + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de parade du J2 trigger : " + J2ParadeTriggered + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de combo effectu� par le J1 : " + J1ComboTriggered + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de combo effectu� par le J2 : " + J2ComboTriggered + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de permutations r�ussites par le J1 : " + J1PermutationTriggered + "\n";
        File.AppendAllText(logFilePath, content);
        content = "Nombre de permutations r�ussites par le J2 : " + J2PermutationTriggered + "\n";
        File.AppendAllText(logFilePath, content);
    }
    private void StartLog()
    {
        logFilePath = LogCreator.logFilePath;
    }

    public IEnumerator CanCreateLog()
    {
        canCreateLog = false;
        yield return new WaitForSeconds(3f);
        canCreateLog = true;
    }
}

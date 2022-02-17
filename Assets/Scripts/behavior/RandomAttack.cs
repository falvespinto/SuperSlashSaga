using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class RandomAttack : MonoBehaviour
{
    public int randomNumber = Random.Range(0, 100);
    public Dictionary<string, int> nbAttacks;
    public Dictionary<string, float> percentAttacks;

    private void Start()
    {
        nbAttacks = new Dictionary<string, int>()
        {
            { "Light", 0 },
            { "Heavy", 0 },
            { "Parade", 0 }
        };

        percentAttacks = new Dictionary<string, float>()
        {
            { "Light", 0 },
            { "Heavy", 0 },
            { "Parade", 0 }
        };
    }
    private void OnEnable()
    {
        LightAttack.OnLightAtk += UpdateAttackData;
        HeavyAttack.OnHeavyAtk += UpdateAttackData;
        Parade.OnParadeUsed    += UpdateAttackData;
    }
    private void OnDisable()
    {
        LightAttack.OnLightAtk -= UpdateAttackData;
        HeavyAttack.OnHeavyAtk -= UpdateAttackData;
        Parade.OnParadeUsed    -= UpdateAttackData;
    }

    private void UpdateAttackData(string attack)
    {
        nbAttacks[attack]++;
        CalculatePercentLight();
        CalculatePercentHeavy();
        CalculatePercentParade();
    }

    public float CalculatePercentLight()
    {
        int sumAttacks = nbAttacks.Values.Sum();
        percentAttacks["Light"] = (nbAttacks["Light"] / sumAttacks) *100;
        return percentAttacks["Light"];
    }
    public float CalculatePercentHeavy()
    {
        int sumAttacks = nbAttacks.Values.Sum();
        percentAttacks["Heavy"] = (nbAttacks["Heavy"] / sumAttacks) * 100;
        return percentAttacks["Heavy"];
    }
    public float CalculatePercentParade()
    {
        int sumAttacks = nbAttacks.Values.Sum();
        percentAttacks["Parade"] = (nbAttacks["Parade"] / sumAttacks) * 100;
        return percentAttacks["Parade"];
    }

}

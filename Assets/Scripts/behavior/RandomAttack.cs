using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class RandomAttack : MonoBehaviour
{
    public int randomNumber;
    public Dictionary<string, float> nbAttacks;
    public Dictionary<string, float> percentAttacks;

    private void Start()
    {
        randomNumber = Random.Range(0, 100);
        nbAttacks = new Dictionary<string, float>()
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
        Parade.OnParadeUsed += UpdateAttackData;
    }
    private void OnDisable()
    {
        LightAttack.OnLightAtk -= UpdateAttackData;
        HeavyAttack.OnHeavyAtk -= UpdateAttackData;
        Parade.OnParadeUsed -= UpdateAttackData;
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
        float sumAttacks = nbAttacks.Values.Sum();
        if (sumAttacks > 0)
        {
            percentAttacks["Light"] = (nbAttacks["Light"] / sumAttacks) * 100;
            float test = (nbAttacks["Light"] / sumAttacks);
            float test2 = (nbAttacks["Light"] / sumAttacks) * 100;
            Debug.Log((nbAttacks["Light"] / sumAttacks) * 100);
            return percentAttacks["Light"];
        }
        else
        {
            return 0;
        }

    }
    public float CalculatePercentHeavy()
    {
        float sumAttacks = nbAttacks.Values.Sum();
        if (sumAttacks > 0)
        {
            percentAttacks["Heavy"] = (nbAttacks["Heavy"] / sumAttacks) * 100;
            Debug.Log((nbAttacks["Heavy"] / sumAttacks) * 100);
            return percentAttacks["Heavy"];
        }
        else
        {
            return 0;
        }
    }
    public float CalculatePercentParade()
    {
        float sumAttacks = nbAttacks.Values.Sum();
        if (sumAttacks > 0)
        {
            percentAttacks["Parade"] = (nbAttacks["Parade"] / sumAttacks) * 100;
            Debug.Log((nbAttacks["Parade"] / sumAttacks) * 100);
            return percentAttacks["Parade"];
        }
        else
        {
            return 0;
        }
    }

}

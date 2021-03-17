using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharacterModel", menuName ="Character")]
public class CharactersModel : ScriptableObject
{
    public string name;
    public float attack;
    public float range;
    public float hp;
    public GameObject character;
}

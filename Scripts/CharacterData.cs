using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Character Data")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string characterClass;

    [SerializeField] private int health, damage, speed;

    // Getters
    public string CharacterClass { get { return characterClass; } }
    public int Health { get { return health; } }
    public int Damage { get { return damage; } }
    public int Speed { get { return speed; } }


}

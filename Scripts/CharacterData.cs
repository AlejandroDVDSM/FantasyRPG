using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Character Data")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string characterClass;

    [SerializeField] private int health, damage;

    [SerializeField] private float speed;

    // Getters
    public string CharacterClass { get { return characterClass; } }

    public int Health { get { return health; } }

    public int Damage { get { return damage; } }

    public float Speed { get { return speed; } }
}

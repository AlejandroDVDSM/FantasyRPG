using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Data", menuName = "Monster Data")]
public class MonsterData : ScriptableObject
{
    [SerializeField] private string monsterName;

    [SerializeField] private int health, damage;

    [SerializeField] private float speed;

    [SerializeField] private float attackRange;

    [SerializeField] private float cooldownAttack;

    // Getters
    public string MonsterName { get { return monsterName; } }

    public int Health { get { return health; } }

    public int Damage { get { return damage; } }

    public float Speed { get { return speed; } }

    public float AttackRange { get { return attackRange; } }

    public float CooldownAttack { get => cooldownAttack; }
}

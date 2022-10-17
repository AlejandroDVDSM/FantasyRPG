using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICombatBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private MonsterData monsterData;

    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = monsterData.Health;
    }

    /**
     * This method will reduce enemy's health
     */
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("TakeHit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("isDead", true);
        
        // Disable the component that we don't need anymore
        GetComponent<Collider2D>().enabled = false; // hitbox
        GetComponent<Rigidbody2D>().isKinematic = true; // gravity
        GetComponent<EnemyAttack>().enabled = false; // follow player behaviour
        this.enabled = false;
    }
}

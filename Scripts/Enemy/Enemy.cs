using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ILife
{

    [SerializeField] private Animator animator;
    [SerializeField] private MonsterData monsterData;

    private int currentHealth;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = monsterData.Health;
        audioManager = FindObjectOfType<AudioManager>();

        FaceTowardsThePlayer();
    }

    void FaceTowardsThePlayer()
    {
        if (transform.position.x > 0) // If the enemy is in the right, face where the player is: at his left
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
        }
    }

    /**
     * This method will reduce enemy's health
     */
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("TakeHit");
        audioManager.Play("EnemyHit");

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("IsDead", true);
        audioManager.Play("EnemyDeath");
        
        // Disable the component that we don't need anymore
        GetComponent<Collider2D>().enabled = false; // hitbox
        GetComponent<Rigidbody2D>().isKinematic = true; // gravity
        GetComponent<EnemyAttack>().enabled = false; // follow player behaviour
        this.enabled = false;
    }
}

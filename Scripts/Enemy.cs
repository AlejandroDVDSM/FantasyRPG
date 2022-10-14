using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private CharacterData characterData;

    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = characterData.Health;
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

    void Die()
    {
        animator.SetBool("isDead", true);

        // Disable the hitbox and then the gameobject itself
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}

using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ILife
{

    [SerializeField] private Animator animator;
    [SerializeField] private CharacterData characterData;

    private void Start()
    {
        currentHealth = characterData.Health;
    }

    /**
     * This method will reduce player health
     */
    private int currentHealth;
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
        animator.SetBool("IsDead", true);

        // Disable the component that we don't need anymore
        GetComponent<Collider2D>().enabled = false; // hitbox
        GetComponent<Rigidbody2D>().isKinematic = true; // gravity
        GetComponent<PlayerController>().enabled = false; // movement
        this.enabled = false;
    }

}

using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ILife
{

    [SerializeField] private Animator animator;
    [SerializeField] private CharacterData characterData;

    private BlockAttacks blockAttacks;

    private int currentHealth;
    private bool takeHit = false;

    private AudioManager audioManager;

    public bool TakeHit { get => takeHit; }

    private void Start()
    {
        currentHealth = characterData.Health;

        blockAttacks = GetComponent<BlockAttacks>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    /**
     * This method will reduce player health when an enemy hits him
     */
    public void TakeDamage(int damage)
    {
        takeHit = true;
        animator.SetTrigger("TakeHit");

        if (blockAttacks != null && blockAttacks.IsBlocking)
        {
            audioManager.Play("ShieldBlocking");
            currentHealth -= damage / 2;
        } else
        {
            audioManager.Play("PlayerHit");
            currentHealth -= damage;
        }

        if (currentHealth <= 0)
        {
            Die();
            GameObject.Find("GameOverManager").GetComponent<TriggerGameOver>().TriggerGameOverScreen();
        }

        takeHit = false;
    }

    public void Die()
    {
        animator.SetBool("IsDead", true);
        audioManager.Play("PlayerDeath");

        // Disable the component that we don't need anymore
        GetComponent<Collider2D>().enabled = false; // hitbox
        GetComponent<Rigidbody2D>().isKinematic = true; // gravity
        GetComponent<PlayerController>().enabled = false; // movement
        this.enabled = false;
    }

}

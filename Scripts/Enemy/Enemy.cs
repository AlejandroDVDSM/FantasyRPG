using DefaultNamespace;
using System.Collections;
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

        StartCoroutine(DestroyCorpse());
    }

    private IEnumerator DestroyCorpse()
    {
        DisableEnemy();

        yield return new WaitForSeconds(7);

        Destroy(gameObject);
    }

    private void DisableEnemy()
    {
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();

        // Disable all scripts attached to the enemies
        foreach (var script in scripts)
        {
            script.enabled = false;
        }

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true; // gravity
        this.enabled = false;
    }
}

using DefaultNamespace;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, ILife
{
    [SerializeField] private Animator animator;
    [SerializeField] private MonsterData monsterData;

    private int currentHealth;
    private AudioManager audioManager;

    private SpriteRenderer spriteRenderer;
    private Color startColor;
    private Color endColor;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = monsterData.Health;
        audioManager = FindObjectOfType<AudioManager>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        endColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
    }

    /**
     * This method will reduce enemy's health
     */
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("TakeHit");
        audioManager.Play("EnemyHit");

        currentHealth -= damage;

        if (currentHealth <= 0 && !isDead)
        {
            Die();
            FindObjectOfType<Score>().AddPoint();
        }
    }

    public void Die()
    {
        animator.SetBool("IsDead", true);
        isDead = true;
        audioManager.Play("EnemyDeath");
        StartCoroutine(DestroyCorpse());
    }

    private IEnumerator DestroyCorpse()
    {
        DisableEnemy();

        yield return new WaitForSeconds(4);

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

        GetComponent<Enemy>().enabled = true;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true; // gravity
        //this.enabled = false;
    }

    private void Update()
    {
        if(isDead)
        {
            spriteRenderer.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * 1, 1));

        }
    }
}

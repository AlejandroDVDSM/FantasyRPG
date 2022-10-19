using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class MagicPush : MonoBehaviour
{
    
    [SerializeField] private Animator animator;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    
    [SerializeField] private float magicKnockback;

    private PlayerController playerController;

    private AudioManager audioManager;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    /**
     * This method will push enemies
     */
    public void OnSpecialMovement(InputAction.CallbackContext context)
    {
        // With this "if" we will avoid the trigger twice behaviour
        if (context.performed)
        {
            animator.SetTrigger("MagicPush");
            audioManager.Play("MagicPush");
        }
    }

    /**
     * This method is called by Animation Events
     */
    public void MagicHit()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(2);

            MagicKnockback(enemy);

        }
    }

    /**
     * This method will push enemies away
     */
    private void MagicKnockback(Collider2D enemy) 
    {
        enemy.GetComponent<Enemy>().transform.position += playerController.FacingRight
            ? new Vector3(magicKnockback, 0, 0)
            : new Vector3(-magicKnockback, 0, 0);

    }
}

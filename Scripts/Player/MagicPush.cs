using UnityEngine;
using UnityEngine.InputSystem;

public class MagicPush : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool isMagiclyPushing = false;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    
    [SerializeField] private float magicKnockback;

    private PlayerController playerController;

    private AudioManager audioManager;

    public bool IsMagiclyPushing { get => isMagiclyPushing; }

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
        var isAttacking = GetComponent<PlayerAttack>().IsAttacking;
        // With this "if" we will avoid the trigger twice behaviour
        if (context.performed && isMagiclyPushing == false && isAttacking == false)
        {
            isMagiclyPushing = true;
            playerController.enabled = false;
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

    private void StopMagiclyPushing()
    {
        playerController.enabled = true;
        isMagiclyPushing = false;
    }
}

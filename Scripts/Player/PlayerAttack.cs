using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private PlayerController playerController;
    private AudioManager audioManager;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private float knockback;
    private bool isAttacking = false;

    [SerializeField] private CharacterData characterData;

    public bool IsAttacking { get => isAttacking; }

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        audioManager = FindObjectOfType<AudioManager>();
    }

    /**
     * OnAttack1 only trigger the animation of the attack
     */
    public void OnAttack1(InputAction.CallbackContext context)
    {
        var isMagiclyPushing = false;
        if (GetComponent<MagicPush>() != null)
        {
            isMagiclyPushing = GetComponent<MagicPush>().IsMagiclyPushing;
        }

        var isRolling = false;
        if (GetComponent<Roll>() != null)
        {
            isRolling = GetComponent<Roll>().IsRolling;
        }

        var isBlocking = false;
        if (GetComponent<BlockAttacks>() != null)
        {
            isBlocking = GetComponent<BlockAttacks>().IsBlocking;
        }

        // With this "if" we will avoid the trigger twice behaviour
        if (context.performed && !isAttacking && !isMagiclyPushing && !isBlocking && !isRolling && !playerController.IsJumping)
        {
            isAttacking = true;
            playerController.enabled = false;
            audioManager.Play("SwordAttack");
            animator.SetTrigger("Attack1");
        }
    }

    /**
     * This method is called by Animation Events
     */
    public void HitEnemies()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(characterData.Damage);
            KnockBack(enemy);
        }
    }

    /**
     * This method is called by Animation Events
     */
    public void StopAttacking()
    {
        isAttacking = false;
        playerController.enabled = true;
    }

    /**
     * This method will push enemies away
     */
    private void KnockBack(Collider2D enemy)
    {
        enemy.GetComponent<Enemy>().transform.position += playerController.FacingRight
            ? new Vector3(knockback, 0, 0)
            : new Vector3(-knockback, 0, 0);

    }

    /**
     * This method will draw the gizmos of the attack in the Unity Editor
    */
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

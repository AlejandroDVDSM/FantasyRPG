using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour, IHitEnemies
{
    [SerializeField] private Animator animator;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;

    [SerializeField] private CharacterData characterData;

    [SerializeField] private float knockback;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    /**
     * OnAttack1 only trigger the animation of the attack
     */
    public void OnAttack1(InputAction.CallbackContext context)
    {
        // With this "if" we will avoid the trigger twice behaviour
        if (context.performed) 
        {
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

            if (playerController.FacingRight)
            {
                enemy.GetComponent<Enemy>().transform.position += new Vector3(knockback, 0, 0); // This will push the enemy to the right after taking the hit
            }
            else
            {
                enemy.GetComponent<Enemy>().transform.position += new Vector3(-knockback, 0, 0); // This will push the enemy to the right after taking the hit
            }
        }
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

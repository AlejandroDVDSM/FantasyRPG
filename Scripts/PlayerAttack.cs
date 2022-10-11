using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
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
    void OnAttack1()
    {
        animator.SetTrigger("Attack1");
    }

    /**
     * This method is called by Animation Events
     */
    void InflictDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(characterData.Damage);

            enemy.GetComponent<Enemy>().transform.position += new Vector3(knockback, 0, 0); // This will push the enemy after taking the hit
            // HAY QUE SOLUCIONAR LO DEL KNOCBACK. SI GOLPEO A UN ENEMIGO A MI IZQUIERDA, DEBERÍA EMPUJAR A LA IZQUIERDA, NO A LA DERECHA
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

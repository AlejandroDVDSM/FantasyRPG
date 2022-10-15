using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class MagicPush : MonoBehaviour, IHitEnemies
{
    
    [SerializeField] private Animator animator;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    
    [SerializeField] private float magicKnockback;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
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
            enemy.GetComponent<Enemy>().TakeDamage(2);

            enemy.GetComponent<Enemy>().transform.position += playerController.FacingRight
                ? new Vector3(magicKnockback, 0, 0)
                : new Vector3(-magicKnockback, 0, 0);
        }
    }
}

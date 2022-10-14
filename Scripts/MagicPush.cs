using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagicPush : MonoBehaviour
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

    public void OnSpecialMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetTrigger("MagicPush");
            
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                if (playerController.FacingRight)
                {
                    enemy.GetComponent<Enemy>().transform.position += new Vector3(magicKnockback, 0, 0);
                }
                else
                {
                    enemy.GetComponent<Enemy>().transform.position += new Vector3(-magicKnockback, 0, 0);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private Vector3 movement;
    [SerializeField] private float jumpForce;

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private CharacterData characterData;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMove(InputValue value)
    {
        animator.SetFloat("Speed", Mathf.Abs(value.Get<Vector2>().x));

        if (value.Get<Vector2>().x < 0)
        {
            spriteRenderer.flipX = true;
        } else
        {
            spriteRenderer.flipX = false;
        }

        movement = new Vector3(value.Get<Vector2>().x, 0, 0);
    }

    void OnJump()
    {
        if (IsGrounded())
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnAttack()
    {
        animator.SetTrigger("Attack1");

        
    }

    private void Update()
    {
        transform.position += movement * characterData.Speed * Time.deltaTime;
    }

    bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);
        return raycastHit2D.collider != null;
    }

    void InflictDamage()
    { // This method will be activated by Animation Events

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(characterData.Damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

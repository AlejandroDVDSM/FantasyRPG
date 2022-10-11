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

    [SerializeField] private CharacterData characterData;

    private bool facingRight = true;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMove(InputValue value)
    {
        animator.SetFloat("Speed", Mathf.Abs(value.Get<Vector2>().x));

        if (value.Get<Vector2>().x < 0 && facingRight)
        { // If the player is moving left BUT is facing right, then flip the player to the left
            FlipPlayer();
        } else if (value.Get<Vector2>().x > 0 && !facingRight)
        { // If the player is moving right BUT is facing left, then flip the player to the right
            FlipPlayer();
        }

        movement = new Vector3(value.Get<Vector2>().x, 0, 0);
    }

    void FlipPlayer()
    {
        Vector3 currennScale = transform.localScale;
        currennScale.x *= -1;
        transform.localScale = currennScale;

        facingRight = !facingRight;
    }

    void OnJump()
    {
        if (IsGrounded())
        {
            animator.SetBool("IsJumping", true);
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);
        return raycastHit2D.collider != null;
    }

    void isLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void Update()
    {
        transform.position += movement * characterData.Speed * Time.deltaTime;
    }
}
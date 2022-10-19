using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private AudioManager audioManager;

    [SerializeField] private Animator animator;

    private Vector3 movement;
    private bool facingRight = true;

    [SerializeField] private float jumpForce;

    [SerializeField] private LayerMask groundLayerMask;

    [SerializeField] private CharacterData characterData;

    // Getters
    public bool FacingRight { get => facingRight; }
    public Vector3 Movement { get => movement; }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var horizontalAxisValue = context.ReadValue<Vector2>().x;

        animator.SetFloat("Speed", Mathf.Abs(horizontalAxisValue));

        if (horizontalAxisValue < 0 && facingRight)
        { // If the player is moving left BUT is facing right, then flip the player to the left
            FlipPlayer();
        } else if (horizontalAxisValue > 0 && !facingRight)
        { // If the player is moving right BUT is facing left, then flip the player to the right
            FlipPlayer();
        }

        movement = new Vector3(horizontalAxisValue, 0, 0);
    }

    /**
     * FlipPlayer will change the scale of the player to change the direction in which the sprite is facing
     */
    void FlipPlayer()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    public void OnJump(InputAction.CallbackContext _)
    {
        if (IsGrounded())
        {
            animator.SetBool("IsJumping", true);
            audioManager.Play("PlayerJump");
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    /**
     * This method check if the player is in the ground or not
     */
     public bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);
        return raycastHit2D.collider != null;
    }

    /**
     * This method is called by Animation Events
     */
    void IsLanded()
    {
        animator.SetBool("IsJumping", false);
        audioManager.Play("PlayerLanding");
    }

    private void Update()
    {
        transform.position += movement * (characterData.Speed * Time.deltaTime);
    }
}
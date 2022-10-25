using UnityEngine;
using UnityEngine.InputSystem;

public class AvoidAttacks : MonoBehaviour
{

    private Color spriteWhileIdle;
    private Color spriteWhileAvoiding;

    private SpriteRenderer spriteRenderer;
    private Collider2D collider2d;
    private Rigidbody2D rigidbody2d;

    private PlayerAttack playerAttack;
    private MagicPush magicPush;

    private bool isAvoiding;

    public bool IsAvoiding { get => isAvoiding; }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        playerAttack = GetComponent<PlayerAttack>();
        magicPush = GetComponent<MagicPush>();


        spriteWhileIdle = spriteRenderer.color;
        spriteWhileAvoiding = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, .4f);
    }

    public void OnAvoid(InputAction.CallbackContext context)
    {
        if (!playerAttack.IsAttacking && !magicPush.IsMagiclyPushing)
        {
            isAvoiding = true;

            spriteRenderer.color = spriteWhileAvoiding;
            collider2d.enabled = false;
            rigidbody2d.isKinematic = true;

            if (context.canceled)
            {
                spriteRenderer.color = spriteWhileIdle;
                collider2d.enabled = true;
                rigidbody2d.isKinematic = false;

                isAvoiding = false;
            }
        }
    }
}

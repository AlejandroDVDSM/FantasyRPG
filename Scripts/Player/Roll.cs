using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Roll : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private PlayerController playerController;

    [SerializeField] private Animator animator;
    [SerializeField] private float rollForce;

    private bool isRolling = false;

    private AudioManager audioManager;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnSpecialMovement(InputAction.CallbackContext context)
    {
        if (playerController.IsGrounded() && CanRoll())
        {
            animator.SetBool("IsRolling", true);
            audioManager.Play("PlayerRolling");
            Physics2D.IgnoreLayerCollision(gameObject.layer, 7);

            if (playerController.FacingRight && context.started) // If it is facing right
            {
                rigidbody2D.AddForce(Vector2.right * rollForce, ForceMode2D.Impulse);
            }
            else if (!playerController.FacingRight && context.started) // If it is facing left
            {
                rigidbody2D.AddForce(Vector2.left * rollForce, ForceMode2D.Impulse);
            }
            isRolling = true;
        }
    }

    /**
     * This method is called by Animation Events
     */
    public void StopRolling()
    {
        animator.SetBool("IsRolling", false);
        isRolling = false;
        Physics2D.IgnoreLayerCollision(gameObject.layer, 7, false);
    }


    /**
     * This method will check if the player is rolling
     */
    bool CanRoll()
    {
        if (!isRolling && playerController.Movement.x != 0)
        {
            return true;
        }

        return false;
    }
}

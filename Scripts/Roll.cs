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

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    public void OnSpecialMovement(InputAction.CallbackContext context)
    {
        if (playerController.IsGrounded() && canRoll())
        {
            if (playerController.FacingRight && context.started) // If it is facing right
            {
                rigidbody2D.AddForce(Vector2.right * rollForce, ForceMode2D.Impulse);
                animator.SetBool("IsRolling", true);
            }
            else if (!playerController.FacingRight && context.started) // If it is facing left
            {
                rigidbody2D.AddForce(Vector2.left * rollForce, ForceMode2D.Impulse);
                animator.SetBool("IsRolling", true);
            }
            isRolling = true;
        }
    }

    /**
     * This method is called by Animation Events
     */
    public void stopRolling()
    {
        animator.SetBool("IsRolling", false);
        isRolling = false;
    }


    /**
     * This method will check if the player is rolling
     */
    bool canRoll()
    {
        if (!isRolling && playerController.Movement.x != 0)
        {
            return true;
        }

        return false;
    }
}

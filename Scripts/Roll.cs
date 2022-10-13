using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnSpecialMovement()
    {
        // Arreglos necesarios: que no pueda cambiar la dirección mientras rueda
        // Que le tengas que dar dos veces Shift
        if(canRoll() && playerController.IsGrounded())
        {
            if (playerController.FacingRight && playerController.Movement.x != 0)
            {
                rigidbody2D.AddForce(Vector2.right * rollForce, ForceMode2D.Impulse);
                animator.SetTrigger("Roll");
            } else if (!playerController.FacingRight && playerController.Movement.x != 0)
            {
                rigidbody2D.AddForce(Vector2.left * rollForce, ForceMode2D.Impulse);
                animator.SetTrigger("Roll");
            }
            isRolling = true;
        } else
        {
            isRolling = false;
        }
    }

    bool canRoll()
    {
        if (!isRolling)
        {
            return true;
        }

        //isRolling = false;
        return false;
    }
}

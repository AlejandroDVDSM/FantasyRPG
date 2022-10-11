using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private PlayerController playerController;

    [SerializeField] private Animator animator;
    [SerializeField] private float force;

    private bool canRoll = true;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    void OnSpecialMovement()
    {
        // HAY QUE IMPLEMENTAR QUE SOLO SE PUEDA RODAR SI NO SE ESTÁ RODANDO PREVIAMENTE
        if (playerController.FacingRight && playerController.Movement.x != 0)
        {
            animator.SetTrigger("Roll");
            rigidbody2D.AddForce(Vector2.right * force, ForceMode2D.Impulse);
        } else if (!playerController.FacingRight && playerController.Movement.x != 0)
        {
            animator.SetTrigger("Roll");
            rigidbody2D.AddForce(Vector2.left * force, ForceMode2D.Impulse);
        }
    }
}

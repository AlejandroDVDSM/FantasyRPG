using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlockAttacks : MonoBehaviour
{

    [SerializeField] private Animator animator;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        animator.SetBool("IsBlocking", true);
        playerController.enabled = false;
        if (context.canceled)
        {
            StopBlocking();
        }
    }

    void StopBlocking()
    {
        animator.SetBool("IsBlocking", false);
        playerController.enabled = true;
    }
}

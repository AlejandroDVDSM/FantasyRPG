using UnityEngine;
using UnityEngine.InputSystem;

public class BlockAttacks : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Player player;
    private PlayerController playerController;
    private Roll roll;

    private bool isBlocking = false;
    private bool isMoving = false;
    public bool IsBlocking { get => isBlocking; }

    private void Awake()
    {
        player = GetComponent<Player>();
        playerController = GetComponent<PlayerController>();
        roll = GetComponent<Roll>();
    }

    private void Update()
    {
        if (player.TakeHit)
        {
            animator.SetTrigger("TakeHit");
        }

        if (playerController.Movement.x != 0 )
        {
            isMoving = true;
        } else {
            isMoving = false;
        }
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        if (!roll.IsRolling && !playerController.IsJumping)
        {
            animator.SetBool("IsBlocking", true);
            isBlocking = true;

            playerController.enabled = false;
            animator.SetFloat("Speed", 0);

            if (context.canceled)
            {
                StopBlocking();
            }
        }
    }

    void StopBlocking()
    {
        animator.SetBool("IsBlocking", false);

        if (isMoving)
        {
            animator.SetFloat("Speed", 1);
        } else
        {
            animator.SetFloat("Speed", 0);
        }

        //animator.SetFloat("Speed", 1);
        isBlocking = false;
        playerController.enabled = true;
    }
}

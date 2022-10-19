using UnityEngine;
using UnityEngine.InputSystem;

public class BlockAttacks : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private PlayerController playerController;
    private bool isBlocking = false;

    public bool IsBlocking { get => isBlocking; }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (GetComponent<Player>().TakeHit)
        {
            animator.SetTrigger("TakeHit");
        }
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        animator.SetBool("IsBlocking", true);
        isBlocking = true;

        playerController.enabled = false;
        if (context.canceled)
        {
            StopBlocking();
        }
    }

    void StopBlocking()
    {
        animator.SetBool("IsBlocking", false);
        isBlocking = false;
        playerController.enabled = true;
    }
}

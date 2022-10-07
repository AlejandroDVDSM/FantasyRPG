using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 movement;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayerMask;

    [SerializeField] private CharacterData characterData;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        Debug.Log(PlayerPrefs.GetString("Class"));
    }

    void OnMove(InputValue value)
    {
        movement = new Vector3(value.Get<Vector2>().x, 0, 0);
        animator.SetFloat("Speed", Mathf.Abs(value.Get<Vector2>().x));
    }

    void OnJump()
    {
        if (IsGrounded())
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void onAttack() // ARREGLAR, NO PARECE QUE ENTRE A ESTE M�TODO CUANDO SE PULSA CLICK IZQUIERDO/DERECHO
    {
        Debug.Log("ataco");

        animator.SetBool("isAttacking", true);
    }

    private void Update()
    {
        transform.position += movement * characterData.Speed * Time.deltaTime;
    }

    bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);
        return raycastHit2D.collider != null;
    }
}

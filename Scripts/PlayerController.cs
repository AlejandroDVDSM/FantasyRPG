using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Vector2 movement;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        movement = new Vector2(value.Get<Vector2>().x, 0);
    }

    void OnJump()
    {
        //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Debug.Log("ESTOY SIENDO RECONOCIDO");
        rb.velocity = new Vector2(0, jumpForce);
        //transform.position += new Vector3(0, 5, 0);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * 5 * Time.fixedDeltaTime);
    }
}

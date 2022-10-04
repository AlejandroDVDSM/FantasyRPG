using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Vector2 movement;
    private Vector2 jump;
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
    { // ARREGLAR EL SALTO - POR ALGÚN CASUAL EMPLEAR Time.fixedDeltaTime lo rompe, pero sin usarlo salta DEMASIADO.
      // Probar con velocity en vez de AddForce en el método FixedUpdate()???
        jump = new Vector2(0, jumpForce);
        Debug.Log("ESTOY SIENDO RECONOCIDO");
        Debug.LogFormat("value: {0}", jumpForce);
        //rb.velocity += new Vector2(0, jumpForce);
        //transform.position += new Vector3(0, 5, 0);
    }

    private void FixedUpdate()
    {
        rb.AddForce(jump, ForceMode2D.Impulse);
        //rb.MovePosition(rb.position + movement * 5 * Time.fixedDeltaTime);
    }
}

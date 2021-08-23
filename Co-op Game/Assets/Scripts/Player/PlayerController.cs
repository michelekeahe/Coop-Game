using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D groundCheck;

    public float speed = 3.0f;
    public float jumpForce = 6.0f;
    public bool isGrounded = false;

    private bool isFacingRight = true;
    private float horizontal = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    // Jump method
    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded) rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    // Movement Method
    public void Movement(InputAction.CallbackContext context)
    {
        SetVelocity(context.ReadValue<Vector2>());
    }

    // Velocity method for movement
    public void SetVelocity(Vector2 direction)
    {
        horizontal = direction.x;
        if (horizontal < 0 && isFacingRight) Flip();
        else if (horizontal > 0 && !isFacingRight) Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground") isGrounded = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground") isGrounded = false;
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        isFacingRight = !isFacingRight;
    }
}

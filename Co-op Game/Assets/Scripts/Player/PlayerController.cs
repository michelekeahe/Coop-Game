using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Declaring components
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private BoxCollider2D interactionTrigger;
    #endregion

    #region Serialized variables
    [SerializeField]
    private float speed = 3.0f;
    #endregion

    #region Private variables
    private bool isFacingRight = true;
    private float horizontal = 0.0f;
    private Vector2 direction;
    #endregion

    public bool interacting = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    // Movement Method
    public void Movement(InputAction.CallbackContext context)
    {
        SetVelocity(context.ReadValue<Vector2>());
    }
    
    // Velocity method for movement
    public void SetVelocity(Vector2 dir)
    {
        direction = dir;
        horizontal = direction.x;
        if (horizontal < 0 && isFacingRight) Flip();
        else if (horizontal > 0 && !isFacingRight) Flip();
    }

    // Flip method
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        isFacingRight = !isFacingRight;
    }

    // Interact method to interact with objects such as doors
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            interactionTrigger.enabled = true;
        }
        else
        {
            interactionTrigger.enabled = false;
        }
    }
}

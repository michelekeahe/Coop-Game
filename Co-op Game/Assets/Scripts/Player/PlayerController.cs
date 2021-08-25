using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Decalring components
    [SerializeField]
    private Rigidbody2D rb;
    #endregion

    #region Serialzied variables
    [SerializeField]
    private float speed = 3.0f;
    #endregion

    #region Private variables
    private float horizontal = 0.0f;
    private bool isFacingRight = true;
    private Vector2 dir;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(dir * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    // Movement Method
    public void Movement(InputAction.CallbackContext context)
    {
        SetVelocity(context.ReadValue<Vector2>());
    }

    // Velocity method for movement
    public void SetVelocity(Vector2 direction)
    {
        dir = direction;
    }

    //Flip method
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        isFacingRight = !isFacingRight;

    }

}

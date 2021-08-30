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
    private string currentState = "";
    #endregion


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Moves player every frame
    private void FixedUpdate()
    {
        rb.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    // Gets the vector 2 of Movment action from new Input System and runs it through SetVelocity function
    public void ReadInput(InputAction.CallbackContext context)
    {
        SetDirection(context.ReadValue<Vector2>());
    }
    
    // Determins if player is facing left or right by reading x value of the passed Vector2
    public void SetDirection(Vector2 dir)
    {
        direction = dir;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public bool isInRange = false;
    public UnityEvent interactAction;
    
    // Interact method to interact with objects such as doors
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            Debug.Log("Interact");
            interactAction.Invoke();
        }
        else
        {
            Debug.Log("No Interact");
        }
    }
}

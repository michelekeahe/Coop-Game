using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D door;

    [SerializeField]
    private float doorOpenTime = 0f;

    private string interactionTag = "InteractionCheck";
    
    //If door tag collides with interactionCheck trigger, then OpenDoor
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == interactionTag)
        {
            OpenDoor();
        }
    }

    //Switches door to DoorOpened layer, which ignores players, the switches back to ClosedDoor layer after x seconds
    public void OpenDoor()
    {
        door.enabled = false;
        Invoke(nameof(CloseDoor), doorOpenTime);
    }

    private void CloseDoor()
    {
        door.enabled = true;
    }
}
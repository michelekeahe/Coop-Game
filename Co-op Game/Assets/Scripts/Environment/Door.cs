using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    [SerializeField]
    private float doorOpenTime = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "InteractionCheck")
        {
            OpenDoor();
        }

    }


    public void OpenDoor()
    {
        this.gameObject.layer = LayerMask.NameToLayer("DoorOpened");
        Invoke(nameof(CloseDoor), doorOpenTime);
    }

    private void CloseDoor()
    {
        this.gameObject.layer = LayerMask.NameToLayer("DoorClosed");
    }


}

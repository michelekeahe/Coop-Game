using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Ensures that everytime this class is lauched, it calls the new Unity Input System
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Declaring object. PlayerInputAction can be found in InputAction folder.
    private PlayerInputAction playerInputAction;

    private void Awake()
    {
        //Instantiates object.
        playerInputAction = new PlayerInputAction();
    }

    //No clue what this does.
    private void OnEnable()
    {
        playerInputAction.Enable();
    }

    //No clue what this does.
    private void OnDisable()
    {
        playerInputAction.Disable();
    }

    private void Update()
    {
        
    }

}

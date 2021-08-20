using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Ensures that everytime this class is lauched, it calls the new Unity Input System
using UnityEngine.InputSystem;


public class Combat : MonoBehaviour
{
    //Declaring object. PlayerInputAction can be found in InputAction folder.
    private PlayerInputAction playerInputAction;

    //Declaring bullet. Instantiation made in Unity Hub
    [SerializeField]
    private GameObject bullet;
    //Declaring position of firepoint. Instantiation made in Unity Hub.
    [SerializeField]
    private Transform firePoint;
    //Declaring value used for determining bullet spped. Instantiated in Unity Hub.
    [SerializeField]
    private int bulletSpeed;

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

    private void Start()
    {
        //When player clicks Shoot input, then call Shoot function.
        playerInputAction.Land.Shoot.performed += _ => Shoot();   
    }

    //Summons and launches bullet PreFab.
    private void Shoot()
    {
        GameObject spawnedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);

    }
}

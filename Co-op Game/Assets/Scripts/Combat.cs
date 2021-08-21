using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Combat : MonoBehaviour
{
    public Bullet bulletPrefab;

    // Declaring object. PlayerInputAction can be found in InputAction folder.
    private PlayerInputAction playerInputAction;
    
    [SerializeField]
    private Transform firePoint;

    private void Awake()
    {
        // Instantiates object.
        playerInputAction = new PlayerInputAction();

    }
     
    // No clue what this does.
    private void OnEnable()
    {
        playerInputAction.Enable();
    }

    // No clue what this does.
    private void OnDisable()
    {
        playerInputAction.Disable();
    } 

    private void Start()
    {
        // When player clicks Shoot input, then call Shoot function.
        playerInputAction.Land.Shoot.performed += _ => Shoot();   
    }

    // Summons and launches bullet PreFab.
    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.Project(this.transform.up);
    }
}

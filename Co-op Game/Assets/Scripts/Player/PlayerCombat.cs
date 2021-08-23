using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCombat : MonoBehaviour
{
    public PlayerBullet bulletPrefab;

    // Declaring object. PlayerInputAction can be found in InputAction folder.
    private PlayerInputAction controls;
    
    [SerializeField]
    private Transform firePoint;

    private Camera mainCam;
    private float angle = 0f;
    private float maxAngle = 45f;
    private float minAngle = -45f;

    private void Awake()
    {
        // Instantiates object.
        controls = new PlayerInputAction();

    }

    private void Start()
    {
        mainCam = Camera.main;

        // When player clicks Shoot input, then call Shoot function in Bullet class.
        controls.Land.Shoot.performed += _ => bulletPrefab.Shoot(firePoint);
    }

    private void Update()
    {
        Vector2 mouseScreenPosition = controls.Land.MousePosition.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = mainCam.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 targetDirection = mouseWorldPosition - transform.position;
        angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        Debug.Log(angle);
        // Limit arm angle for shooting
        if ((angle <= maxAngle) && (angle >= minAngle))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
    }

    private void PlayerShoot()
    {
        Vector2 mousePosition = controls.Land.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        bulletPrefab.Shoot(firePoint);
    }

    // No clue what this does.
    private void OnEnable()
    {
        controls.Enable();
    }

    // No clue what this does.
    private void OnDisable()
    {
        controls.Disable();
    } 
}

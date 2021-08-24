using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCombat : MonoBehaviour
{
    public PlayerBullet bulletPrefab;

    // Declaring object. PlayerInputAction can be found in InputAction folder.
    private PlayerInputAction controls;
    private PlayerController controller = new PlayerController();
    
    [SerializeField]
    private Transform firePoint;
    
    private Camera mainCam;
    private float angle = 0f;
    private float maxAngle = 45f;
    private float minAngle = -45f;
    public float aimSpeed = 0;
    

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

    private void FixedUpdate()
    {
        FollowMouse();
        
    }

    private void FollowMouse()
    {
        Vector2 mouseScreenPosition = controls.Land.MousePosition.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = mainCam.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 targetDirection = mouseWorldPosition - transform.position;
        angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;


        float tz = mouseWorldPosition.y * aimSpeed;

        // Limit arm angle for shooting
        //if ((angle <= maxAngle) && (angle >= minAngle))
        //{
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, tz));

            
        //}
      


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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCombat : MonoBehaviour
{
    #region Declaring class
    // Declaring object. PlayerInputAction can be found in InputAction folder.
    private PlayerInputAction controls;
    #endregion

    #region Declaring component
    [SerializeField] private PlayerBullet bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private BoxCollider2D meleePoint;
    private Camera mainCam;
    #endregion

    #region Variables
    public int currentAmmo = 25;
    public int maxAmmo = 50;
    private float angle = 0f;
    public float aimSpeed = 0;
    #endregion

    private void Awake()
    {
        // Instantiates object.
        controls = new PlayerInputAction();
    }

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        FollowMouse();
    }

    // ======================
    // SHOOT
    // ======================

    public void Shoot(InputAction.CallbackContext inputType)
    {
        bool FireStart = inputType.started;

        // Shoot bullet from firepoint & lose ammo per shot
        if (FireStart && currentAmmo > 0)
        {
            bulletPrefab.Shoot(firePoint);
            currentAmmo--;
        }
    }

    // Rotates gun in direction of mouse
    private void FollowMouse()
    {
        Vector2 mouseScreenPosition = controls.Land.MousePosition.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = mainCam.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 targetDirection = mouseWorldPosition - transform.position;
        angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    // ======================
    // MELEE
    // ======================

    public void Melee(InputAction.CallbackContext inputType)
    {
        // When hit melee keybind, enable collider and then disable.
        if (inputType.started || inputType.performed)
        {
            meleePoint.enabled = true;
        } else {
            meleePoint.enabled = false;
        }
    }

    // ======================
    // IDK
    // ======================

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

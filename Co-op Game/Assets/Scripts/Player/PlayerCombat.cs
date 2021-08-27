using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCombat : MonoBehaviour
{
    #region Declaring script
    // Declaring object. PlayerInputAction can be found in InputAction folder.
    private PlayerInputAction controls;
    #endregion

    #region Declaring component
    [SerializeField]
    private PlayerBullet bulletPrefab;
    [SerializeField]
    private Transform firePoint;
    private Camera mainCam;
    #endregion

    #region Private Variables
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

    public void Shoot(InputAction.CallbackContext inputType)
    {
        bool Fire = inputType.started;
        if (Fire)
        {
            bulletPrefab.Shoot(firePoint);
        }
    }

    private void FixedUpdate()
    {
        FollowMouse();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 3;
    private float invinsibilityTime = 3.0f;
    private float inactiveTime = 2.0f;
    [SerializeField]
    private PlayerController movement;
    [SerializeField]
    private PlayerCombat combat;


    // When player runs into enemy, player becomes invincible for a period of time and loses 1 health.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            this.gameObject.layer = LayerMask.NameToLayer("Invinicibility");
            movement.enabled = false;
            combat.enabled = false;
            health -= 1;

            Invoke(nameof(TurnOnMovement), inactiveTime);

            // Returns to regular collision layer after 3 seconds.
            Invoke(nameof(TurnOnCollisionsAndCombat), invinsibilityTime);
            Debug.Log(health);
        }
    }

    private void TurnOnCollisionsAndCombat()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Player");
        combat.enabled = true;

    }

    private void TurnOnMovement()
    {
        movement.enabled = true;
    }
}

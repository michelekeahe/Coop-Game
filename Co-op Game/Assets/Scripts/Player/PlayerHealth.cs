using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 3;
    private float invinsibilityTime = 3.0f;

    // When player runs into enemy, player becomes invincible for a period of time and loses 1 health.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            this.gameObject.layer = LayerMask.NameToLayer("Invinicibility");
            health -= 1;

            // Returns to regular collision layer after 3 seconds.
            Invoke(nameof(TurnOnCollisions), invinsibilityTime);
            Debug.Log(health);
        }
    }

    private void TurnOnCollisions()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Player");
    }
}

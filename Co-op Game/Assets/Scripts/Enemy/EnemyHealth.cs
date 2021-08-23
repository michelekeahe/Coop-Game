using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 3;

    public int bulletDamage = 1;

    // If bullet touches enemy, enemy's health goes down by 1.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            // Reduce health by 1 point
            maxHealth -= bulletDamage;

            // If enemy's health reduced to 0 or below, destroy GameObject (enemy death).
            if (maxHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float knockbackForce = 4f;
    public int bulletDamage = 1;
    public int meleeDamage = 1;

    private string playerBulletTag = "PlayerBullet";
    private string playerMeleeTag = "PlayerMelee";
    
    // If bullet touches enemy, enemy's health goes down by 1.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Shooting damage
        if (collision.gameObject.tag == playerBulletTag)
        {
            TakeDamage(bulletDamage);
        }

        // Melee damage
        if (collision.gameObject.tag == playerMeleeTag)
        {
            TakeDamage(meleeDamage);
        }
    }

    // Take Damage function
    private void TakeDamage(int damageDone)
    {
        Knockback(this.transform);

        // Reduce health by damage taken
        this.maxHealth -= damageDone;

        // If enemy's health reduced to 0 or below, destroy GameObject (enemy death).
        if (this.maxHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Knockback when damaged
    private void Knockback(Transform obj)
    {
        Vector3 direction = (obj.transform.position).normalized;

        rb.AddForce(direction * this.knockbackForce, ForceMode2D.Impulse);
    }
}

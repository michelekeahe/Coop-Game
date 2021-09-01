using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Components
    public Image[] healthPoints;
    [SerializeField] Rigidbody2D rb;

    // Variables
    [SerializeField] private int health = 10;
    [SerializeField] private float invincibilityLifetime = 3.0f;
    [SerializeField] private float knockbackForce = 4f;

    // Tags and layers
    private string enemyTag = "Enemy";
    private string enemyBulletTag = "EnemyBullet";
    private string invincibilityLayer = "Invincibility";
    private string playerLayer = "Player";
    
    // When player runs into enemy, player becomes invincible for a period of time and loses 1 health.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == enemyTag || collision.gameObject.tag == enemyBulletTag)
        {
            Knockback(this.transform);

            //Turns layer to "Invincibility"
            //this.gameObject.layer = LayerMask.NameToLayer(invincibilityLayer);
            //reduces health
            health -= 1;

            //Updates HealthBar
            HealthBarFiller();
            
            // Returns to regular collision layer after x seconds.
            //Invoke(nameof(TurnOnCollisionsAndCombat), invincibilityLifetime);
        }
    }

    // Puts player layer back on player
    private void TurnOnCollisionsAndCombat()
    {
        this.gameObject.layer = LayerMask.NameToLayer(playerLayer);
    }
    
    //Fills health bar
    private void HealthBarFiller()
    {
        //Adds/subtracts health points so long as index of healthpoint is above 0 and equal to or below 10(max health bars)
        for (int i = 0; i < healthPoints.Length; i++)
        {
            // If the return function is true, make it false.
            // If arraylength is < health, then enable that image
            healthPoints[i].enabled = !DisplayHealthPoint(health, i);
        }
    }

    //If aray length is >= health, then return true.
    private bool DisplayHealthPoint(float health, int pointNumber)
    {
        return ((pointNumber) >= health);
    }

    // Knockback when damaged
    private void Knockback(Transform obj)
    {
        Vector3 direction = (obj.transform.position).normalized;

        rb.AddForce(direction * this.knockbackForce, ForceMode2D.Impulse);
    }
}

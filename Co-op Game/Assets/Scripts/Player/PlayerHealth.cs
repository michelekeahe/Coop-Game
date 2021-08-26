using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Scripts
    [SerializeField]
    private PlayerController movement;
    [SerializeField]
    private PlayerCombat combat;
    #endregion

    #region Serialized variables
    [SerializeField]
    private int health = 3;
    [SerializeField]
    private float invinsibilityTime = 3.0f;
    [SerializeField]
    private float inactiveTime = 2.0f;
    #endregion

    #region Tags and Layers
    private string enemyTag = "Enemy";
    private string enemyBulletTag = "EnemyBullet";
    private string invincibilityLayer = "Invinicibility";
    private string playerLayer = "Player";
    #endregion

    // When player runs into enemy, player becomes invincible for a period of time and loses 1 health.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == enemyTag || collision.gameObject.tag == enemyBulletTag)
        {
            //Turns layer to "Invincibility"
            this.gameObject.layer = LayerMask.NameToLayer(invincibilityLayer);
            //disables movement and combat
            movement.enabled = false;
            combat.enabled = false;
            //reduces health
            health -= 1;

            //Turns movement on after x seconds
            Invoke(nameof(TurnOnMovement), inactiveTime);

            // Returns to regular collision layer after x seconds.
            Invoke(nameof(TurnOnCollisionsAndCombat), invinsibilityTime);

            Debug.Log(health);
        }
    }

    //Allows for shooting and puts player layer back on player
    private void TurnOnCollisionsAndCombat()
    {
        this.gameObject.layer = LayerMask.NameToLayer(playerLayer);
        combat.enabled = true;
    }

    //enables movmement.
    private void TurnOnMovement()
    {
        movement.enabled = true;
    }
}

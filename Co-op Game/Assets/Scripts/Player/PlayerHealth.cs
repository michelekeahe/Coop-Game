using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Scripts
    [SerializeField]
    private PlayerController movement;
    [SerializeField]
    private PlayerCombat combat;
    #endregion

    #region Component
    [SerializeField]
    public Image[] healthPoints;
    #endregion

    #region Serialized variables
    [SerializeField]
    private int health = 10;
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
            //reduces health
            health -= 1;

            //Updates HealthBar
            HealthBarFiller();


            // Returns to regular collision layer after x seconds.
            Invoke(nameof(TurnOnCollisionsAndCombat), invinsibilityTime);

            Debug.Log(health);
        }
    }

    // Puts player layer back on player
    private void TurnOnCollisionsAndCombat()
    {
        this.gameObject.layer = LayerMask.NameToLayer(playerLayer);
    }


    #region Health Bar
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
    #endregion

    #region

    private void Update()
    {
        CountDown();
    }

    [SerializeField]
    private int seconds;
    [SerializeField]
    private int minutes;
    private int totalTime;
    private bool timerIsOn = true;

    private void CountDown()
    {
        totalTime = seconds + minutes;

        if (timerIsOn)
        {
            totalTime -= Mathf.RoundToInt(Time.deltaTime);
        }
    }

    public void StartCountDown()
    {
        timerIsOn = !timerIsOn;
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 3;

    //If bullet touches enemy, enemies health goes down by 1.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Touchdown!");
            maxHealth = maxHealth - 1;
        }

    }

    //If health =0, then destroy enemy. 
    //In fixed updates because it doens't need to update every frame.
    private void FixedUpdate()
    {
        if (maxHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Tester 

}

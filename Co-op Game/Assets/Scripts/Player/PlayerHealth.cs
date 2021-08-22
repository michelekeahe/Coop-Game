using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 3;
    EnemyMeleCombat meleAttackDelay;

    private void Start()
    {
        meleAttackDelay = new EnemyMeleCombat();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MeleEnemy")
        {
            health = health- 1;
            Debug.Log(health);
        }

    }
    


}

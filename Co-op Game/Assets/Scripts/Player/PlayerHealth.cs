using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 3;

    private void Start()
    {
    }

    //When player runs into enemy, player becomes immune to all colliders and loses 1 health.
    //Immunity is lost after x seconds
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MeleEnemy")
        {
            this.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
            health = health- 1;
            Invoke(nameof(TurnOnCollisions), 3f);
            Debug.Log(health);
        }


    }

    private void TurnOnCollisions()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Player");
    }
    


}

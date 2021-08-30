using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private PlayerCombat playerCombat;

    private string ammoTag = "Ammo";

    private int ammoPickup = 1;

    private void Start()
    {
        // add reference to player combat ammo.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ammoTag)
        {
            playerCombat.currentAmmo += 1;
        }
    }

}

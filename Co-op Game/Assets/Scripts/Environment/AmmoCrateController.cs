using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrateController : MonoBehaviour
{
    public PlayerCombat playerCombat;

    [SerializeField]
    private int ammoCount = 0;
    [SerializeField]
    private int minAmmoCount = 1;
    [SerializeField]
    private int maxAmmoCount = 5;
    private int totalAmmo = 0;

    private string interactionTag = "InteractionCheck";
    private string playerTag = "Player";
    // Declare animator

    private void Awake()
    {
       ammoCount = Random.Range(minAmmoCount, maxAmmoCount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            // Pop Up Icon: "Interact" appears
        }

        if (collision.tag == interactionTag)
        {
            OpenCrate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            // Pop Up Icon: "Interact" disappears
        }

        if (collision.tag == interactionTag)
        {
            
        }
    }

    public void OpenCrate()
    {
        totalAmmo += (playerCombat.currentAmmo + ammoCount);

        // If combined current ammo + new ammo is greater than max ammo. Lose the difference.
        // Otherwise just add the two together.
        if (totalAmmo > playerCombat.maxAmmo)
        {
            playerCombat.currentAmmo = playerCombat.maxAmmo;
            Debug.Log(playerCombat.currentAmmo);
        }
        else
        {
            playerCombat.currentAmmo += ammoCount;
            Debug.Log(playerCombat.currentAmmo);
        }

        Debug.Log("Opened Box! Gained " + ammoCount + " ammo! Total: " + totalAmmo);
        // play Box Open animation

        Destroy(this.gameObject);
    }
}

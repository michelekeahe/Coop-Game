using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 50f;
    private float bulletLifetime = 2f;
    
    // Spawns bullet. Gives it a rigid body, then launches it from firePoint.
    public void Shoot(Transform firePoint)
    {
        // Create bullet
        GameObject spawnedBullet = Instantiate(this.gameObject, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();

        // Project bullet
        rb.AddForce(firePoint.up * this.bulletSpeed, ForceMode2D.Impulse);
        Destroy(spawnedBullet, this.bulletLifetime);
    }

    // If bullet hits enemy, destory bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy") || collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}

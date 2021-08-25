using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 50f;
    private float bulletLifetime = 2f;

    // Shoot function
    public void Shoot(Transform firePoint)
    {
        // Create Bullet
        GameObject spawnedBullet = Instantiate(this.gameObject, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();

        // Project Bullet
        rb.AddForce(firePoint.up * this.bulletSpeed, ForceMode2D.Impulse);
        Destroy(spawnedBullet, this.bulletLifetime);
    }

    //Destroys bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "Ground") || (collision.gameObject.tag == "Door"))
        {
            Destroy(this.gameObject);
        }
    }
}

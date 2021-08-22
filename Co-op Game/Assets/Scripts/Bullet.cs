using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 50f;
    private float bulletLifetime = 2f;


    private void Awake()
    {

    }

    // Spawns bullet. Gives it a rigid body, then launches it from firePoint.
    public void Shoot(Transform firePoint)
    {
        GameObject spawnedBullet = Instantiate(this.gameObject, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * this.bulletSpeed, ForceMode2D.Impulse);
        Destroy(spawnedBullet, this.bulletLifetime);

    }

    // If bullet hits enemy, destory bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MeleEnemy")
        {
            Destroy(this.gameObject);
        }
    }
}

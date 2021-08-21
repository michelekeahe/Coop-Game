using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigibod; 

    [SerializeField]
    private float bulletSpeed = 50f;
    private float bulletLifetime = 2f;

    private void Awake()
    {
        rigibod = GetComponent<Rigidbody2D>();
    }

    // Projects & adds force to bullet. Destroys after period of time.
    public void Project(Vector2 direction)
    {
        rigibod.AddForce(direction * this.bulletSpeed, ForceMode2D.Impulse);
        Destroy(this.gameObject, bulletLifetime);
    }

    // If bullet hits something
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed = 50f;
    private float bulletLifetime = 2f;
    private bool recharging = false;


    public void StartShooting(Transform firePoint)
    {
        while (!recharging)
        {
            StartCoroutine(Shoot(firePoint));
        }
    }

    public IEnumerator Shoot(Transform firePoint)
    {
        recharging = true;
        GameObject spawnedBullet = Instantiate(this.gameObject, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * this.bulletSpeed, ForceMode2D.Impulse);
        Destroy(spawnedBullet, this.bulletLifetime);
        yield return new WaitForSeconds(1);
        recharging = false;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

}

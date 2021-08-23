using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public EnemyBullet bulletPrefab;

    [SerializeField]
    private Transform firepoint;

    [SerializeField]
    private float minShootTime = 1.5f;
    [SerializeField]
    private float maxShootTime = 2.5f;
    private float randShootTime = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(ShootDelay());
    }

    IEnumerator ShootDelay()
    {
        Debug.Log("Shoot");

        // Shoot
        this.bulletPrefab.Shoot(firepoint);

        // Wait after random period of time
        randShootTime = Random.Range(minShootTime, maxShootTime);
        yield return new WaitForSeconds(2);
    }
}

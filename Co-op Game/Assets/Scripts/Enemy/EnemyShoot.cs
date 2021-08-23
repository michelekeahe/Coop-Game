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

    private bool isInRage = true;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInRage = true;

        while (collision.tag == "Player" && isInRage)
        {
            //StartCoroutine(ShootDelay());
            Debug.Log("Shoot");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRage = false;
    }
    

    IEnumerator ShootDelay()
    {
        Debug.Log("Shoot");
        // Wait after random period of time
        randShootTime = Random.Range(minShootTime, maxShootTime);
        yield return new WaitForSeconds(2);

        // Shoot
        this.bulletPrefab.Shoot(firepoint);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Refering to EnemyBullet class
    public EnemyBullet bulletPrefab;

    // Insantiated in Unity
    [SerializeField]
    private Transform firepoint;

    [SerializeField]
    private Transform playerPos;

    // Variables used to decide of often enemy shoots
    [SerializeField]
    private float minShootTime = .5f;
    [SerializeField]
    private float maxShootTime = 1f;
    private float randShootTime = 0f;

    // Bool to check is player is in range to shoot at.
    private bool isInRage = false;

    // If the player is shoot range, then start the delay corutine.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInRage = true;

        if (collision.tag == "Player" && isInRage == true)
        {
            StartCoroutine(ShootDelay());


        }


    }

    // If player leaves range, change isInRange to false.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInRage = false;

        }

    }


    // Coroutine to prevent bullets shooting out all at once.
    IEnumerator ShootDelay()
    {
        // The condition is important! Without it, the enemy will just shoot forever.
        // However, now when the player goes invincible, it stops shooting
        // This is because all of the players colliders disable when dead.
        while (isInRage)
        {
            float playerDirection = playerPos.position.x - transform.position.x;
            float playerDirSimple = Mathf.Sign(playerDirection);
            
            if(playerDirSimple == 1)
            {
                transform.right = ((Vector2)playerPos.position - (Vector2)transform.position).normalized;

            }
            else
            {
                transform.right = -((Vector2)playerPos.position - (Vector2)transform.position).normalized;

            }


            // Wait after random period of time
            randShootTime = Random.Range(minShootTime, maxShootTime);
            yield return new WaitForSeconds(.5f);

            // Shoot
            this.bulletPrefab.Shoot(firepoint);

        }

    }
}

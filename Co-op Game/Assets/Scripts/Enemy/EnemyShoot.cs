using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Declaring Compenents
    [SerializeField]
    private EnemyBullet bulletPrefab;
    [SerializeField]
    private Transform firepoint;
    [SerializeField]
    private Transform playerPos;

    // Serialized variables
    // Variables used to decide of often enemy shoots
    [SerializeField]
    private float minShootTime = .5f;
    [SerializeField]
    private float maxShootTime = 1f;

    // Private variables
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
            //Rotates gun to face player
            Vector2 playerDirection = playerPos.position - transform.position;
            float playerDirSimple = Mathf.Sign(playerDirection.x);
            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg + 180f;

            if (playerDirSimple == 1)
            {
                //Must add 180 to angle, otherwise bullet shoots in opposite direction when facing right.
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180f));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle ));
            }

            // Wait after random period of time
            randShootTime = Random.Range(minShootTime, maxShootTime);
            yield return new WaitForSeconds(randShootTime);

            // Shoot
            this.bulletPrefab.Shoot(firepoint);
        }
    }
}

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

    //Private veraibles
    private float currentTime = 0;
    private float randomWaitTime = 0;
    private bool ShotFired = false;

    // If the player is shoot range, then start the delay corutine.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Getting distance from and to player, and creating variables from it for later calculations.
            Vector2 distanceFromPlayer = playerPos.position - transform.position;
            Vector2 direction = distanceFromPlayer.normalized;
            float playerDirSimple = Mathf.Sign(distanceFromPlayer.x);
            float angle = Mathf.Atan2(distanceFromPlayer.y, distanceFromPlayer.x) * Mathf.Rad2Deg + 180f;
            float distanceToPlayer = distanceFromPlayer.magnitude;

            //sending Ray. Only interacts with Player and Ground layers.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distanceToPlayer, 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Ground"));

            //Checks to see if ray hits something
            if(hit.collider != null)
            {
                //If ray hits player, fire prefab and start random countdown
                if(hit.collider.tag == "Player" && currentTime == 0 && !ShotFired)
                {
                    Fire(playerDirSimple, angle);
                    randomWaitTime = Random.Range(minShootTime, maxShootTime);
                    ShotFired = true;
                }
                //coundown code
                else if (currentTime < randomWaitTime && ShotFired)
                {
                    currentTime += 1 * Time.deltaTime;
                }
                //resets coundown
                else if (currentTime >= randomWaitTime)
                {
                    currentTime = 0;
                    ShotFired = false;
                }
            }

        }
    }

    // Coroutine to prevent bullets shooting out all at once.
    private void Fire(float playerDirSimple, float angle)
    {
        if (playerDirSimple == 1)
        {
            //Must add 180 to angle, otherwise bullet shoots in opposite direction when facing right.
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180f));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle ));
        }
        // Shoot
        this.bulletPrefab.Shoot(firepoint);
    }
}

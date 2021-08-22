using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //grabbing player position in Unity
    [SerializeField]
    private Transform playerPos;

    [SerializeField]
    private int speed;
    [SerializeField]
    private int agroRange;

    
    private bool isGrounded;

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    //Enemy follows player if enemy is grounded
    //and if player is within x units
    //Enemy stops following player if player is within 1.5 units.
    private void FollowPlayer()
    {
        Vector3 distanceFromPlayer = playerPos.position - transform.position;
        Vector3 direction = distanceFromPlayer.normalized;

        float distanceToPlayer = distanceFromPlayer.magnitude;

        if (isGrounded == true && distanceToPlayer > 1.5f && distanceToPlayer < agroRange)
        {
            transform.position += new Vector3(direction.x, 0f, 0f) * speed * Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground") isGrounded = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground") isGrounded = false;
    }

}

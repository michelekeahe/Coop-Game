using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyMovement : MonoBehaviour
{
    //grabbing player position in Unity
    [SerializeField]
    private Transform playerPos;

    [SerializeField]
    private int speed;
    [SerializeField]
    private float stopDistance;
    
    private bool isGrounded;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FollowPlayer();
        }
    }

    // Enemy follows player if enemy is grounded && and if player is within x units
    // Enemy stops following player if player is within StopDistance.
    private void FollowPlayer()
    {
        // Getting distance from player
        Vector3 distanceFromPlayer = playerPos.position - transform.position;
        Vector3 direction = distanceFromPlayer.normalized;
        
        float distanceToPlayer = distanceFromPlayer.magnitude;

        Debug.Log(isGrounded);

        // Checks distance from player and when to stop.
        if (isGrounded && (distanceToPlayer > stopDistance))
        {
            transform.position += new Vector3(direction.x, 0f, 0f) * speed * Time.deltaTime;
        }
    }
    
    // Checks for grounding
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground") isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground") isGrounded = false;
    }
}

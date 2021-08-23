using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //grabbing player position in Unity
    [SerializeField]
    private Transform playerPos;

    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float stopDistance = 0f;
    private float horizontalDirection = 0f;
    
    private bool isGrounded = false;
    private bool isFacingRight = true;
    
    // For gizmo
    Vector2 viewArea;

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

        // Flips GameObject depending on direction it's moving towards
        SetVelocity(direction);
        
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }

    public void SetVelocity(Vector2 direction)
    {
        horizontalDirection = direction.x;
        if (horizontalDirection < 0 && isFacingRight) Flip();
        else if (horizontalDirection > 0 && !isFacingRight) Flip();
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        isFacingRight = !isFacingRight;
    }
}

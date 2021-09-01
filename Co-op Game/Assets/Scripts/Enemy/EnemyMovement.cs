using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    #region Serialized Variables 
    //grabbing player position in Unity
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float stopDistance = 0f;
    #endregion

    #region Private Variables
    private float horizontalDirection = 0f;
    private bool isFacingRight = true;
    // For gizmo
    private Vector2 viewArea;
    #endregion

    //When Player is in range, follow him
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Getting distance from and to player. 
            Vector2 distanceFromPlayer = playerPos.position - transform.position;
            Vector2 direction = distanceFromPlayer.normalized;
            float distanceToPlayer = distanceFromPlayer.magnitude;

            //sending Ray. Only interacts with Player and Ground layers.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distanceToPlayer, 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Ground"));

            //If ray hits something, if it hits player, then follow him.
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                    FollowPlayer(direction, distanceToPlayer);
                }
            }

        }
    }

    // Enemy follows player if enemy is grounded && and if player is within x units
    // Enemy stops following player if player is within StopDistance.
    private void FollowPlayer(Vector2 direction, float distanceToPlayer)
    {
        // Flips GameObject depending on direction it's moving towards
        SetVelocity(direction);
        
        // Checks distance from player and when to stop.
        if (distanceToPlayer > stopDistance)
        {
            transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        }
    }
    
    //Lets us see gizmo
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }

    //Code to flip enemy
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

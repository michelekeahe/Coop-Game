using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;

    [SerializeField]
    private int speed;

    private bool isGrounded;

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 distanceFromPlayer = playerPos.position - transform.position;
        Vector3 direction = distanceFromPlayer.normalized;

        float distanceToPlayer = distanceFromPlayer.magnitude;

        if (isGrounded == true && distanceToPlayer > 1.5f)
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

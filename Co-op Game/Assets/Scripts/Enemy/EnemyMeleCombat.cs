using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleCombat : MonoBehaviour
{
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private LayerMask playerLayerMask;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = new PlayerHealth();
    }

    private void Update()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        //RaycastHit2D hit;
        if( Physics2D.Raycast(attackPoint.position, Vector2.left, 1.5f, playerLayerMask))
        {
            StartCoroutine(DealDamage());
        }
    }

    private IEnumerator DealDamage()
    {
        yield return new WaitForSeconds(2);
        playerHealth.Damage(1);
        Debug.Log(playerHealth.health);

    }

}

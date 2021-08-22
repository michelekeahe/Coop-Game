using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleCombat : MonoBehaviour
{
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private LayerMask playerLayerMask;

    private void Update()
    {
        
    }

    private void DetectPlayer()
    {
        //RaycastHit2D hit;
        if( Physics2D.Raycast(attackPoint.position, Vector2.left, 1.5f, playerLayerMask))
        {
            Debug.Log("Ray");
        }
    }

}

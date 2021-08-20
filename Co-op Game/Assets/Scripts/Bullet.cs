using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Start()
    {
        //Calls Destroy function
        StartCoroutine(Destroy());

        playerHealth = new PlayerHealth();
    }

    //Temporary Coroutine to destory bullets. 
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            playerHealth.Damage(1);
            Destroy(gameObject);
        }
    }

}

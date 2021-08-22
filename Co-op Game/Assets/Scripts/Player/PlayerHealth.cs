using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int health = 3;

    public void Healing (int healAmount)
    {
        health = health + healAmount;
    }

    public void Damage(int damageAmount)
    {
        health = health - damageAmount;
    }

}

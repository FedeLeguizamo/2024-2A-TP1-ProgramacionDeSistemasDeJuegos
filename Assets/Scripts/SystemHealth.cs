using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemHealth : MonoBehaviour
{
    public int health = 100;
    public CharacterDataSO characterData; 
    
    void OnEnable()
    {
        health = characterData.hp;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Heal(int heal)
    {
        health += heal;
    }

    public int GetHealth()
    {
        return health;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<SystemHealth>()!= null)
        {
            if (other.gameObject.CompareTag(characterData.enemytag))
                other.gameObject.GetComponent<SystemHealth>().TakeDamage(characterData.damage); 
        }
    }
    
}

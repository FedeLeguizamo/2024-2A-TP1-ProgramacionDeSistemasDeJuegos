using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureSpawn : MonoBehaviour
{
    SystemHealth systemHealth;

    void Start()
    {
        systemHealth = GetComponent<SystemHealth>();
    }

    void Update()
    {
        if (systemHealth.GetHealth() <= 0)
        {
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        transform.GetChild(0).gameObject.SetActive(true); 
        systemHealth.Heal(systemHealth.characterData.hp);
    }
    
}

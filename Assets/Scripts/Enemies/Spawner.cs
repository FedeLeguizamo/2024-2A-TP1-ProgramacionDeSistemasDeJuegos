using System;
using System.Collections;
using Enemies;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private int spawnsPerPeriod = 10;
    [SerializeField] private float frequency = 30;
    [SerializeField] private float period = 0;

    private void OnEnable()
    {
        if (frequency > 0) period = 1 / frequency;
    }

    private IEnumerator Start()
    {
        while (true)  
        {
            for (int i = 0; i < spawnsPerPeriod; i++)
            {
                // Agarro de la pool
                Enemy pooledEnemy = Pool.instance.GetPooledObject();

                if (pooledEnemy != null)
                {
                    // Clono aca
                    Enemy clonedEnemy = (Enemy)pooledEnemy.Clone();

                    clonedEnemy.transform.position = transform.position;
                    clonedEnemy.gameObject.SetActive(true);
                }
                yield return new WaitForSeconds(period);
            }
        }
    }
}

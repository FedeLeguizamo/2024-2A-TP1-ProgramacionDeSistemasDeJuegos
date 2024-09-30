using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool instance;
    
    private List<Enemy> pooled = new List<Enemy>();
    [SerializeField]private int pooledCount = 0;
    
    [SerializeField] private Enemy _enemy;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < pooledCount; i++)
        {
            Enemy obj = Instantiate(_enemy); 
            obj.gameObject.SetActive(false);
            pooled.Add(obj); 
        }
    }

    public Enemy GetPooledObject()
    {
        for (int i = 0; i < pooled.Count; i++)
        {
            if (!pooled[i].gameObject.activeInHierarchy)
            {
                return pooled[i];
            }
        }
        
        return null;
    }
}

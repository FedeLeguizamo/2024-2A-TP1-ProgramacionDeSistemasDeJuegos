using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        public event Action OnSpawn = delegate { };
        public event Action OnDeath = delegate { };
        [SerializeField] private Vector3[] target;
    
        private void Reset() => FetchComponents();

        private void Awake() => FetchComponents();
    
        private void FetchComponents()
        {
            agent ??= GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            if (agent.isOnNavMesh)
            {
                //Is this necessary?? We're like, searching for it from every enemy D:
                Vector3 towncenter = target[Random.Range(0, target.Length)];
                var destination = towncenter;
                destination.y = transform.position.y;
                agent.SetDestination(destination);
            }
            
        }

        private IEnumerator AlertSpawn()
        {
            //Waiting one frame because event subscribers could run their onEnable after us.
            yield return null;
            OnSpawn();
        }

        private void Update()
        {
            if (agent.hasPath
                && Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance)
            {
                Debug.Log($"{name}: I'll die for my people!");
                Die();
            }
        }

        private void Die()
        {
            OnDeath();
            //Destroy(gameObject);
            
            gameObject.SetActive(false);
        }
        
        
        public object Clone()
        {
            
            Enemy clone = Instantiate(this);

            // Verifico los eventos antes
            clone.OnSpawn = (Action)Delegate.Combine(OnSpawn?.GetInvocationList());
            clone.OnDeath = (Action)Delegate.Combine(OnDeath?.GetInvocationList());

            return clone;
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float attackRange = 2f;

    [SerializeField]
    float damage;

    [SerializeField]
    float damageInterval = 2f; 

    float lastDamageTime;

    NavMeshAgent _navAgent;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navAgent.SetDestination(target.position);

        if (Time.time - lastDamageTime >= damageInterval)
        {
            if (Vector3.Distance(transform.position, target.position) <= attackRange)
            {
                // Aplicar el daño al objetivo
                HealthController healthController = target.GetComponent<HealthController>();
                if (healthController != null)
                {
                    healthController.TakeDamage(damage);
                }

                lastDamageTime = Time.time;
            }
        }
    }
}

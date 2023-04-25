using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private Animator animator;

    private NavMeshAgent _agent;
    private float _distanceToTarget;
    private bool _isProvoked = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (_isProvoked)
        {
            EngageTarget();
        }
        else if (_distanceToTarget < chaseRange)
        {
            animator.SetBool("IsRunning", true);
            _isProvoked = true;
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void EngageTarget()
    {
        if (_agent.stoppingDistance < _distanceToTarget)
        {
            ChaseTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        Debug.Log(name + " is destroyed");
    }

    private void ChaseTarget()
    {
        _agent.SetDestination(target.position);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
#endif
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private float turnSpeed = 5f;


    private Transform target;

    private NavMeshAgent navMeshAgent;
    private EnemyHealth health;
    private float distanceToTargt = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
        health = GetComponent<EnemyHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (health.IsDead())
        {
            this.enabled = false;
            navMeshAgent.enabled = false;
        }

        distanceToTargt = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTargt <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTargt >= navMeshAgent.stoppingDistance)
        {
            ChasePlayer();
        }

        if(distanceToTargt <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChasePlayer()
    {
        if(navMeshAgent.isActiveAndEnabled)
        {
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<Animator>().SetTrigger("Move");
            navMeshAgent.SetDestination(target.position);
        }

    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        
    }




}

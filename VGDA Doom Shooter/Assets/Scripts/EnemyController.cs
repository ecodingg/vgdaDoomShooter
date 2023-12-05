
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public int damageP = 10; //damage enemey deals
    public float lookRadius = 10f;
    public float attackDistance = 10f;
    public float timeBetweenAttacks;

    Transform target; // aka player
    NavMeshAgent agent;
    
    bool alreadyAttacked;

    public float health; //Enemy Health


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                AttackPlayer();
                FaceTarget();
            }
        }
    }

    private void AttackPlayer() //work in progress
    {
        Debug.Log("AttackPlayer called");

        agent.SetDestination(target.position);

        transform.LookAt(target);

        if (!alreadyAttacked)
        {
            playerHealth.TakeDamage(damageP);
            Debug.Log("Attack player");

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        // provides a visual for the enemies look radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}


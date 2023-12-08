
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    ////code for animations
    //private Animator animator;
    //private bool isAttacking = false;
    //private bool isWalking = false;


    public SpriteRenderer spriteRenderer;
    public Sprite hurtA, idleA, attackA, deathA, walkA;
    bool isDead = false;

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
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        idleSprite();
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

        // Check if the enemy is walking (moving)
        if (agent.velocity != Vector3.zero)
        {
            walkSprite();
        }
        else if (isDead == true)
        {
            deathSprite();
        }
        else
        {
            idleSprite();
        }
    }

    private void AttackPlayer() //work in progress
    {
        Debug.Log("AttackPlayer called");

        agent.SetDestination(target.position);

        transform.LookAt(target);

        if (!alreadyAttacked)
        {
            attackSprite();
            //player takes damage when coming in contact with player - code in player health script
            Debug.Log("Attack player");

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        idleSprite();
    }

    //functions for sprites
    void hurtSprite()
    {
        Debug.Log("Hurt");
        spriteRenderer.sprite = hurtA;
    }

    void idleSprite()
    {
        Debug.Log("idle");
        spriteRenderer.sprite = idleA;
    }
    void attackSprite()
    {
        Debug.Log("attack");
        spriteRenderer.sprite = attackA;
    }
    void walkSprite()
    {
        Debug.Log("walking");
        spriteRenderer.sprite = walkA;
    }
    void deathSprite()
    {
        Debug.Log("death rip lol");
        spriteRenderer.sprite = deathA;
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
            hurtSprite();
            isDead = true;
            // Show the death sprite for a bit longer before destroying the enemy
            float delayBeforeDestroy = 1.0f;
            deathSprite();

            // Stop the enemy from walking and invoking walking sprite again during death
            agent.isStopped = true;

            // Invoke DestroyEnemy() after the delay
            Invoke(nameof(DestroyEnemy), delayBeforeDestroy);
        }
        else if (!alreadyAttacked)
        {
            hurtSprite();
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}


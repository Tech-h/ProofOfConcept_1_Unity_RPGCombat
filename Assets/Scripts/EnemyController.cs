using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    

    public float health;

    // Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    int numberOfAttacksMade;
    int numberOfTimesDamageTaken;
    bool isDodging;

    // States
    public float sightRange, jumpAttackRange, attackRange;
    public bool playerInSightRange, playerJumpAttackRange, playerInAttackRange;

    // Components
    private Animator animator;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerJumpAttackRange = Physics.CheckSphere(transform.position, jumpAttackRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && animator.GetBool("IsDead") == false)
        {
           // Debug.Log("Patroling");
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange && animator.GetBool("IsDead") == false)
        {
           // Debug.Log("Chasing");
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange && animator.GetBool("IsDead") == false)
        {
          //  Debug.Log("Attacking");
            AttackPlayer();
        }
    }

    private void Patroling()
     {
        animator.SetFloat("MoveAmount", 0);
        /*  if (!walkPointSet) SearchWalkPoint();

          if (walkPointSet)
          {
              agent.SetDestination(walkPoint);
          }

          Vector3 distanceToWalkPoint = transform.position - walkPoint;

          //Walkpoint reached
          if (distanceToWalkPoint.magnitude < 1f)
          {
              walkPointSet = false;
          }*/
    }
    /*private void SearchWalkPoint()
    {
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }*/

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        animator.SetFloat("MoveAmount", 1);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        animator.SetFloat("MoveAmount", 0);

        if (!alreadyAttacked)
        {
            transform.LookAt(transform.forward);


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            animator.SetBool("isDead", true);
           // Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }



   /* private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.TransformPoint(transform.position), sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.TransformPoint(transform.position), attackRange);
    }*/
}

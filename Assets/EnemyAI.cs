using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float countDown = 5;
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    private float randomZ;
    private float randomX;
    public float StillTimer;

    //patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPoingRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //switch
    private int statement;

    //damage
    //public GameObject playerDamage;
    public GameObject manSkin;

    private void Awake()
    {
        //Getiing player transform and agent nav-mesh agent
        player = GameObject.Find("PlayerCapsule").transform;
        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        //state-machine controller
        if (!playerInSightRange && !playerInAttackRange)
        {
            statement = 1;
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            statement = 2;
        }
        if (playerInSightRange && playerInAttackRange)
        {
            statement = 3;
        }

        switch (statement)
        {
            case 1:
                patroling();
                break;

            case 2:
                chasePlayer();
                break;

            case 3:
                attackPlayer();
                break;
        }
        if (StillTimer >= 0)
        {
            StillTimer = StillTimer - Time.deltaTime;
        }
        if (StillTimer <= 0)
        {
            manSkin.GetComponent<Animator>().Play("Walk");
        }
    }


    private void patroling()
    {
        //walk to walkpoint
        if (!walkPointSet)
        {
            SearchWalkPoint();
            StillTimer = Random.Range(1,10);
        }

        if (walkPointSet & StillTimer <= 0)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoin reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

       
    }
    private void SearchWalkPoint()
    {
        //calculate random point in range
        randomZ = Random.Range(-walkPoingRange, walkPoingRange);
        randomX = Random.Range(-walkPoingRange, walkPoingRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

       
        if (Physics.Raycast(walkPoint, -transform.up, 2f))
        {
            walkPointSet = true;
        }
        
        //start countdown to new walkpoint (if former walkpoint was unreachable)
        StartCoroutine(countDownRoutine());
    }
    //walkpoint countdown
    private IEnumerator countDownRoutine()
    {
        while (true)
        {
            newWalkPoint();
            yield return new WaitForSeconds(5);
        }
    }
    //placing new walkpoint
    private void newWalkPoint()
    {
        randomZ = Random.Range(-walkPoingRange, walkPoingRange);
        randomX = Random.Range(-walkPoingRange, walkPoingRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }
    private void chasePlayer()
    {
        //placing destination to the player
        agent.SetDestination(player.position);
    }
    private void attackPlayer()
    {
        //stopping up and attacking
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //damaging player
            //Invoke(nameof(DamagePlayer), 0.5f);
            //attack cooldown
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            manSkin.GetComponent<Animator>().Play("Punch");
        }
    }
    private void DamagePlayer()
    {
        //activating damage code in playermovement script
        //playerDamage.GetComponent<PlayerMovement>().TakeDamage();
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}

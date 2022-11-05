using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemyFinal : MonoBehaviour
{
    public NavMeshAgent agent;
    Transform player;
    public GameObject manSkin;
    Animator anim;
    public bool wondering;
    public float wonderMaxStandStillTime;
    public float wonderMinStandStillTime;
    public float wonderMinWalkRange;
    public float wonderMaxWalkRange;


    public enum states
    {
        search, chase, attack, chill, wonder
    }

    public states myState = new states();



    void Start()
    {
        player = GameObject.Find("PlayerCapsule").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = manSkin.GetComponent<Animator>();
        myState = states.wonder;
    }

    
    void Update()
    {
        switch (myState)
        {
            case states.search:
                Search();
                break;

            case states.chase:
                Chase();
                break;

            case states.attack:
                Attack();
                break;

            case states.chill:
                Chill();
                break;

            case states.wonder:

                if (wondering == false)
                {
                    StartCoroutine("Wonder");
                }
                
                break;
        }
    }

    void Search()
    {

    }

    void Chase()
    {

    }

    void Attack()
    {

    }

    void Chill()
    {

    }

    IEnumerator Wonder()    //the agent wonders around and stands still sometimes
    {
        wondering = true;                                                                                   //bool for only running the coroutine once at a time
        agent.speed = 1.2f;

        while (myState == states.wonder)                                                        
        {
            Vector3 finalPosition = new Vector3(0,0,0);                                                     //this will become the position the agent will walk to
            NavMeshPath navMeshPath = new NavMeshPath();                                                    //navmeshpath for checking if a path is calculated (takes some time)
            bool navMeshPointFound = false;                                                                 //bool for checking for valid navmesh points

            while (navMeshPointFound == false)                                                              
            {
                float wonderRadius = Random.Range(wonderMinWalkRange, wonderMaxWalkRange);                  //random float
                Vector3 randomDirection = Random.insideUnitSphere * wonderRadius;                           //random position around agent
                randomDirection += transform.position;
                NavMeshHit hit;

                if (NavMesh.SamplePosition(randomDirection, out hit, 1, NavMesh.AllAreas) == true)          //finds the closest navmesh point to the randomDirection float within 1 unit of the point and returns false if no point exists
                {
                    finalPosition = hit.position;                                                           //if a point exists, it is saved here
                    navMeshPointFound = true;                                                               //bool set to true if point is found, taking us out of the while loop
                    print("found point on navmesh");
                }

                else
                {
                    print("no point in range on navmesh");
                }
                
            }

            agent.SetDestination(finalPosition);
            print("position set");

            while (agent.remainingDistance == 0)                                                            //it takes navmesh a little time to find a path to the target destination. during this time navmesh thinks the distance to the target is 0. Thats why I have this while loop.
            {
                print("calculating path");
                yield return new WaitForSecondsRealtime(0.1f);
            }

            print($"path found. distace: {agent.remainingDistance}");

            while (agent.remainingDistance > 0.01f)
            {
                if (anim.GetInteger("Movement") != 1)
                {
                    print("set integer to 1");
                    anim.SetInteger("Movement", 1);
                }

                print($"moving. remaining distance: {agent.remainingDistance}");
                yield return new WaitForSecondsRealtime(0.2f);
            }

            anim.SetInteger("Movement", 0);
            print("standing still");
            yield return new WaitForSecondsRealtime(Random.Range(wonderMinStandStillTime,wonderMaxStandStillTime));
        }

        wondering = false;
    }
}

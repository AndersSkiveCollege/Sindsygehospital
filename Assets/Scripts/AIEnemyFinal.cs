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

    IEnumerator Wonder()
    {

        while (myState == states.wonder)
        {
            anim.SetInteger("Movement", 1);
            float wonderRadius = Random.Range(wonderMinWalkRange,wonderMaxWalkRange);
            Vector3 randomDirection = Random.insideUnitSphere * wonderRadius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, wonderRadius, 1);
            Vector3 finalPosition = hit.position;
            GetComponent<NavMeshAgent>().destination = finalPosition;
            yield return new WaitForSecondsRealtime(Random.Range(wonderMinStandStillTime,wonderMaxStandStillTime));
        }
    }
}

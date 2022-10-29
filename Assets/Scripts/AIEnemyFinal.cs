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

    public enum states
    {
        search, chase, attack, chill, walk
    }

    public states myState = new states();



    void Start()
    {
        player = GameObject.Find("PlayerCapsule").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = manSkin.GetComponent<Animator>();
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
                Attack();
                break;

            case states.walk:
                Attack();
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

    void Walk()
    {

    }
}

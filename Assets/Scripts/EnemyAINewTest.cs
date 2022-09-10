using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAINewTest : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    private int statement;
    public GameObject manSkin;
    public float walkAiomationLoopTime;

    private void Awake()
    {
        //Getiing player transform and agent nav-mesh agent
        player = GameObject.Find("PlayerCapsule").transform;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(WalkingAnimationPlayer());
    }

    IEnumerator WalkingAnimationPlayer()
    {
        while (true)
        {
            manSkin.GetComponent<Animator>().Play("Walk");
            yield return new WaitForSeconds(walkAiomationLoopTime);
        }
    }

    private void Update()
    {
        agent.SetDestination(player.position);   
    }
}

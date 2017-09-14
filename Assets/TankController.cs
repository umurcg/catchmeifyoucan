using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// //Tank controller follows player
/// When it reaches to near of player within a radius it waits.
/// </summary>


public class TankController : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] float radius;
    NavMeshAgent nma;


    private void Awake()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {

        float distance = Vector3.Distance(player.transform.position, transform.position);

        //Debug.Log("Distance is " + distance + " following is " + (distance > radius));

        if (distance> radius) followPlayer();
        else nma.isStopped = true;



	}

    private void followPlayer()
    {
        nma.isStopped = false;
        Vector3 playerToTankDir = transform.position - player.transform.position;
        playerToTankDir = playerToTankDir.normalized;
        Vector3 aim = player.transform.position + playerToTankDir * radius;

        //Try to cast aim to neares hit position on navmash
        NavMeshHit hit;
        if(NavMesh.SamplePosition(aim,out hit, 30f, nma.areaMask))  aim = hit.position;

        nma.SetDestination(aim);
        
    }
}

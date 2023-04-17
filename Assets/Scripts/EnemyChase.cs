using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    
    public Transform playerToChase;

    private bool isChasing=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing == true)
        {
            transform.LookAt(playerToChase);
            enemyAgent.SetDestination(playerToChase.transform.position);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isChasing = true;

    }

    private void OnTriggerExit(Collider other)
    {
        isChasing = false;
    }
}

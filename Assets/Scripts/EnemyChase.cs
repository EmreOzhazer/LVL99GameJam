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
    
    [SerializeField] private ParticleSystem sprayParticle;
   
    private Animator animator;

    public Transform[] waypoints;
    private int wayPointIndex;
    private Vector3 target;

    private bool isChasing = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        UpdateDestionation();
        animator.SetBool("isWalking",true);
        sprayParticle.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isChasing == true)
        {
            transform.LookAt(playerToChase);
            enemyAgent.SetDestination(playerToChase.transform.position);
        }

        if (Vector3.Distance(transform.position, target) < 1)// less than 1 metre close 
        {
           
            IterateWaypointIndex();
            UpdateDestionation();
        }
        
    }
    
    //patrol atarken gizmolar nav mesh agent ama gözükürse nav mesh agent arı oluyor.
    //kovaladıktan sonra eğer arı kaçarsa 2 saniye sonra geri döner patrol atmaya

    void UpdateDestionation()
    {
        
        target = waypoints[wayPointIndex].position;
        enemyAgent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        wayPointIndex++;
        if (wayPointIndex == waypoints.Length) wayPointIndex = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        isChasing = true;
        animator.SetBool("isRunning",true);
        sprayParticle.Play();

        //transform.position = Vector3.Lerp(transform.position, enemyVector, Time.deltaTime * 0.001f); //
    }

    private void OnTriggerExit(Collider other)
    {
        
        isChasing = false;
        //animator.SetBool("isRunning",false);
       StartCoroutine(backToPatrol());
       sprayParticle.Stop();
       
       
       
        IEnumerator backToPatrol()
        {
            animator.SetBool("isRunning",false);
            animator.SetBool("isWalking",false);
            enemyAgent.speed = 0;
            yield return new WaitForSeconds(2);
            UpdateDestionation();
            animator.SetBool("isWalking",true);
            
            enemyAgent.speed = 3;

        }
        
    }
    
}

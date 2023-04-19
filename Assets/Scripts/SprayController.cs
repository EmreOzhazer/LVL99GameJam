using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{
    [SerializeField] private BeeCondition _beeCondition;

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("damageTaken");
            _beeCondition.beeHealth -= 1;
            

        }
    }

    public void GiveDamage()
    {
        
    }
    void Update()
    {
        
    }
}

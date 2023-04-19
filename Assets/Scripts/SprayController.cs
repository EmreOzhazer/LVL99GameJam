using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{
    [SerializeField] private BeeCondition _beeCondition;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _beeCondition.breath <= 1f )
        {
            Debug.Log("damageTaken");
            _beeCondition.beeHealth -= 1;
            _beeCondition.breath -= 1;
            

        }
    }
    
}

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
            _beeCondition.isinGas = true;

            Debug.Log("damageTaken");
            _beeCondition.beeHealth -= 0.4f;
            _beeCondition.breath -= 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _beeCondition.isinGas = false;
        //spraySound.Pause();
    }
}

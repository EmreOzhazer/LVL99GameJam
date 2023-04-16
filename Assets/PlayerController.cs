using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

  [SerializeField]  private float _responsiveness = 500f;
  [SerializeField]  private float _throttleAmt = 25;
    private float _throttle;

    
    private float _roll;
    private float _pitch;
    private float _yaw;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInputs();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(transform.up * _throttle, ForceMode. Impulse) ;

        _rigidbody.AddTorque(transform.right * _pitch * _responsiveness);
        _rigidbody.AddTorque(transform.forward * _roll * _responsiveness);
        _rigidbody.AddTorque(transform.up * _yaw * _responsiveness);

    }

    private void HandleInputs()
    {
        _roll = Input.GetAxis("Horizontal");
        _pitch = Input.GetAxis("Vertical");
        _yaw = Input.GetAxis ("Yaw");
        if (Input.GetKey(KeyCode.Space))
            _throttle += Time.deltaTime * _throttleAmt;
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            _throttle -= Time.deltaTime * _throttleAmt;
        }
        
        _throttle = Mathf.Clamp(_throttle, 0f, 100f);

    }
}



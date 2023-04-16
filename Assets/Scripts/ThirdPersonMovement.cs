using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    
    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    private void Start()
    {
        Cursor. lockState = CursorLockMode. Locked;
        Cursor. visible = false;

    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float rise = Input.GetAxisRaw("Jump");
        Vector3 direction = new Vector3(horizontal, rise, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
             float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            
            // float targetAngleUp = Mathf.Atan2(direction.y, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //
             float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                 turnSmoothTime);
            //
             transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //
             Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f)*Vector3.forward;
            //
            // Vector3 moveDirUp = Quaternion.Euler(0f, targetAngleUp, 0f)*Vector3.up;
            controller.Move(direction.normalized * speed * Time.deltaTime);
           // controller.Move(moveDirUp.normalized * speed * Time.deltaTime);
        }
    }
}

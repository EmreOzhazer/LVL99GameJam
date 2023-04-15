using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float FlySpeed = 5;
    public float YawAmount = 120;
    private float Yaw;
  

    void Update() {
        
    // move forward
    transform.position += transform.forward * FlySpeed * Time.deltaTime;
    // inputs
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    // yaw, pitch, roll
    Yaw += horizontalInput * YawAmount * Time.deltaTime;
    float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
    // apply rotation
    transform. localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch);
}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public Rigidbody rb;

    private float maxSpeed = 2.7f;
    public float movementSpeed;
    private float stopSpeed = 3.5f;
    private float speedModifier = 6.1f;

    private void Update()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            movementSpeed = maxSpeed;
        }
    }

    private void FixedUpdate()
    {
        WaitForInput();
        StopMoving();
    }

    private void WaitForInput()
    {
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * movementSpeed * speedModifier, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(-transform.forward * movementSpeed * speedModifier, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(-transform.right * movementSpeed * speedModifier, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * movementSpeed * speedModifier, ForceMode.Acceleration);
        }
    }

    private void StopMoving()
    {
        if (Input.anyKey != true)
        {
            if (rb.velocity.magnitude > 0)
            {
                rb.velocity -= rb.velocity * stopSpeed * Time.deltaTime;
            }
        }
    }

}

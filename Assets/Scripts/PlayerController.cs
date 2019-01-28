using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float inputDelay = 0.1f;
    public float forwardVel = 12.0f;
    public float rotateVel = 100;
    
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    private void Start()
    {
        targetRotation = transform.rotation; // Set target rotation to spawn rotation
        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("The character needs a rigidbody.");
        }
    }

    // Get any input every second via Update
    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical"); // Defined in Edit > Project Settings > Input - returns value between -1 and 1
        turnInput = Input.GetAxis("Horizontal"); // Defined in Edit > Project Settings > Input
    }

    private void Update()
    {
        GetInput();
        Turn();
    }

    private void FixedUpdate()
    {
        Run();
    }

    void Run()
    {
        // If no longer receiving input, stop moving
        if(Mathf.Abs(forwardInput) > inputDelay)
        {
            // move
            rBody.velocity = transform.forward * forwardInput * forwardVel;
        }
        else
        {
            // zero velocity
            rBody.velocity = Vector3.zero;
        }
    }
    
    void Turn()
    {
        // If stop receiving input, stop turning
        if(Mathf.Abs(turnInput) > inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up); // Multiplying quaternions is like adding angles to previous target rotation
            transform.rotation = targetRotation;
        }
        transform.rotation = targetRotation;
    }
}

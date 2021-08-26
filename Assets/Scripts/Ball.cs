using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody ballRigidbody;
    [SerializeField] private float maxVelocity = 25;
    [SerializeField] private float slowerForce = 0.8f;
    [SerializeField] private float current;

    void Update()
    {
        current = ballRigidbody.velocity.magnitude;
    }
    void FixedUpdate()
    {
        if (ballRigidbody.velocity.magnitude > maxVelocity)
        {
            
            ballRigidbody.velocity *= slowerForce;
            
        }
    }

}

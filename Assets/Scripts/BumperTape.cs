using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperTape : MonoBehaviour
{
    [SerializeField]
    private int forceX = 5;
    [SerializeField]
    private int forceZ = 5;
    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddForce(forceX, 0, forceZ, ForceMode.Impulse);
    }
}

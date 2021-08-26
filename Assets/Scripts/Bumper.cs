using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper: MonoBehaviour
{
    
    [SerializeField] private int force = 2;
    

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 velocityBeforeContact;
        Vector3 velocityAfterContact;
        //ContactPoint contact;
        var contact = collision.contacts[0];
        velocityBeforeContact = collision.rigidbody.velocity;
        velocityAfterContact = Vector3.Reflect(velocityBeforeContact, contact.normal);
        velocityBeforeContact = velocityAfterContact;
        collision.rigidbody.velocity = velocityAfterContact * 2;
        Debug.Log($"before{velocityBeforeContact},after{collision.rigidbody.velocity}");

        //collision.rigidbody.AddForce(8, 0, 8, ForceMode.Impulse);
    }
}

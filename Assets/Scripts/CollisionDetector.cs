using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction;
    [SerializeField] 
    private bool random;
    [SerializeField] 
    private Vector3 randDirection;
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ball"))
        {
            onTriggerStay?.Invoke(true);

        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ball"))
        {
            onTriggerEnter?.Invoke(true);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            onContact?.Invoke(true);
            if (random)
            {
                var randomizedDirection = new Vector3(Random.Range(-randDirection.x, randDirection.x), 0, Random.Range(-randDirection.z, randDirection.z));
                onColl?.Invoke(collision, direction + randomizedDirection);
            }
            else
            {
                onColl?.Invoke(collision, direction);
            }
        }
    }
    public delegate void TriggerStay(bool onTriggerStay);
    public event TriggerStay onTriggerStay;

    public delegate void TriggerEnter(bool onTriggerEnter);
    public event TriggerEnter onTriggerEnter;

    public delegate void Contact(bool onContact);
    public event Contact onContact;

    public delegate void Coll(Collision collision, Vector3 direction);
    public event Coll onColl;
    
}

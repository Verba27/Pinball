using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private MyParticlesSystems particles;
    [SerializeField] private MyInteractions interactions;
    [SerializeField] private ScoreValue scoreValue;
    [SerializeField] private MyQuest quest;
    [SerializeField] private ForceType force;
    [SerializeField] private MySounds sound;

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
            onColl?.Invoke(true, null, force, direction, particles, interactions, 0, quest, 0);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ball"))
        {
            onColl?.Invoke(true, null, force, direction, particles, interactions, scoreValue, quest, sound);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (random)
            {
                var randomizedDirection = new Vector3(
                    Random.Range(-randDirection.x, randDirection.x),
                    0,
                    Random.Range(-randDirection.z, randDirection.z)
                    );
                onColl?.Invoke(true, collision, force, direction + randomizedDirection, particles, interactions, scoreValue, quest, sound);
            }
            else
            {
                onColl?.Invoke(true, collision, force, direction, particles, interactions, scoreValue, quest, sound);
            }
        }
    }
    
    public delegate void Coll(
        bool onContact,
        Collision collision,
        ForceType force,
        Vector3 direction,
        MyParticlesSystems particles,
        MyInteractions interactions,
        ScoreValue scoreValue,
        MyQuest quest,
        MySounds sound
        );
    public event Coll onColl;
    
}

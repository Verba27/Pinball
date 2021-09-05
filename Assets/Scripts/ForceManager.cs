using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ForceType
{
    NoForce,
    DirectForce,
    GearForce,
    SaverForce,
    BlockinForce,
    Destroy
}
public class ForceManager : MonoBehaviour
{
    [SerializeField] private float forceCylinder = 2f;
    [SerializeField] private float minSpeed = 5f;
    [SerializeField] private float speeder = 1.1f;
    [SerializeField] private Vector3 blockFieldForce;

    public void DoForce(ForceType force, Collision collision, Vector3 direction)
    {
        switch (force)
        {
            case ForceType.NoForce:
                break;
            case ForceType.DirectForce:
                collision.rigidbody.AddForce(direction, ForceMode.Impulse);
                break;
            case ForceType.GearForce:
                Vector3 velocityBeforeContact;
                Vector3 velocityAfterContact;
                ContactPoint contact = collision.contacts[0];
                if (collision.rigidbody.velocity.magnitude < minSpeed)
                {
                    collision.rigidbody.velocity *= speeder;
                }
                velocityBeforeContact = collision.rigidbody.velocity;
                velocityAfterContact = Vector3.Reflect(velocityBeforeContact, contact.normal);
                collision.rigidbody.velocity = velocityAfterContact * forceCylinder;
                break;
            case ForceType.SaverForce:
                StartCoroutine(SideSaveRoutine(collision, direction));
                break;
            case ForceType.BlockinForce:
                GameObject ball = GameObject.FindGameObjectWithTag("Ball");
                ball.GetComponent<Rigidbody>().AddForce(blockFieldForce, ForceMode.VelocityChange);
                break;
            case ForceType.Destroy:
                Destroy(collision.gameObject);
                onDestroy?.Invoke(true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(force), force, null);
        }
    }
    
    public delegate void BallDestroyed(bool onDestroy);
    public event BallDestroyed onDestroy;
    IEnumerator SideSaveRoutine(Collision collision, Vector3 direction)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        collision.rigidbody.AddForce(direction, ForceMode.Impulse);
    }
}

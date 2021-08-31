using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceManager : MonoBehaviour
{
    //[SerializeField] private CollisionDetector bumperTapeLeft;
    //[SerializeField] private CollisionDetector bumperTapeRight;
    //[SerializeField] private CollisionDetector cylinderTop;
    //[SerializeField] private CollisionDetector cylinderLeft;
    //[SerializeField] private CollisionDetector cylinderRight;
    //[SerializeField] private CollisionDetector mainLeft;
    //[SerializeField] private CollisionDetector mainRight;
    //[SerializeField] private CollisionDetector sparks;
    //[SerializeField] private CollisionDetector saverLeft;
    //[SerializeField] private CollisionDetector saverRight;
    //[SerializeField] private CollisionDetector blockingField;
    //[SerializeField] private CollisionDetector wallSteam;
    //[SerializeField] private CollisionDetector pyramindLeft;
    //[SerializeField] private CollisionDetector pyramindRight;
    [SerializeField] private float forceCylinder = 2f;
    [SerializeField] private float minSpeed = 5f;
    [SerializeField] private float speeder = 1.1f;
    [SerializeField] private Vector3 blockFieldForce;
    void Start()
    {
        //cylinderTop.onColl += BumpCylinderCollision;
        //cylinderLeft.onColl += BumpCylinderCollision;
        //cylinderRight.onColl += BumpCylinderCollision;
        //sparks.onColl += BumpTapeCollision;
        //bumperTapeLeft.onColl += BumpTapeCollision;
        //bumperTapeRight.onColl += BumpTapeCollision;
        //mainLeft.onColl += BumpTapeCollision;
        //mainRight.onColl += BumpTapeCollision;
        //pyramindLeft.onColl += BumpTapeCollision;
        //pyramindRight.onColl += BumpTapeCollision;
        //wallSteam.onColl += BumpTapeCollision;
        //saverLeft.onColl += SideSaver;
        //saverRight.onColl += SideSaver;

    }

    //private void BumpCylinderCollision(Collision collision, Vector3 direction)
    //{
    //    CylinderForce(collision);
    //}
    //private void BumpTapeCollision(Collision collision, Vector3 direction)
    //{
    //    DirectForce(collision, direction);
    //}
    public void SideSaver(Collision collision, Vector3 direction)
    {
        StartCoroutine(SideSaveRoutine(collision, direction));
    }
    public void CylinderForce(Collision collision)
    {
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
    }
    public void DirectForce(Collision collision, Vector3 direction)
    {
        collision.rigidbody.AddForce(direction, ForceMode.Impulse);
    }

    IEnumerator SideSaveRoutine(Collision collision, Vector3 direction)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        collision.rigidbody.AddForce(direction, ForceMode.Impulse);
        //onSave?.Invoke(true);
    }
    //public delegate void FallSaved(bool onSave);
    //public event FallSaved onSave;

    public void BlockingFieldForce()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        ball.GetComponent<Rigidbody>().AddForce(blockFieldForce,ForceMode.VelocityChange);
        //collision.rigidbody.velocity = blockFieldForce;
    }
    
}

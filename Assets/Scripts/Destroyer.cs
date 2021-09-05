using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Ball"))
        {
            Destroy(collider.gameObject);
            onDestroy?.Invoke(true);
        }
    }

    public delegate void BallDestroyed(bool onDestroy);

    public event BallDestroyed onDestroy;
}

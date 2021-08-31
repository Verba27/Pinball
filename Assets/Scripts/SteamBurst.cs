using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamBurst : MonoBehaviour
{
    [SerializeField] private ParticleSystem exp;

    void Start()
    {
        exp = GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Explode();
        exp.Play();
        Debug.Log("pshhh");
        //if (collision.transform.tag == "Ball")
        //{
        //    Explode();
        //}
        
    }
    void Explode()
    {
        exp.Play();
        //Destroy(gameObject, exp.main.duration);
    }
}

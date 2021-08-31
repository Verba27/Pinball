using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem launchSteamParticle;
    [SerializeField]
    private ParticleSystem blockingSteamParticle;
    [SerializeField]
    private ParticleSystem wallSteamParticle;
    [SerializeField]
    private ParticleSystem leftAngle;
    [SerializeField]
    private ParticleSystem rightAngle;
    [SerializeField]
    private ParticleSystem sparksParticle;
    [SerializeField]
    private ParticleSystem fallSaverLeftParticle;
    [SerializeField]
    private ParticleSystem fallSaverRightParticle;
    [SerializeField]
    private GameObject blockerLeft;
    [SerializeField]
    private GameObject blockerRight;
    [SerializeField]
    private ParticleSystem thunderLeft;
    [SerializeField]
    private ParticleSystem thunderMiddle;
    [SerializeField]
    private ParticleSystem thunderRight;
    //[SerializeField] private CollisionDetector blockingField;
    //[SerializeField] private CollisionDetector sparks;
    //[SerializeField] private CollisionDetector wallSteam;

    void Start()
    {
        //blockingField.onContact += BlockingFieldOn;
        //sparks.onContact += SparkParticleOn;
        //wallSteam.onContact += WallSteamOn;
    }

    public void BlockingFieldOn()
    {
        blockingSteamParticle.Play();
    }
    public void SparkParticleOn()
    {
        sparksParticle.Play();
    }
    public void WallSteamOn()
    {
        wallSteamParticle.Play();
    }
    public void AngleSteamOn()
    {
        leftAngle.Play();
        rightAngle.Play();
    }
    public void FallSaverLeftParticleOn()
    {
        fallSaverLeftParticle.Play();
        blockerLeft.GetComponent<MeshCollider>().isTrigger = false;
    }
    public void FallSaverRightParticleOn()
    {
        fallSaverRightParticle.Play();
        blockerRight.GetComponent<MeshCollider>().isTrigger = false;
    }

    public void ThunderLeftOn()
    {
        thunderLeft.Play();
    }
    public void ThunderMiddleOn()
    {
        thunderMiddle.Play();
    }
    public void ThunderRightOn()
    {
        thunderRight.Play();
    }
}

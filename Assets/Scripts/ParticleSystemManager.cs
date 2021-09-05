using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MyParticlesSystems
{
    NoParticles,
    LaunchSteamParticle,
    BlockingSteamParticle,
    WallSteamParticle,
    SideAngles,
    SparksParticle,
    FallSaverLeftParticle,
    FallSaverRightParticle,
    ThunderLeft,
    ThunderMiddle,
    ThunderRight
}

public class ParticleSystemManager : MonoBehaviour
{


    [SerializeField] private ParticleSystem launchSteamParticle;
    [SerializeField] private ParticleSystem blockingSteamParticle;
    [SerializeField] private ParticleSystem wallSteamParticle;
    [SerializeField] private ParticleSystem leftAngle;
    [SerializeField] private ParticleSystem rightAngle;
    [SerializeField] private ParticleSystem sparksParticle;
    [SerializeField] private ParticleSystem fallSaverLeftParticle;
    [SerializeField] private ParticleSystem fallSaverRightParticle;
    [SerializeField] private GameObject blockerLeft;
    [SerializeField] private GameObject blockerRight;
    [SerializeField] private ParticleSystem thunderLeft;
    [SerializeField] private ParticleSystem thunderMiddle;
    [SerializeField] private ParticleSystem thunderRight;


    public void PlayParticles(MyParticlesSystems system)
    {
        switch (system)
        {
            case MyParticlesSystems.NoParticles:
                break;
            case MyParticlesSystems.LaunchSteamParticle:
                launchSteamParticle.Play();
                break;
            case MyParticlesSystems.BlockingSteamParticle:
                blockingSteamParticle.Play();
                break;
            case MyParticlesSystems.WallSteamParticle:
                wallSteamParticle.Play();
                break;
            case MyParticlesSystems.SideAngles:
                leftAngle.Play();
                rightAngle.Play();
                break;
            case MyParticlesSystems.SparksParticle:
                sparksParticle.Play();
                break;
            case MyParticlesSystems.FallSaverLeftParticle:
                fallSaverLeftParticle.Play();
                blockerLeft.GetComponent<MeshCollider>().isTrigger = false;
                break;
            case MyParticlesSystems.FallSaverRightParticle:
                fallSaverRightParticle.Play();
                blockerRight.GetComponent<MeshCollider>().isTrigger = false;
                break;
            case MyParticlesSystems.ThunderLeft:
                thunderLeft.Play();
                break;
            case MyParticlesSystems.ThunderMiddle:
                thunderMiddle.Play();
                break;
            case MyParticlesSystems.ThunderRight:
                thunderRight.Play();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(system), system, null);
        }


    }



//    public void BlockingFieldOn()
//    {
//        blockingSteamParticle.Play();
//    }
//    public void SparkParticleOn()
//    {
//        sparksParticle.Play();
//    }
//    public void WallSteamOn()
//    {
//        wallSteamParticle.Play();
//    }
//    public void AngleSteamOn()
//    {
//        leftAngle.Play();
//        rightAngle.Play();
//    }
//    public void FallSaverLeftParticleOn()
//    {
//        fallSaverLeftParticle.Play();
//        blockerLeft.GetComponent<MeshCollider>().isTrigger = false;
//    }
//    public void FallSaverRightParticleOn()
//    {
//        fallSaverRightParticle.Play();
//        blockerRight.GetComponent<MeshCollider>().isTrigger = false;
//    }

//    public void ThunderLeftOn()
//    {
//        thunderLeft.Play();
//    }
//    public void ThunderMiddleOn()
//    {
//        thunderMiddle.Play();
//    }
//    public void ThunderRightOn()
//    {
//        thunderRight.Play();
//    }




}

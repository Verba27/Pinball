using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    [SerializeField]
    private Rigidbody launchingBall;
    //[SerializeField]
    //private GameObject nozzle;
    [SerializeField]
    private float hitForceMax = 10f;
    [SerializeField]
    private float chargeTimer = 2f;
    [SerializeField]
    private float hitForceCharged;
    
    [SerializeField]
    private ParticleSystemManager particle;
    [SerializeField]
    private AudioManager audio;
    private Coroutine coroutine;
    private bool isOnLaunchPosition;
    private bool canCreateBall;
    private bool multiballOn;
    private List<GameObject[]> numberOfBalls;
    private Rigidbody otherBall;
    private Vector3 startBallPosition;
    private Vector3 launchDirection;
    void Start()
    {
        startBallPosition = new Vector3(3.5f, 1.1f, -11.5f);
        isOnLaunchPosition = false;
        launchDirection = new Vector3(0, 0, 100);
    }

    void Update()
    {
        GameObject[] ballInGame;
        numberOfBalls = new List<GameObject[]>();
        ballInGame = GameObject.FindGameObjectsWithTag("Ball");
        numberOfBalls.Add(ballInGame);
        if ((ballInGame.Length == 0) || multiballOn == true)
        {
            canCreateBall = true;
        }
        else
        {
            canCreateBall = false;
        }

        if (Input.GetKey(KeyCode.R))
        {
            if (canCreateBall == true)
            {
                otherBall = Instantiate(launchingBall, startBallPosition, Quaternion.identity);
            }
        }
        if (isOnLaunchPosition == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                coroutine = StartCoroutine(BallLaunch());
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                otherBall.AddForce(launchDirection * hitForceCharged);
                StopCoroutine(coroutine);
                isOnLaunchPosition = false;
                audio.PlaySound(MySounds.LauncherSound);
                particle.PlayParticles(MyParticlesSystems.LaunchSteamParticle);
            }
        }
    }
    
    public void MultiballAction()
    {
        StartCoroutine(MyltiballAddBall());
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Ball"))
        {
            isOnLaunchPosition = true;
        }
    }
    IEnumerator BallLaunch()
    {
        float currentChargeTime = 0;
        while (currentChargeTime <= chargeTimer)
        {
            currentChargeTime += Time.deltaTime;
            hitForceCharged = hitForceMax * (currentChargeTime / chargeTimer);
            yield return null;
        }
    }
    IEnumerator MyltiballAddBall()
    {
        otherBall = Instantiate(launchingBall, startBallPosition, Quaternion.identity);
        particle.PlayParticles(MyParticlesSystems.LaunchSteamParticle);
        otherBall.AddForce(launchDirection * hitForceMax);
        audio.PlaySound(MySounds.LauncherSound);
        yield return new WaitForSecondsRealtime(1);
        otherBall = Instantiate(launchingBall, startBallPosition, Quaternion.identity);
        particle.PlayParticles(MyParticlesSystems.LaunchSteamParticle);
        otherBall.AddForce(launchDirection * hitForceMax);
    }
}
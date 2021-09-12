using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    [SerializeField]
    private Rigidbody launchingBall;
    [SerializeField]
    private float hitForceMax = 10f;
    [SerializeField]
    private ParticleSystemManager particle;
    [SerializeField]
    private AudioManager audioManager;
    private Coroutine coroutine;
    private bool isPlaying;
    private bool isOnLaunchPosition;
    private bool canCreateBall;
    private bool multiballOn;
    private List<GameObject[]> numberOfBalls;
    private Rigidbody otherBall;
    private Vector3 startBallPosition;
    private Vector3 launchDirection;
    void Start()
    {
        startBallPosition = new Vector3(3.5f, 1.05f, -11.5f);
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
        
    }
    public delegate void Created(bool ballCreated);
    public event Created ballCreated;

    public void GiveBall()
    {
        if (isPlaying == false)
        {
            coroutine = StartCoroutine(WaitforStart());

        }
        if(canCreateBall == true && isPlaying == true)
        {
            otherBall = Instantiate(launchingBall, startBallPosition, Quaternion.identity);
            ballCreated?.Invoke(true);
        }
    }
    
    public void Launch()
    {
        if (isOnLaunchPosition == true)
        {
            otherBall.AddForce(launchDirection * hitForceMax);
            isOnLaunchPosition = false;
            audioManager.PlaySound(MySounds.LauncherSound);
            particle.PlayParticles(MyParticlesSystems.LaunchSteamParticle);
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
    IEnumerator MyltiballAddBall()
    {
        otherBall = Instantiate(launchingBall, startBallPosition, Quaternion.identity);
        particle.PlayParticles(MyParticlesSystems.LaunchSteamParticle);
        otherBall.AddForce(launchDirection * hitForceMax);
        audioManager.PlaySound(MySounds.LauncherSound);
        yield return new WaitForSecondsRealtime(1);
        otherBall = Instantiate(launchingBall, startBallPosition, Quaternion.identity);
        particle.PlayParticles(MyParticlesSystems.LaunchSteamParticle);
        otherBall.AddForce(launchDirection * hitForceMax);
    }

    IEnumerator WaitforStart()
    {
        yield return new WaitForSecondsRealtime(1);
        isPlaying = true;
    }
}
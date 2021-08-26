using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    
    [SerializeField] private GameObject plunger;
    private Vector3 scaleChange;
    [SerializeField]
    private Rigidbody launchingBall;
    [SerializeField] private GameObject prefabBall;
    
    [SerializeField]
    private float hitForceMax = 10f;
    [SerializeField]
    private float chargeTimer = 2f;
    [SerializeField]
    private float hitForceCharged;
    private Coroutine coroutine;
    private Vector3 plungerNormalScale;
    [SerializeField]
    private bool isOnLaunch;

    private bool isCreated;

    public Rigidbody otherBall;
    private Vector3 startBallPosition;
    private Vector3 launchDirection;

    void Start()
    {
        startBallPosition = new Vector3(3.5f,1.1f,-7.5f);
        isOnLaunch = false;
        launchDirection = new Vector3(0,0,100);
        scaleChange = new Vector3(0f, -0.005f, 0f);
        plungerNormalScale = plunger.transform.localScale;

        isCreated = false;
    }
    
    void Update()
    {
        
        if (Input.GetKey(KeyCode.R))
        {
            if (isCreated == false)
            {
                StartCoroutine(Creator());
            }
        }
        if (isOnLaunch == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                coroutine = StartCoroutine(BallLaunch());
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                otherBall.AddForce(launchDirection * hitForceCharged);
                StopCoroutine(coroutine);
                plunger.transform.localScale = plungerNormalScale;
                isOnLaunch = false;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Ball"))
        {
            isOnLaunch = true;
        }
    }

    IEnumerator Creator()
    {
        otherBall = Instantiate(launchingBall, startBallPosition, Quaternion.identity);
        isCreated = true;
        
        yield return new WaitForSecondsRealtime(5);
        isCreated = false;
    }
    IEnumerator BallLaunch()
    {
        float currentChargeTime = 0;
        
        while (currentChargeTime <= chargeTimer)
        {
            currentChargeTime += Time.deltaTime;
            plunger.transform.localScale += scaleChange; 
            hitForceCharged = hitForceMax * (currentChargeTime / chargeTimer);

            yield return null;
        }
        
        
    }
}

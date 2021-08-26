using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperMove : MonoBehaviour
{
    [SerializeField] private Rigidbody rightFlipperRb;
    [SerializeField] private Rigidbody leftFlipperRb;
    [SerializeField] private float spinForce = 35;
    private Vector3 rightAngleVelocity;
    private Vector3 leftAngleVelocity;

    private bool leftUp;
    private bool leftDown;
    private bool rightUp;
    private bool rightDown;

    private Quaternion startLeftQuaternion;
    private Quaternion leftQuaternion;
    private Quaternion startRightQuaternion;
    private Quaternion rightQuaternion;
    void Start()
    {
        startLeftQuaternion = leftFlipperRb.transform.rotation;
        startRightQuaternion = rightFlipperRb.transform.rotation;
        rightAngleVelocity = new Vector3(0, 70, 0);
        leftAngleVelocity = new Vector3(0, -70, 0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftUp = true;
            leftDown = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            leftUp = false;
            leftDown = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightUp = true;
            rightDown = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rightUp = false;
            rightDown = true;
        }
    }
    void FixedUpdate()
    {
        if (leftUp)
        {
            leftQuaternion = Quaternion.Lerp(leftQuaternion, Quaternion.Euler(leftAngleVelocity), Time.fixedDeltaTime * spinForce);
            leftFlipperRb.MoveRotation(startLeftQuaternion * leftQuaternion);
        }

        if (leftDown)
        {
            leftQuaternion = Quaternion.Lerp(leftQuaternion, Quaternion.identity, Time.fixedDeltaTime * spinForce);
            leftFlipperRb.MoveRotation(startLeftQuaternion * leftQuaternion);
        }
        if (rightUp)
        {
            rightQuaternion = Quaternion.Lerp(rightQuaternion, Quaternion.Euler(rightAngleVelocity), Time.fixedDeltaTime * spinForce);
            rightFlipperRb.MoveRotation(startRightQuaternion * rightQuaternion);
        }

        if (rightDown)
        {
            rightQuaternion = Quaternion.Lerp(rightQuaternion, Quaternion.identity, Time.fixedDeltaTime * spinForce);
            rightFlipperRb.MoveRotation(startRightQuaternion * rightQuaternion);
        }
    }
}

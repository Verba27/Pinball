using UnityEngine;

public class FlipperMove : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Rigidbody rightFlipperRb;
    [SerializeField] private Rigidbody leftFlipperRb;
    [SerializeField] private float spinForce = 35;
    private Vector3 rightAngleVelocity;
    private Vector3 leftAngleVelocity;

    private bool leftFlipper;
    private bool rightFlipper;
    
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

    public void OnLeftUp()
    {
        leftFlipper = false;
        audioManager.PlaySound(MySounds.FlipperSound);
    }
    public void OnLeftDown()
    {
        leftFlipper = true;
        audioManager.PlaySound(MySounds.FlipperSound);
    }
    public void OnRightUp()
    {
        rightFlipper = false;
        audioManager.PlaySound(MySounds.FlipperSound);
    }
    public void OnRightDown()
    {
        rightFlipper = true;
        audioManager.PlaySound(MySounds.FlipperSound);
    }
    
    void FixedUpdate()
    {
        if (leftFlipper)
        {
            leftQuaternion = Quaternion.Lerp(leftQuaternion, Quaternion.Euler(leftAngleVelocity), Time.fixedDeltaTime * spinForce);
            leftFlipperRb.MoveRotation(startLeftQuaternion * leftQuaternion);
        }

        if (leftFlipper == false)
        {
            leftQuaternion = Quaternion.Lerp(leftQuaternion, Quaternion.identity, Time.fixedDeltaTime * spinForce);
            leftFlipperRb.MoveRotation(startLeftQuaternion * leftQuaternion);
        }
        if (rightFlipper)
        {
            rightQuaternion = Quaternion.Lerp(rightQuaternion, Quaternion.Euler(rightAngleVelocity), Time.fixedDeltaTime * spinForce);
            rightFlipperRb.MoveRotation(startRightQuaternion * rightQuaternion);
        }

        if (rightFlipper == false)
        {
            rightQuaternion = Quaternion.Lerp(rightQuaternion, Quaternion.identity, Time.fixedDeltaTime * spinForce);
            rightFlipperRb.MoveRotation(startRightQuaternion * rightQuaternion);
        }
    }
}

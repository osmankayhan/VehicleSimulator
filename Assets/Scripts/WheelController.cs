using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float acceleration = 500f;
    public float breakingForce = 350f;
    public float maxTurnAngle = 20f;

    private float currentAccceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    private void FixedUpdate()
    {
        currentAccceleration = acceleration * Input.GetAxisRaw("Vertical");

        //El Freni Sistemi
        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingForce;
        else
            currentBreakForce = 0f;


        frontRight.motorTorque = currentAccceleration;
        frontLeft.motorTorque = currentAccceleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;

        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxisRaw("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(backLeft, backLeftTransform);

        DefaultRotation();
    }

    void UpdateWheel(WheelCollider _collider, Transform _transform)
    {
        Vector3 position;
        Quaternion rotation;
        _collider.GetWorldPose(out position, out rotation);
        _transform.position = position;
        _transform.rotation = rotation;
    }

    void DefaultRotation()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            transform.rotation = Quaternion.Euler(0f, transform.position.y, 0f);
        }
    }
}
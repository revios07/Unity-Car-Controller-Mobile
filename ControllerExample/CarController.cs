using UnityEngine;

public class CarController : CarCollision
{
    private float horizontalInput, v;

    //Wheel Colliders
    [SerializeField] WheelCollider frontRightW, frontLeftW;
    [SerializeField] WheelCollider rearRightW, rearLeftW;

    [SerializeField] Transform frontRightT, frontLeftT;
    [SerializeField] Transform rearRightT, rearLeftT;


    private void Update()
    {
        Inputs();
    }

    void FixedUpdate()
    {
        FrontWheelsGas();
        FrontWheelsDirection();
        RearWhellsBreak();
    }

    private void LateUpdate()
    {
        UpdateWheelPosses();
    }

    private void Inputs()
    {

        if (Input.touchCount > 0)
        {
            v = 1.0f;
            horizontalInput += Input.touches[0].deltaPosition.x * sensitivity * Time.deltaTime ;

            Debug.Log(horizontalInput);
           
            horizontalInput = Mathf.Clamp(horizontalInput, -1f, 1f);
        }
        else
        {
            horizontalInput = Mathf.Lerp(horizontalInput, 0.0f, 10 * Time.deltaTime);
        }
    }

    private void FrontWheelsGas()
    {
        rearLeftW.motorTorque = v * frontSpeed + (50f * horizontalInput);
        rearRightW.motorTorque = v * frontSpeed + (50f * horizontalInput);
    }
    //Direction Change To Front Wheels With Input
    private void FrontWheelsDirection()
    {
        frontLeftW.steerAngle = horizontalInput * maxTurnSpeed;
        frontRightW.steerAngle = horizontalInput * maxTurnSpeed;
    }

    private void RearWhellsBreak()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rearLeftW.brakeTorque = breakForce;
            rearRightW.brakeTorque = breakForce;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rearLeftW.brakeTorque = 0;
            rearRightW.brakeTorque = 0;
        }
    }
    
    //Turn Effect Wheel
    private void UpdateWheelPos(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);
        _transform.rotation = _quat;
    }

    private void UpdateWheelPosses()
    {
        UpdateWheelPos(frontRightW, frontRightT);
        UpdateWheelPos(frontLeftW, frontLeftT);
        UpdateWheelPos(rearRightW, rearRightT);
        UpdateWheelPos(rearLeftW, rearLeftT);
    }
}

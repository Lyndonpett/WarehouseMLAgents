using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forklift : MonoBehaviour
{
    public GameObject fork;
    public float drivespeed = 5f;
    public float turnspeed = 3f;
    public float forkSpeed = 2f;
    public float forkStartPos;
    public GameObject WheelColliders, Wheels;
    public WheelCollider LFwheel, RFwheel, LBwheel, RBwheel;
    public GameObject LFwheelMesh, RFwheelMesh, LBwheelMesh, RBwheelMesh;
    private void Start()
    {
        fork = transform.GetChild(0).gameObject;
        WheelColliders = transform.GetChild(3).gameObject;
        Wheels = transform.GetChild(2).gameObject;
        LBwheel = WheelColliders.transform.GetChild(0).gameObject.GetComponent<WheelCollider>();
        LFwheel = WheelColliders.transform.GetChild(1).gameObject.GetComponent<WheelCollider>();
        RBwheel = WheelColliders.transform.GetChild(2).gameObject.GetComponent<WheelCollider>();
        RFwheel = WheelColliders.transform.GetChild(3).gameObject.GetComponent<WheelCollider>();
        LBwheelMesh = Wheels.transform.GetChild(0).gameObject;
        LFwheelMesh = Wheels.transform.GetChild(1).gameObject;
        RBwheelMesh = Wheels.transform.GetChild(2).gameObject;
        RFwheelMesh = Wheels.transform.GetChild(3).gameObject;
        forkStartPos = fork.transform.position.y;
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    // move up and down
    private void Update()
    {
        UpdateWheelPose(LBwheel, LBwheelMesh.transform);
        UpdateWheelPose(LFwheel, LFwheelMesh.transform);
        UpdateWheelPose(RBwheel, RBwheelMesh.transform);
        UpdateWheelPose(RFwheel, RFwheelMesh.transform);
        

        if (Input.GetKey(KeyCode.E) && fork.transform.position.y < forkStartPos + 8)
        {
            fork.transform.Translate(Vector3.up * forkSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.C) && fork.transform.position.y > forkStartPos)
        {
            fork.transform.Translate(Vector3.down * forkSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            LBwheel.motorTorque = 500f;
            LFwheel.motorTorque = 500f;
            RBwheel.motorTorque = 500f;
            RFwheel.motorTorque = 500f;       
        }
        else if(Input.GetKey(KeyCode.S))
        {
            LBwheel.motorTorque = -500f;
            LFwheel.motorTorque = -500f;
            RBwheel.motorTorque = -500f;
            RFwheel.motorTorque = -500f;
        }
        else
        {
            LBwheel.motorTorque = 0f;
            LFwheel.motorTorque = 0f;
            RBwheel.motorTorque = 0f;
            RFwheel.motorTorque = 0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            LBwheel.steerAngle -= 25f * Time.deltaTime;
            RBwheel.steerAngle -= 25f * Time.deltaTime;
            LBwheel.steerAngle = Mathf.Clamp(LBwheel.steerAngle, -30f, 30f);
            RBwheel.steerAngle = Mathf.Clamp(RBwheel.steerAngle, -30f, 30f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            LBwheel.steerAngle += 25f * Time.deltaTime;
            RBwheel.steerAngle += 25f * Time.deltaTime;
            LBwheel.steerAngle = Mathf.Clamp(LBwheel.steerAngle, -30f, 30f);
            RBwheel.steerAngle = Mathf.Clamp(RBwheel.steerAngle, -30f, 30f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            LBwheel.brakeTorque = 1000f;
            LFwheel.brakeTorque = 1000f;
            RBwheel.brakeTorque = 1000f;
            RFwheel.brakeTorque = 1000f;
        }
        else
        {
            LBwheel.brakeTorque = 0f;
            LFwheel.brakeTorque = 0f;
            RBwheel.brakeTorque = 0f;
            RFwheel.brakeTorque = 0f;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            // grab fork game object then rotate on x axis
            fork.transform.Rotate(Vector3.left * 2f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            // grab fork game object then rotate on x axis
            fork.transform.Rotate(Vector3.right * 2f * Time.deltaTime);
        }
    }   
}

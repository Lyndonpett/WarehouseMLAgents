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

    // move up and down
    private void Update()
    {
        LFwheelMesh.transform.position = LFwheel.transform.position;
        LFwheelMesh.transform.rotation = LFwheel.transform.rotation;

        RFwheelMesh.transform.position = RFwheel.transform.position;
        RFwheelMesh.transform.rotation = RFwheel.transform.rotation;

        LBwheelMesh.transform.rotation = LBwheel.transform.rotation;
        RBwheelMesh.transform.rotation = RBwheel.transform.rotation;

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
            LFwheel.steerAngle -= 10f * Time.deltaTime;
            RFwheel.steerAngle -= 10f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            LFwheel.steerAngle += 10f * Time.deltaTime;
            RFwheel.steerAngle += 10f * Time.deltaTime;
        }
        else
        {
            LFwheel.steerAngle = 0f;
            RFwheel.steerAngle = 0f;
        }
    }
}

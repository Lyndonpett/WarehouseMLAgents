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
    public Rigidbody LFwheel, RFwheel, LBwheel, RBwheel;
    private void Start()
    {
        fork = transform.GetChild(0).gameObject;
        LBwheel = transform.GetChild(2).gameObject.GetComponent<Rigidbody>();
        LFwheel = transform.GetChild(3).gameObject.GetComponent<Rigidbody>();
        RBwheel = transform.GetChild(4).gameObject.GetComponent<Rigidbody>();
        RFwheel = transform.GetChild(5).gameObject.GetComponent<Rigidbody>();
        forkStartPos = fork.transform.position.y;
    }

    // move up and down
    private void Update()
    {

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
            LBwheel.AddTorque(Vector3.forward);
            LFwheel.AddTorque(Vector3.forward);
            RBwheel.AddTorque(Vector3.forward);
            RFwheel.AddTorque(Vector3.forward);
        }
    }
}

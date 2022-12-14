using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forklift : MonoBehaviour
{
    public GameObject fork;
    public float forkSpeed = 2f;

    private void Start()
    {
        fork = transform.GetChild(0).gameObject;
        print(fork);
    }

    // move up and down
    private void Update()
    {

        if (Input.GetKey(KeyCode.E)) fork.transform.Translate(Vector3.up * forkSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.C)) fork.transform.Translate(Vector3.down * forkSpeed * Time.deltaTime);

    }
}

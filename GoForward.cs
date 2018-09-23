using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : MonoBehaviour {

    private Rigidbody rigidBody;
    public float power;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(rigidBody.transform.forward.normalized * power, ForceMode.Acceleration);
	}

}

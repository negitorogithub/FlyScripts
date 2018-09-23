using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StokeRotation : MonoBehaviour {


    public Transform target;
    private Transform myTransform;

    // Use this for initialization
    void Start () {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        myTransform.rotation = target.rotation;
	}
}

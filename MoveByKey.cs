using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour {

    private Rigidbody rigidBody;
    public float playerSpeed;
    private float defaultSpeed = 1f;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
        //操作
        Vector3 vector3toSet = new Vector3();
        if (Input.GetKey("up"))
        {
            vector3toSet.z = defaultSpeed;
        }
        if (Input.GetKey("down"))
        {
            vector3toSet.z = -defaultSpeed;
        }
        if (Input.GetKey("right"))
        {
            vector3toSet.x = defaultSpeed;
        }
        if (Input.GetKey("left"))
        {
            vector3toSet.x = -defaultSpeed;
        }
        if (!Input.anyKey)
        {
            vector3toSet = Vector3.zero;
        }
        vector3toSet.Normalize();
        vector3toSet = vector3toSet * playerSpeed;
        rigidBody.velocity = new Vector3(vector3toSet.x + rigidBody.velocity.x, rigidBody.velocity.y, vector3toSet.z + rigidBody.velocity.z);









    }
}

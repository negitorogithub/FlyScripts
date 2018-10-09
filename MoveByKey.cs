using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour
{

    private Rigidbody rigidBody;
    public float playerSpeed;
    private float defaultSpeed = 1f;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidBody.velocity.magnitude > 1)
        {
            return;
        }


        Vector3 vector3toSet = new Vector3();
        if (Input.GetKey("up"))
        {
            vector3toSet += rigidBody.transform.forward;
        }
        if (Input.GetKey("down"))
        {
            vector3toSet -= rigidBody.transform.forward;
        }
        if (Input.GetKey("right"))
        {
            vector3toSet += rigidBody.transform.right;
        }
        if (Input.GetKey("left"))
        {
            vector3toSet -= rigidBody.transform.right;
        }
        vector3toSet.Normalize();
        vector3toSet = vector3toSet * playerSpeed;
        rigidBody.velocity += vector3toSet;

    }
}

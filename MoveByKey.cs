using UnityEngine;

public class MoveByKey : MonoBehaviour, IPausable
{
    private bool isPausing;
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
        if (isPausing)
        {
            rigidBody.velocity = Vector3.zero;
            return;
        }

        if (!Input.anyKey)
        {
            return;
        }

        Vector3 vector3toSet = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            vector3toSet += rigidBody.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vector3toSet -= rigidBody.transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vector3toSet += rigidBody.transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vector3toSet -= rigidBody.transform.right;
        }

        vector3toSet.y = 0;
        vector3toSet.Normalize();
        vector3toSet = vector3toSet * playerSpeed;
        rigidBody.velocity = vector3toSet;

    }

    public void Pause()
    {
        isPausing = true;
    }

    public void Resume()
    {
        isPausing = false;
    }   
}

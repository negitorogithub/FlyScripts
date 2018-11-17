using UnityEngine;

//羽につける用
public class GlindByKey : MonoBehaviour, IPausable
{
    private bool isPausing;
    private Rigidbody rigidBody;
    public Rigidbody parentRigidBody;　//本体
    private float glindStartedY;
    private Vector3 glindStartedVelocity;

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
            return;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            float deltaY = glindStartedY - parentRigidBody.position.y;
            if (deltaY >= 0)
            {
                parentRigidBody.velocity = parentRigidBody.transform.forward.normalized * Mathf.Sqrt(2 * Physics.gravity.magnitude * deltaY);
            }

        }
        else
        {
            parentRigidBody.useGravity = true;
            glindStartedY = parentRigidBody.position.y;
        }
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


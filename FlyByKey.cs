using UniRx;
using UnityEngine;

public class FlyByKey : MonoBehaviour, IPausable
{
    private Rigidbody rigidBody;
    private Subject<Unit> flySubject;
    private bool isPausing;
    public float power;

    private void Awake()
    {
        flySubject = new Subject<Unit>();
    }

    // Use this for initialization
    void Start()
    {

        rigidBody = GetComponent<Rigidbody>();
        flySubject.ThrottleFirst(System.TimeSpan.FromMilliseconds(400f)).Subscribe(_ => rigidBody.AddForce(Vector3.up * power));
    }

    // Update is called once per frame
    void Update()
    {
        if (isPausing)
        {
            return;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            flySubject.OnNext(Unit.Default);
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

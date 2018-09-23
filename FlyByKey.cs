using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FlyByKey : MonoBehaviour {
    private Rigidbody rigidBody;
    private Subject<Unit> flySubject;

    public float power;

    private void Awake()
    {
        flySubject = new Subject<Unit>();
    }

    // Use this for initialization
    void Start () {
        
        rigidBody = GetComponent<Rigidbody>();
        flySubject.ThrottleFirst(System.TimeSpan.FromMilliseconds(400f)).Subscribe(_ => rigidBody.AddForce(Vector3.up * power));
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            flySubject.OnNext(Unit.Default);
        }
    }
}

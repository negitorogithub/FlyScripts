using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class FlapByKey : MonoBehaviour
{

    private Rigidbody rigidBody;
    private Subject<Unit> wingUpSubject;

    public Rigidbody parentRigidBody;
    public float power;

    private Subject<Unit> wingDownSubject;
    private Subject<Unit> parentUpSubject;

    // Use this for initialization
    void Start()
    {
        wingUpSubject = new Subject<Unit>();
        wingDownSubject = new Subject<Unit>();
        parentUpSubject = new Subject<Unit>();

        rigidBody = GetComponent<Rigidbody>();
        wingUpSubject
            .ThrottleFirst(System.TimeSpan.FromMilliseconds(500f))

            .Subscribe(_ =>
            {
                rigidBody.AddForceAtPosition((transform.right.normalized + Vector3.up.normalized).normalized * 0.2f, transform.position);
                wingDownSubject.OnNext(Unit.Default);
            }
            );


        wingDownSubject
            .Delay(System.TimeSpan.FromMilliseconds(100f))
            .Subscribe(
            _ =>
            {
                rigidBody.AddForceAtPosition(Vector3.down.normalized.normalized * 0.2f, transform.position);
                parentUpSubject.OnNext(Unit.Default);


            }
            );

        parentUpSubject
            .Delay(System.TimeSpan.FromMilliseconds(200f))
            .Subscribe(_ =>
            {
                parentRigidBody.AddForceAtPosition(parentRigidBody.transform.up.normalized * power, parentRigidBody.transform.position);
            }
            );


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            wingUpSubject.OnNext(Unit.Default);
        }
    }
}

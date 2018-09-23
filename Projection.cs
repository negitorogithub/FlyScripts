using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Projection : MonoBehaviour {

    public GameObject target;
    public float intervalMilliSeconds;
    private Rigidbody rigidBodyOfTarget;
    private Transform transform_;
    private Subject<Unit> projectionSubject;
    new private ParticleSystem particleSystem;
    

    // Use this for initialization
    void Start () {
        transform_ = transform;
        Instantiate(target, transform_.position, transform_.rotation);
        rigidBodyOfTarget = target.GetComponent<Rigidbody>();
        projectionSubject = new Subject<Unit>();
        projectionSubject
            .ThrottleFirst(System.TimeSpan.FromMilliseconds(intervalMilliSeconds))
            .Subscribe(_ =>
        {
            Instantiate(target, transform_.position, transform_.rotation);

        }

        );
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            projectionSubject.OnNext(Unit.Default);
        }


    }
}

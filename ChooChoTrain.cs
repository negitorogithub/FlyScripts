using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using static UnityEngine.Mathf;

public class ChooChoTrain : MonoBehaviour {

    private PropagetionSubjects propagetionSubjects;
    private Rigidbody rigidBody;
    public float speed;
    private bool isStarted = false;
    private float currentDegree = 180;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        propagetionSubjects = GetComponent<PropagetionSubjects>();
        propagetionSubjects.subject.Subscribe(_ => {
            isStarted = true;
            });
    }

    private void Update()
    {
        if (isStarted)
        {
            rigidBody.velocity = new Vector3(Cos(currentDegree * Deg2Rad), Sin(currentDegree * Deg2Rad), 0);
            currentDegree += speed;
        }
    }
}

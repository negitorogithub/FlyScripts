using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PropagetionSubjects : MonoBehaviour {

    public PropagetionSubjects propagetionSubjects2Receive;
    public Subject<Unit> subject { get; private set; } 
    public float delaySecondsFromReceiving;

    private void Awake()
    {
        subject = new Subject<Unit>();
    }

    private void Start()
    {
        if (propagetionSubjects2Receive == null)
        {
            Observable.Return(Unit.Default).Delay(System.TimeSpan.FromSeconds(delaySecondsFromReceiving)).Subscribe(_ => subject.OnNext(Unit.Default));
        }
        else
        {
            propagetionSubjects2Receive.subject.Delay(System.TimeSpan.FromSeconds(delaySecondsFromReceiving)).Subscribe(_ => subject.OnNext(Unit.Default));
        }
    }
}

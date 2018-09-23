using UnityEngine;
using System.Collections;
using UniRx;

public class HpHolder : MonoBehaviour
{
    public float maxHp { get; private set; }
    public ReactiveProperty<float> hp;
    public Subject<Unit> deadSubject;
    public Subject<float> onDamagedSubject;
    private RobotParameters robotParameters;
    private float hpDebuffLevarage;
    private ReactiveProperty<float> hpDebuffLevel;

    public void Awake()
    {
        hpDebuffLevel = new ReactiveProperty<float>(1);
        robotParameters = GetComponent<RobotParameterHolder>().robotParameter;
        maxHp = robotParameters.hp;
        hp = new ReactiveProperty<float>(maxHp);
        deadSubject = new Subject<Unit>();
        onDamagedSubject = new Subject<float>();
    }

    public void Start()
    {
        hp.Subscribe(value => {

            if (value <= 0)
            {
                deadSubject.OnNext(Unit.Default);
            }
            value = Mathf.Max(0, value);
        });
        hpDebuffLevarage = 1;
        hpDebuffLevel.Subscribe(
            value => { hpDebuffLevarage = 1 + robotParameters.hpDebuffLevarege * Mathf.Sqrt(value - 1) ; }
            );
    }
    public void ReduceHp(float value)
    {
        hp.Value -= value * hpDebuffLevarage;
        Debug.Log("Damaged"+value * hpDebuffLevarage);
        onDamagedSubject.OnNext(value);
    }


    public void PlusHpDebuffLevel(int level = 1)
    {
        hpDebuffLevel.Value = hpDebuffLevel.Value + level;
        if (hpDebuffLevel.Value > robotParameters.maxHpDebuffLevel)
        {
            hpDebuffLevel.Value = robotParameters.maxHpDebuffLevel;
        }
    }

    public void MinusHpDebuffLecel(int level = 1)
    {
        hpDebuffLevel.Value = hpDebuffLevel.Value - level;
        if (hpDebuffLevel.Value < 1)
        {
            hpDebuffLevel.Value = 1;
        }
    }
    private void Update()
    {
    }
    public void FillHp()
    {
        hp.Value = maxHp;
    }

}

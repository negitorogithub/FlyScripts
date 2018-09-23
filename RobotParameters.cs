using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RobotParameters : MonoBehaviour
{

    public LevaragesHolderByDifficuly difficultyLevarageHolder;
    [SerializeField]
    float hpOrigin;

    [SerializeField]
    float attackOrigin;
    [SerializeField]
    float moveSpeedOrigin;
    [SerializeField]
    float shotSpeedOrigin;
    [SerializeField]
    float shotIntervalSecondOrigin;
    [SerializeField]
    float hpDebuffLevarageOrigin;
    [SerializeField]
    float speedDebuffLevarageOrigin;
    public int maxHpDebuffLevel;
    public int maxSpeedDebuffLevel;


    [HideInInspector]
    public Sprite sprite;
    [HideInInspector]
    public float hp;
    [HideInInspector]
    public float attack;
    [HideInInspector]
    public float moveSpeed;
    [HideInInspector]
    public float shotSpeed;
    [HideInInspector]
    public float shotIntervalSecond;
    [HideInInspector]
    public float hpDebuffLevarege;
    [HideInInspector]
    public float speedDebuffLevarage;





    private void Awake()
    {
        Levarages currentLevarages = difficultyLevarageHolder.currentLevarages;
        hp = hpOrigin * currentLevarages.hpLevarage;
        attack = attackOrigin * currentLevarages.attackLevarage;
        moveSpeed = moveSpeedOrigin * currentLevarages.moveSpeedLevarage;
        shotSpeed = shotSpeedOrigin * currentLevarages.shotSpeedLevarage;
        shotIntervalSecond = shotIntervalSecondOrigin * currentLevarages.shotIntervalLevarage;
        hpDebuffLevarege = hpDebuffLevarageOrigin * currentLevarages.hpDebuffLevarage;
        speedDebuffLevarage = speedDebuffLevarageOrigin * currentLevarages.speedDebuffLevarage;

    }

    private void Update()
    {
        
    }





}

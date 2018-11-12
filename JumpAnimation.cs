using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;

public class JumpAnimation : MonoBehaviour {

    public ConstantScenarioModelOfNPC model;
    public new Transform transform;

    private void Start()
    {
        model.loadConstant.onShowText.Subscribe(
            _ => transform.DOLocalJump(transform.localPosition ,jumpPower: 0.5f, numJumps: 1, duration: 0.4f )
            );
    }

}

using UnityEngine;
using System.Collections;
using UniRx;
using DG.Tweening;

public class SubscribeNPCText2Baloon : MonoBehaviour
{
    public new Transform transform;
    public float jumpPower;
    public float duration;


    private void Start()
    {
        ConstantScenarioModelOfNPC.onShowText.Subscribe(
            _ => transform.DOLocalJump(transform.localPosition, jumpPower: jumpPower, numJumps: 1, duration: duration)
            );
    }
}

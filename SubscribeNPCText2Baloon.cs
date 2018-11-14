using UnityEngine;
using System.Collections;
using UniRx;
using DG.Tweening;

public class SubscribeNPCText2Baloon : MonoBehaviour
{
    public float jumpPower;
    public float duration;
    private bool isTalking;

    private void Start()
    {
        ConstantScenarioModelOfNPC.onEndShowing.Subscribe(_ => isTalking = false);
        ConstantScenarioModelOfNPC.onShowText.Subscribe(_ => isTalking = true);
        TalkToNearest.talkedObject.Subscribe(
                obj => {
                    if (!isTalking)
                    {
                        return;
                    }
                    var baloon = obj.GetComponent<IBaloonHolder>()?.getBaloon();
                    baloon.transform
                    .DOLocalJump(baloon.transform.localPosition, jumpPower: jumpPower, numJumps: 1, duration: duration);
                    }
            );


    }
}

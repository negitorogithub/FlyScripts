using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class SubscribeNPCConstantText2UI : MonoBehaviour
{
    public Image Back;
    public Text textUI;

    private void Start()
    {
        SetVisiblityAll(false);
        ConstantScenarioModelOfNPC.onShowText.Subscribe(
                str =>
                {
                    SetVisiblityAll(true);
                    textUI.text = str;
                }
            );
        ConstantScenarioModelOfNPC.onEndShowing.Subscribe(
                _ => SetVisiblityAll(false)
                );
    }

    private void SetVisiblityAll(bool shouldShow)
    {
        Back.enabled = shouldShow;
        textUI.enabled = shouldShow;
    }
}


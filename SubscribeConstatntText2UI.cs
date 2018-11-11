using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class SubscribeConstatntText2UI : MonoBehaviour{

    public ConstantScenarioModel scenarioModel;
    public Image Back;
    public Text textUI;

    private void Start()
    {
        SetVisiblityAll(false);
        scenarioModel.loadConstant.onShowText.Subscribe(
                str =>
                    {
                        SetVisiblityAll(true);
                        textUI.text = str;
                    }
            );
        scenarioModel.loadConstant.onEndShowing.Subscribe(
                _ => {
                    SetVisiblityAll(false);
                    scenarioModel.loadConstant.ResetCursor();
                    }
                    );
    }

    private void SetVisiblityAll(bool shouldShow)
    {
        Back.enabled = shouldShow;
        textUI.enabled = shouldShow;
    }
}


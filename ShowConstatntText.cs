using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class ShowConstatntText : MonoBehaviour{

    public LoadConstantScenario loadScenario;
    private Text textUI;

    private void Start()
    {
        textUI = GetComponent<Text>();
        LoadConstantScenario.onShowText.SubscribeToText(textUI);
    }
}


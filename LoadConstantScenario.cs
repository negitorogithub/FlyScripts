using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class LoadConstantScenario
{
    private const string Japanese = "Japanese";

    private TextAsset textAsset;
    private ConstantScenario constantScenario;
    public Subject<string> onShowText;
    public Subject<Unit> onEndShowing;
    private int cursor = -1;//ResetCursorのタイミングがonEndShowingの為;

    public LoadConstantScenario(TextAsset textAsset_)
    {
        textAsset = textAsset_;
        string deviceLanguage = Application.systemLanguage.ToString();
        constantScenario = JsonUtility.FromJson<TranslatableConstantScenario>(textAsset.text).translated();
        onShowText = new Subject<string>();
        onEndShowing = new Subject<Unit>();
    }


    public string LoadNextText()
    {
        cursor++;
        if (constantScenario.texts.Length == 0)
        {
            Debug.Log("empty message in " + textAsset.name);
        }
        string text2set;
        text2set = constantScenario.texts[Mathf.Min(constantScenario.texts.Length - 1, cursor)];
        onShowText.OnNext(text2set);
        if (constantScenario.texts.Length - 1 < cursor)
        {
            onEndShowing.OnNext(Unit.Default);
        }
        return text2set;
    }

    public void ResetCursor()
    {
        cursor = -1;
    }
}
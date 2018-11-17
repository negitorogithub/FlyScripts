using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class LoadAlternativeScenario
{
    private const string Japanese = "Japanese";
    private TextAsset textAsset;
    private AlternativeScenario alternativeScenario;
    public Subject<string> onShowText;

    public LoadAlternativeScenario(TextAsset textAsset_)
    {
        textAsset = textAsset_;
        string deviceLanguage = Application.systemLanguage.ToString();
        alternativeScenario = JsonUtility.FromJson<TranslatableAlternativeScenario>(textAsset.text).translated();
        onShowText = new Subject<string>();
    }


    public string LoadNextText()
    {
        if (alternativeScenario.text.Length == 0)
        {
            Debug.Log("empty message in " + textAsset.name);
        }
        string text2set;
        text2set = alternativeScenario.text;
        onShowText.OnNext(text2set);
        return text2set;
    }
}
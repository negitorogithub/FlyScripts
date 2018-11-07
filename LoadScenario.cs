
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class LoadConstantScenario : MonoBehaviour
{
    public TextAsset textAsset;
    public TranslatableConstantScenario constantScenario;
    private const string Japanese = "Japanese";


    private void Start()
    {
        string deviceLanguage = Application.systemLanguage.ToString();
        constantScenario = JsonUtility.FromJson<TranslatableConstantScenario>(textAsset.text);
        if (deviceLanguage == Japanese)
        {
            text2set = JapaneseTexts[Mathf.Max(cursor, JapaneseTexts.Count - 1)];
        }
        else
        {
            text2set = EnglishTexts[Mathf.Max(cursor, EnglishTexts.Count - 1)];
        }
    }
}

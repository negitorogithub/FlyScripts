using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowConstatntText : MonoBehaviour, ShowText {

    public List<string> JapaneseTexts;
    public List<string> EnglishTexts;

    private const string Japanese = "Japanese";

    private int cursor = 0;
    private Text textUI;

    public string ShowNextText()
    {
        string deviceLanguage = Application.systemLanguage.ToString();
        string text2set;

        if (deviceLanguage == Japanese)
        {
            text2set = JapaneseTexts[Mathf.Max(cursor, JapaneseTexts.Count - 1)];
        }
        else
        {
            text2set = EnglishTexts[Mathf.Max(cursor, EnglishTexts.Count - 1)];
        }
        textUI.text = text2set;
        cursor++;
        return text2set;

    }

}


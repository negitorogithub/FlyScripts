using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowConstatntText : MonoBehaviour, ShowText {

    public LoadConstantScenario loadScenario;

    private int cursor = 0;
    private Text textUI;

    public string ShowNextText()
    {
        string text2set;
        text2set = loadScenario.constantScenario.texts[Mathf.Max(loadScenario.constantScenario.texts.Length ,cursor)];
        cursor++;
        return text2set;

    }

    void Start()
    {
        textUI = GetComponent<Text>();
    }

    public void ResetCursor()
    {
        cursor = 0;
    }
}


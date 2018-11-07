using System;
using UnityEngine;


[Serializable]

public class TranslatableConstantScenario
{
    public string[] ja;
    public string[] en;
    public bool hasFired;
    private const string Japanese = "Japanese";

    public ConstantScenario translated()
    {
        ConstantScenario constantScenario2return;
        string deviceLanguage = Application.systemLanguage.ToString();
        if (deviceLanguage == Japanese)
        {
            constantScenario2return = new ConstantScenario(ja, hasFired);
        }
        else
        {
            constantScenario2return = new ConstantScenario(en, hasFired);
        }

        return constantScenario2return;
    }
}


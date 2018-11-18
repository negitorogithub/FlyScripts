using System;
using UnityEngine;


[Serializable]

public class TranslatableAlternativeText
{
    public string ja;
    public string en;
    public bool hasFired;
    private const string Japanese = "Japanese";

    public AlternativeText Translated()
    {
        AlternativeText alternativeScenario2return;
        string deviceLanguage = Application.systemLanguage.ToString();
        if (deviceLanguage == Japanese)
        {
            alternativeScenario2return = new AlternativeText(ja, hasFired);
        }
        else
        {
            alternativeScenario2return = new AlternativeText(en, hasFired);
        }

        return alternativeScenario2return;
    }
}

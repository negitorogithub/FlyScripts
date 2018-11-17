﻿using System;
using UnityEngine;


[Serializable]

public class TranslatableAlternativeScenario
{
    public string ja;
    public string en;
    public bool hasFired;
    private const string Japanese = "Japanese";

    public AlternativeScenario translated()
    {
        AlternativeScenario alternativeScenario2return;
        string deviceLanguage = Application.systemLanguage.ToString();
        if (deviceLanguage == Japanese)
        {
            alternativeScenario2return = new AlternativeScenario(ja, hasFired);
        }
        else
        {
            alternativeScenario2return = new AlternativeScenario(en, hasFired);
        }

        return alternativeScenario2return;
    }
}

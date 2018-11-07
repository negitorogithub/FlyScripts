using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ConstantScenario: MonoBehaviour 
{
    public string[] texts;
    public bool hasFired;

    public ConstantScenario(string[] texts, bool hasFired)
    {
        this.texts = texts;
        this.hasFired = hasFired;
    }

    public ConstantScenario(TranslatableConstantScenario translatable)
    {
        this.texts = translatable.translated();
        this.hasFired = translatable.hasFired;
    }
}

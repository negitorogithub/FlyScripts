
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class LoadConstantScenario : MonoBehaviour
{
    public TextAsset textAsset;
    public ConstantScenario constantScenario;
    private const string Japanese = "Japanese";


    private void Start()
    {
        string deviceLanguage = Application.systemLanguage.ToString();
        constantScenario = JsonUtility.FromJson<TranslatableConstantScenario>(textAsset.text).translated();
    }
}

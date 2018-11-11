using UnityEngine;
using System.Collections;

public class ConstantScenarioModel : MonoBehaviour, ShowText
{

    public TextAsset textAsset;
    public LoadConstantScenario loadConstant { get; private set; }

    public void ShowNextText()
    {
        loadConstant.LoadNextText();
    }

    void Awake()
    {
        loadConstant = new LoadConstantScenario(textAsset);
    }

}

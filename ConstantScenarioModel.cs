using UnityEngine;
using System.Collections;

public class ConstantScenarioModel : MonoBehaviour, ShowText
{

    public TextAsset textAsset;
    private LoadConstantScenario loadConstant;

    public void ShowNextText()
    {
        loadConstant.LoadNextText();
    }

    void Start()
    {
        loadConstant = new LoadConstantScenario(textAsset);
    }

}

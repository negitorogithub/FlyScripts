using UniRx;
using UnityEngine;

public class LoadConstantScenario
{
    private const string Japanese = "Japanese";

    private TextAsset textAsset;
    private ConstantScenario constantScenario;
    public Subject<string> onShowText;
    public Subject<Unit> onEndShowing;
    private int cursor = -1;//ResetCursorのタイミングがonEndShowingの為;

    public LoadConstantScenario(string json)
    {
        string deviceLanguage = Application.systemLanguage.ToString();
        constantScenario = JsonUtility.FromJson<TranslatableConstantScenario>(json).translated();
        onShowText = new Subject<string>();
        onEndShowing = new Subject<Unit>();
    }


    public string LoadNextText()
    {
        cursor++;
        if (constantScenario.texts.Length == 0)
        {
            Debug.Log("empty message");
        }
        string text2set;
        text2set = constantScenario.texts[Mathf.Min(constantScenario.texts.Length - 1, cursor)];
        onShowText.OnNext(text2set);
        if (constantScenario.texts.Length - 1 < cursor)
        {
            onEndShowing.OnNext(Unit.Default);
            ResetCursor();
        }
        return text2set;
    }

    public void ResetCursor()
    {
        cursor = -1;
    }
}
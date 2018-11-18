using UniRx;
using UnityEngine;

public class ConstantScenarioModelOfNPC : MonoBehaviour, ILoadText
{
    public TextAsset textAsset;
    public LoadConstantScenario loadConstant { get; private set; }
    public static Subject<string> onShowText;
    public static Subject<Unit> onEndShowing;

    public string LoadNextText()
    {
        return loadConstant.LoadNextText();
    }

    void Awake()
    {
        loadConstant = new LoadConstantScenario(textAsset);
        onShowText = new Subject<string>();
        onEndShowing = new Subject<Unit>();
    }

    void Start()
    {
        loadConstant.onShowText.Subscribe(
            str => onShowText.OnNext(str)
            );
        loadConstant.onEndShowing.Subscribe(
            _ => onEndShowing.OnNext(Unit.Default)
            );
    }
}

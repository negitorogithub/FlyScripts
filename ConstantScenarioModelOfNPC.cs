using UniRx;
using UnityEngine;

public class ConstantScenarioModelOfNPC : MonoBehaviour, ILoadText
{
    public TextAsset textAsset;
    public LoadConstantScenario loadConstant { get; private set; }

    public static bool isTalking { get; private set; }
    public static Subject<string> onShowText { get; private set; }
public static Subject<Unit> onEndShowing { get; private set; }

public void LoadNextText() => loadConstant.LoadNextText();

    void Awake()
    {
        loadConstant = new LoadConstantScenario(textAsset.text);
        onShowText = new Subject<string>();
        onEndShowing = new Subject<Unit>();
        isTalking = false;
    }

    void Start()
    {
        loadConstant.onShowText.Subscribe(
            str => onShowText.OnNext(str)
            );
        loadConstant.onEndShowing.Subscribe(
            _ => onEndShowing.OnNext(Unit.Default)
            );
        onEndShowing.Subscribe(_ => isTalking = false);
        onShowText.Subscribe(_ => isTalking = true);
    }
}

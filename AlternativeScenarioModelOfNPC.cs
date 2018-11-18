using UnityEngine;
using System.Collections;
using UniRx;
using System.Collections.Generic;

public class AlternativeScenarioModelOfNPC : MonoBehaviour
{
    public TextAsset constantScenario;
    public TextAsset alternativeScenario;
    public LoadConstantScenario loadConstant { get; private set; }
    public LoadAlternativeScenario loadAlternarives { get; private set; }

    public static Subject<string> onShowText;
    public static Subject<Unit> onEndShowing;
    public static Subject<List<AlternativeText>> onShowAlternatives;


    public string LoadNextText()
    {
        return loadConstant.LoadNextText();
    }

    void Awake()
    {
        loadConstant = new LoadConstantScenario(constantScenario);
        loadAlternarives = new LoadAlternativeScenario(alternativeScenario);
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
        loadAlternarives.onShowText.Subscribe(
            alternatives => onShowAlternatives.OnNext(alternatives)
            );
    }
}

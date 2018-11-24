using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class AlternativeScenarioModelOfNPC : MonoBehaviour, ILoadText
{
    public TextAsset constantScenario;
    public TextAsset alternativeScenario;
    public LoadAlternativeScenario loadAlternarives { get; private set; }
    public static Subject<List<AlternativeText>> onShowAlternatives;

    public void LoadNextText()
    {
        loadAlternarives.LoadAlternatives();
    }

    void Awake()
    {
        onShowAlternatives = new Subject<List<AlternativeText>>();
        loadAlternarives = new LoadAlternativeScenario(alternativeScenario);
    }

    void Start()
    {
        loadAlternarives.onShowText.Subscribe(
            alternatives => onShowAlternatives.OnNext(alternatives)
            );
    }


}

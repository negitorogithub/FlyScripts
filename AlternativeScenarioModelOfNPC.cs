using UnityEngine;
using System.Collections;
using UniRx;
using System.Collections.Generic;

public class AlternativeScenarioModelOfNPC : MonoBehaviour
{
    public TextAsset constantScenario;
    public TextAsset alternativeScenario;
    public LoadAlternativeScenario loadAlternarives { get; private set; }
    public static Subject<List<AlternativeText>> onShowAlternatives;

    public List<AlternativeText> LoadNextText()
    {
        return loadAlternarives.LoadAlternatives();
    }

    void Awake()
    {
        loadAlternarives = new LoadAlternativeScenario(alternativeScenario);
    }

    void Start()
    {
        loadAlternarives.onShowText.Subscribe(
            alternatives => onShowAlternatives.OnNext(alternatives)
            );
    }
}

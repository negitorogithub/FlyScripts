using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class LoadAlternativeScenario
{
    private const string Japanese = "Japanese";
    private TextAsset textAsset;
    private AlternativeScenario alternativeScenario;
    public Subject<List<AlternativeText>> onShowText;

    public LoadAlternativeScenario(TextAsset textAsset_)
    {
        textAsset = textAsset_;
        string deviceLanguage = Application.systemLanguage.ToString();
        alternativeScenario = JsonUtility.FromJson<TranslatableAlternativeScenario>(textAsset.text).Translated();
        onShowText = new Subject<List<AlternativeText>>();
    }


    public List<AlternativeText> LoadAlternatives()
    {
        if (alternativeScenario.alternatives.Capacity == 0)
        {
            Debug.Log("empty message in " + textAsset.name);
        }
        List<AlternativeText> texts2set;
        texts2set = alternativeScenario.alternatives;
        onShowText.OnNext(texts2set);
        return texts2set;
    }
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using System.Collections.Generic;

public class SubscribeNPCAlternativeText2UI : MonoBehaviour
{
    public Transform canvas;
    public List<AlternativeComponent> alternativeComponents;
    private int size;

    private void Start()
    {
        Reset();
        AlternativeScenarioModelOfNPC.onShowAlternatives.Subscribe(alternatives =>
        {
            alternatives.ForEach(alternative => AddAlternativeUI(alternative));
        });
        ConstantScenarioModelOfNPC.onEndShowing.Subscribe(_ => Reset());
    }

    private void AddAlternativeUI(AlternativeText alternative)
    {
        foreach (var item in alternativeComponents)
        {
            if (item.text.text == alternative.text)
            {
                return;
            }
        }
        size++;
        alternativeComponents[size -1].text.text = alternative.text;
        SetVisiblityOfIndex(true, size - 1);
    }

    private void Reset()
    {
        size = 0;
        alternativeComponents.ForEach(obj => {
            obj.Back.enabled = false;
            obj.text.enabled = false;
            obj.text.text = "";
            }
        );

    }

    private void SetVisiblityOfIndex(bool shouldShow, int index)
    {
        alternativeComponents[index].Back.enabled = shouldShow;
        alternativeComponents[index].text.enabled = shouldShow;
    }

}

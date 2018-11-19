using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;

public class SubscribeNPCAlternativeText2UI : MonoBehaviour
{
    public Transform canvas;
    public Image Back;
    public Text textUI;
    private int size;

    private void Start()
    {
        SetVisiblityAll(false);
        AlternativeScenarioModelOfNPC.onShowAlternatives.Subscribe(alternatives =>
        {
            alternatives.ForEach(alternative => AddAlternative(alternative));
        });
    }

    private void AddAlternative(AlternativeText alternative)
    {
        size++;
        Image image;
        image = Back;
        image.rectTransform.anchorMax.Set(1, size * 0.1f + 0.3f);
        image.rectTransform.anchorMin.Set(0.7f, size * 0.1f + 0.2f);
        Instantiate(image, canvas);
        // textUIから生成予定
        Text text = textUI;
        text.text = alternative.text;
        Instantiate(text, image.transform);
    }


    private void SetVisiblityAll(bool shouldShow)
    {
        Back.enabled = shouldShow;
        textUI.enabled = shouldShow;
    }
}

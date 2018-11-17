using UnityEngine;

public class AlternativeScenario : MonoBehaviour
{
    public string text;
    public bool hasFired;

    public AlternativeScenario(string text, bool hasFired)
    {
        this.text = text;
        this.hasFired = hasFired;
    }
}

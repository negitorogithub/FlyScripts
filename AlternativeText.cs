[System.Serializable]
public class AlternativeText
{
    public string text;
    public bool hasFired;

    public AlternativeText(string text, bool hasFired)
    {
        this.text = text;
        this.hasFired = hasFired;
    }
}

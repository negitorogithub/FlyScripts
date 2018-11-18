using System.Collections.Generic;
[System.Serializable]
public class AlternativeScenario
{
    public List<AlternativeText> alternatives;

    public AlternativeScenario(List<AlternativeText> alternatives)
    {
        this.alternatives = alternatives;
    }
}

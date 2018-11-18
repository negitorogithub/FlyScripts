using System.Linq;

public class TranslatableAlternativeScenario
{

    public TranslatableAlternativeText[] alternatives;

    public AlternativeScenario Translated() => new AlternativeScenario(alternatives.Select(text => text.Translated()).ToList());

}

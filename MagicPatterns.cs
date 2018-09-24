using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagicPatterns
{
    public List<LineByNumber> linesByNumber;

    public MagicPatterns(){
        linesByNumber = new List<LineByNumber>();
    }
    public MagicPatterns(List<LineByNumber> linesByNumber_)
    {
        linesByNumber = linesByNumber_;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is MagicPatterns))
        {
            return false;
        }

        MagicPatterns magicPatterns2Check = obj as MagicPatterns;

        if (linesByNumber.Count != magicPatterns2Check.linesByNumber.Count )
        {
            return false;
        }

        foreach (LineByNumber line in magicPatterns2Check.linesByNumber)
        {
            if (!linesByNumber.Contains(line))
            {
                return false;
            } 
        }

        return true;
    }

    //良く分からん
    public override int GetHashCode()
    {
        return -1388673660 + EqualityComparer<List<LineByNumber>>.Default.GetHashCode(linesByNumber);
    }
}

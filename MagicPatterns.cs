using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class MagicPatterns
{
    public List<LineByNumber> linesByNumber;
    public string name;
    public string particleName;

    public MagicPatterns(string name_ = "", string particleName_ = "")
    {
        linesByNumber = new List<LineByNumber>();
        name = name_;
        particleName = particleName_;
    }

    public MagicPatterns SetList(List<LineByNumber> linesByNumber_)
    {
        linesByNumber = linesByNumber_;
        return this;
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

    public void ResetList()
    {
        linesByNumber = new List<LineByNumber>();
    }

    //良く分からん
    public override int GetHashCode()
    {
        return -1388673660 + EqualityComparer<List<LineByNumber>>.Default.GetHashCode(linesByNumber);
    }

    public static MagicPatterns FromIntArray(int[] array, string name_ = "", string particleName_ = "")
    {
        var magicPatterns = new MagicPatterns(name_: name_, particleName_: particleName_);
        var oddIndexValues = array.Where((value, index) => index % 2 == 1);
        var evenIndexValues = array.Where((value, index) => index % 2 == 0);
        if (oddIndexValues.Count() != evenIndexValues.Count())
        {
            throw new Exception("the array's size wasn't odd.");
        }
        for (int i = 0; i < oddIndexValues.Count(); i++)
        {
            magicPatterns.linesByNumber.Add(
                new LineByNumber(
                    oddIndexValues.ElementAt(i),
                    evenIndexValues.ElementAt(i)
                    )
            );
        }
        return magicPatterns;
    }

    
}

﻿using System;

public class LineByNumber : IEquatable<LineByNumber>
{
    public int x1 { get; private set; }
    public int x2 { get; private set; }
    public LineByNumber(int x1_, int x2_)
    {
        x1 = x1_;
        x2 = x2_;
    }

    public bool Equals(LineByNumber other)
    {
        if ((x1 == other.x1 | x1 == other.x2)&(x2 == other.x1 | x2 == other.x2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return  x1.GetHashCode() ^ x2.GetHashCode();
    }
}

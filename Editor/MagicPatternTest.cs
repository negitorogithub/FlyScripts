using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MagicPatternTest {

	[Test]
	public void NotEqualsDupulicated() {
        MagicPatterns m1 = new MagicPatterns();
        MagicPatterns m2 = new MagicPatterns();

        m1.linesByNumber.Add(new LineByNumber(2, 3));
        m1.linesByNumber.Add(new LineByNumber(2, 3));
        m2.linesByNumber.Add(new LineByNumber(3, 2));
        Assert.False(m1.Equals(m2));
    }
    
    [Test]
    public void NotEqualsEmpty()
    {
        MagicPatterns m1 = new MagicPatterns();
        m1.linesByNumber.Add(new LineByNumber(2, 3));
        MagicPatterns m2 = new MagicPatterns();
        Assert.False(m1.Equals(m2));
    }

    [Test]
    public void EqualsNormal()
    {
        MagicPatterns m1 = new MagicPatterns();
        m1.linesByNumber.Add(new LineByNumber(2, 3));
        MagicPatterns m2 = new MagicPatterns();
        m2.linesByNumber.Add(new LineByNumber(3, 2));
        Assert.That(m1.Equals(m2));
    }

    [Test]
    public void FromIntArray()
    {
        MagicPatterns m1 = MagicPatterns.FromIntArray(new int[] {2, 3, 5, 9 });
        MagicPatterns m2 = MagicPatterns.FromIntArray(new int[] {3, 2, 9, 5 });
        Assert.That(m1.Equals(m2));
    }

}

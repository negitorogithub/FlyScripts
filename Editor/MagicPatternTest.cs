using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MagicPatternTest {

	[Test]
	public void MagicPatternEqualsTestDupulicated() {
        MagicPatterns m1 = new MagicPatterns();
        MagicPatterns m2 = new MagicPatterns();

        m1.linesByNumber.Add(new LineByNumber(2, 3));
        m1.linesByNumber.Add(new LineByNumber(2, 3));
        m2.linesByNumber.Add(new LineByNumber(3, 2));
        Assert.False(m1.Equals(m2));
    }
    
    [Test]
    public void MagicPatternEqualsTestVoid()
    {
        MagicPatterns m1 = new MagicPatterns();
        m1.linesByNumber.Add(new LineByNumber(2, 3));
        MagicPatterns m2 = new MagicPatterns();
        Assert.False(m1.Equals(m2));
    }

    [Test]
    public void MagicPatternEqualsTestTrue()
    {
        MagicPatterns m1 = new MagicPatterns();
        m1.linesByNumber.Add(new LineByNumber(2, 3));
        MagicPatterns m2 = new MagicPatterns();
        m2.linesByNumber.Add(new LineByNumber(3, 2));
        Assert.That(m1.Equals(m2));
    }
}

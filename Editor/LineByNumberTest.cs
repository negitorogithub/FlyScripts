﻿using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class LineTest {

	[Test]
	public void LineConstructerTest() {
        Assert.That(2, Is.EqualTo(new LineByNumber(2, 3).x1));
        Assert.That(3, Is.EqualTo(new LineByNumber(2, 3).x2));
    }

    [Test]
    public void LineEqualsTest()
    {
        Assert.That(new LineByNumber(2, 3).Equals(new LineByNumber(3, 2)));
        Assert.That(new LineByNumber(3, 2).Equals(new LineByNumber(2, 3)));
    }
}

using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class LineByVector3Test {

    [Test]
    public void LineConstructerTest()
    {
        Assert.That(Vector3.left, Is.EqualTo(new LineByVector3(Vector3.left, Vector3.up).V1));
        Assert.That(Vector3.up, Is.EqualTo(new LineByVector3(Vector3.left, Vector3.up).V2));

    }
}

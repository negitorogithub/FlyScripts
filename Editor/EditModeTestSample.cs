using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EditModeTestSample {

    [Test]
    public void AnyTest()
    {
        int a = 5, b = 4;
        int ans = a * b;

        Assert.That(ans, Is.EqualTo(20));
    }
}

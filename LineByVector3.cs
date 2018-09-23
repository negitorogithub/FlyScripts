using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineByVector3 {
    public Vector3 V1 { get; private set; }
    public Vector3 V2 { get; private set; }
    public LineByVector3(Vector3 x1_, Vector3 x2_)
    {
        V1 = x1_;
        V2 = x2_;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curveShifter :  mono {

    public AnimationCurve curve;
    public mono input;
    // Use this for initialization
    public override float[] getSignal(int length)
    {
        fill = new float[length];
        float[] datt = ((mono)input).getSignal(length);
        for (int i = 0; i < datt.Length; i++)
        {
            fill[i] = curve.Evaluate(datt[i]);
        }
        return fill;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curveShifter : MonoBehaviour, mono {

    public AnimationCurve curve;
    public Component input;
    // Use this for initialization
    public float[] getSignal(int length)
    {
        float[] fill = new float[length];
        float[] datt = ((mono)input).getSignal(length);
        for (int i = 0; i < datt.Length; i++)
        {
            fill[i] = curve.Evaluate(datt[i]);
        }
        return fill;
    }
}

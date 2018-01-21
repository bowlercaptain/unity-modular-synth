using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeShifter : mono {

    public mono input;
    public float sourceMin = -1f;
    public float sourceMax = 1f;
    public float outMin = 0f;
    public float outMax = 1f;

    public override float[] getSignal(List<bool[]> doneBoxes, int length)
    {
        fill = new float[length];
        float[] datt = input.gibSignal(doneBoxes, length);
        for (int i = 0; i < datt.Length; i++)
        {
            fill[i] = (datt[i] - sourceMin) / (sourceMax - sourceMin) * (outMax - outMin) + outMin;
        }
        return fill;
    }

}

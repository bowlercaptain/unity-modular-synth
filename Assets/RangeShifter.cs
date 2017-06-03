using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeShifter : MonoBehaviour, mono {

    public Component input;
    public float sourceMin = -1f;
    public float sourceMax = 1f;
    public float outMin = 0f;
    public float outMax = 1f;

    public float[] getSignal(int length)
    {
        float[] fill = new float[length];
        float[] datt = ((mono)input).getSignal(length);
        for (int i = 0; i < datt.Length; i++)
        {
            fill[i] = (datt[i] - sourceMin) / (sourceMax - sourceMin) * (outMax - outMin) + outMin;
        }
        return fill;
    }

}

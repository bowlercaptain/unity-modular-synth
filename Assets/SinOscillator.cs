using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinOscillator : MonoBehaviour, mono
{

    float currentPos;

    public Component frequency;

    public float[] getSignal(int length)
    {
        float[] fill = new float[length];

        float[] freqs = ((mono)frequency).getSignal(length);
        for (int i=0; i<length; i++)
        {
            currentPos += freqs[i] / info.sampleRate * 2 * Mathf.PI;
            fill[i] = Mathf.Sin(currentPos);
        }
        return fill;
    }
}

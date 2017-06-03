using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriOscillator : MonoBehaviour, mono
{

    float currentPos;

    public Component frequency;

    public float[] getSignal(int length)
    {
        
        float[] fill = new float[length];

        float[] freqs = ((mono)frequency).getSignal(length);
        for (int i = 0; i < length; i++)
        {
            currentPos += freqs[i] / info.sampleRate;
            fill[i] = Mathf.Abs((currentPos*2 + 1f) % 2f - 1f);
        }
        while (currentPos > 2f) { currentPos -= 2f; }
        while (currentPos < -2f) { currentPos += 2f; }
        return fill;
    }
}

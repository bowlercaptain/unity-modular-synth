using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Oscillator : MonoBehaviour, mono {

    public abstract float waveFunction(float position);

    private void Awake()
    {
        if (volume == null)
        {
            volume = gameObject.AddComponent<constantOut>();
            ((constantOut)volume).valll = 1;
        }
    }

    float currentPos;

    public Component frequency;

    public Component volume;

    public float[] getSignal(int length)
    {

        float[] fill = new float[length];

        float[] freqs = ((mono)frequency).getSignal(length);
        float[] vols = ((mono)volume).getSignal(length);
        for (int i = 0; i < length; i++)
        {
            currentPos += freqs[i] / info.sampleRate;
            fill[i] = waveFunction(currentPos)*vols[i];
        }
        while (currentPos > 1f) { currentPos -= 1f; }
        while (currentPos < -1f) { currentPos += 1f; }
        return fill;
    }
}

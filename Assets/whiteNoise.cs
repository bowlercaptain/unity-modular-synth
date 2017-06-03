using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteNoise : MonoBehaviour, mono {

    private System.Random mr = new System.Random();

public float[] getSignal(int length)
    {
        float[] fill = new float[length];

        for (int i = 0; i < length; i++)
        {

            fill[i] = (float)mr.NextDouble()*2f-1f;
        }
        return fill;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteNoise : mono {

    private System.Random mr = new System.Random();

public override float[] getSignal(int length)
    {
        fill = new float[length];

        for (int i = 0; i < length; i++)
        {

            fill[i] = (float)mr.NextDouble()*2f-1f;
        }
        return fill;
    }
}

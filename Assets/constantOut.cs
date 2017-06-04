using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constantOut : MonoBehaviour, mono {

    public float value;
    public float[] getSignal(int length)
    {
        float[] fill = new float[length];
        
        for(int i = 0; i < length; i++)
        {
            fill[i] = value;
        }
        return fill;
    }
}

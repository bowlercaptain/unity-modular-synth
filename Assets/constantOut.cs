using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constantOut :  mono {

    public float value;
    public override float[] getSignal(List<bool[]> doneBoxes, int length)
    {
        fill = new float[length];
        
        for(int i = 0; i < length; i++)
        {
            fill[i] = value;
        }
        return fill;
    }
}

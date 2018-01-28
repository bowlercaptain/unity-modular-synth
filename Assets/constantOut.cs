using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constantOut :  mono {

    public float value;
    protected override void getSignal(List<bool[]> doneBoxes) {
        fill = new float[length];
        
        for(int i = 0; i < length; i++)
        {
            fill[i] = value;
        }
    }
}

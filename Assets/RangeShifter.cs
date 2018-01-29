using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeShifter : mono {

    public mono input{
get{return monoInputs[0];}
set{monoInputs[0]=value;}
}
    public float sourceMin = -1f;
    public float sourceMax = 1f;
    public float outMin = 0f;
    public float outMax = 1f;

    protected override void getSignal(List<bool[]> doneBoxes) {
        fill = new float[length];
        float[] datt = input.gibSignal(doneBoxes);
        for (int i = 0; i < datt.Length; i++)
        {
            fill[i] = (datt[i] - sourceMin) / (sourceMax - sourceMin) * (outMax - outMin) + outMin;
        }
    }

public override int getNumMonos(){ return(1); }
}
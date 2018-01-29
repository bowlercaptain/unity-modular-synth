using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curveShifter :  mono {

    public AnimationCurve curve;
    public mono input{
get{return monoInputs[0];}
set{monoInputs[0]=value;}
}
    // Use this for initialization
    protected override void getSignal(List<bool[]> doneBoxes) {
        fill = new float[length];
        float[] datt = ((mono)input).gibSignal(doneBoxes);
        for (int i = 0; i < datt.Length; i++)
        {
            fill[i] = curve.Evaluate(datt[i]);
        }
    }
public override int getNumMonos(){ return(1); }
}
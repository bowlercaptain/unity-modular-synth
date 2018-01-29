using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteNoise : mono {


	public mono volume{
get{return monoInputs[0];}
set{monoInputs[0]=value;}
}

	private System.Random mr = new System.Random();

protected override void getSignal(List<bool[]> doneBoxes) {
        fill = new float[length];
		float[] vols = volume.gibSignal(doneBoxes);

        for (int i = 0; i < length; i++)
        {

            fill[i] = vols[i]*(float)mr.NextDouble()*2f-1f;
        }
    }
public override int getNumMonos(){ return(1); }
}
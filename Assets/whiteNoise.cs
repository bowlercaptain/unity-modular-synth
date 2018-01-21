using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteNoise : mono {


	public mono volume;

	private System.Random mr = new System.Random();

public override float[] getSignal(List<bool[]> doneBoxes, int length)
    {
        fill = new float[length];
		float[] vols = volume.gibSignal(doneBoxes, length);

        for (int i = 0; i < length; i++)
        {

            fill[i] = vols[i]*(float)mr.NextDouble()*2f-1f;
        }
        return fill;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkNoise : mono {

    public mono width{
get{return monoInputs[0];}
set{monoInputs[0]=value;}
}

	public mono volume{
get{return monoInputs[1];}
set{monoInputs[1]=value;}
}

	private void Awake()
	{
		if(volume == null) {
			var vol = gameObject.AddComponent<constantOut>();
			vol.value = 1;
			volume = vol;
		}
	}

	private float lastVal=0f;

    private System.Random mr = new System.Random();

    protected override void getSignal(List<bool[]> doneBoxes) {
        fill = new float[length];

        float[] widths = width.gibSignal(doneBoxes);
		float[] vols = volume.gibSignal(doneBoxes);

        for (int i = 0; i < length; i++)
        {
            lastVal = Mathf.Clamp(lastVal+((float)mr.NextDouble()*2f-1f)*widths[i],-1f, 1f);
            fill[i] = lastVal * vols[i];
        }
    }
}
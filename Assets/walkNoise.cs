using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkNoise : mono {

    public mono width;

	public mono volume;

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

    public override float[] getSignal(int length)
    {
        fill = new float[length];

        float[] widths = ((mono)width).getSignal(length);
		float[] vols = ((mono)volume).getSignal(length);

        for (int i = 0; i < length; i++)
        {
            lastVal = Mathf.Clamp(lastVal+((float)mr.NextDouble()*2f-1f)*widths[i],-1f, 1f);
            fill[i] = lastVal * vols[i];
        }
        return fill;
    }
}

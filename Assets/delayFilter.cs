using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayFilter : mono
{

	public mono input{
get{return monoInputs[0];}
set{monoInputs[0]=value;}
}
	public mono wetDry{
get{return monoInputs[1];}
set{monoInputs[1]=value;}
}
	public float delay;

	private float[] tape = new float[1024];
	private int j=0;

	private void Start()
	{
		tape = new float[Mathf.RoundToInt(info.sampleRate * delay)];
	}

	protected override void getSignal(List<bool[]> doneBoxes) {
		fill = new float[length];
		var datt = input.gibSignal(doneBoxes);
		var wetDryDat = wetDry.gibSignal(doneBoxes);
		for (int i = 0; i < length; i++)
		{
			fill[i] = fuckSample(datt[i], wetDryDat[i]);
		}
	}

	public float fuckSample(float sample, float wetDry)
	{
		sample += tape[j] * wetDry;
		if(float.IsNaN(sample)) { sample = 0; }
		tape[j] = sample;
		j++;
		if (j >= tape.Length) { j = 0; }
		return sample;
	}

}
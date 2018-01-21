using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayFilter : mono
{

	public mono input;
	public mono wetDry;
	public float delay;

	private float[] tape = new float[1024];
	private int j=0;

	private void Start()
	{
		tape = new float[Mathf.RoundToInt(info.sampleRate * delay)];
	}

	public override float[] getSignal(List<bool[]> doneBoxes, int length)
	{
		fill = new float[length];
		var datt = input.gibSignal(doneBoxes, length);
		var wetDryDat = wetDry.gibSignal(doneBoxes, length);
		for (int i = 0; i < length; i++)
		{
			fill[i] = fuckSample(datt[i], wetDryDat[i]);
		}
		return fill;
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

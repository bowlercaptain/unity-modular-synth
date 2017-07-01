using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayFilter : mono
{

	public mono input;
	public float wetDry;
	public float delay;

	private float[] tape = new float[1024];
	private int j=0;

	private void Start()
	{
		tape = new float[Mathf.RoundToInt(info.sampleRate * delay)];
	}

	public override float[] getSignal(int length)
	{
		fill = new float[length];
		var datt = input.getSignal(length);
		for (int i = 0; i < length; i++)
		{//if length ever changes this breaks! But it doesn't, so...
			fill[i] = fuckSample(datt[i]);
		}
		return fill;
	}

	public float fuckSample(float sample)
	{
		sample += tape[j] * wetDry;
		if(float.IsNaN(sample)) { sample = 0; }
		tape[j] = sample;
		j++;
		if (j >= tape.Length) { j = 0; }
		return sample;
	}
}

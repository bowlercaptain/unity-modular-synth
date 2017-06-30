using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmonicOscillator : Oscillator
{

	public float[] volumes;

	public override float waveFunction(float position)
	{
		//return 1;
		float val = 0f;
		for (int i = 0; i < volumes.Length; i++) {
			val += Mathf.Sin(2 * Mathf.PI * (i+1) * position) * volumes[i]/((float)(i+1));
		}
		return val;
	}
}

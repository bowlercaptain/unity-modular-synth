using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackandSustain :  mono {

	public mono input;
	

	public float attackTime;
	public float sustainTime;

	private float current;
	public override float[] getSignal(int length)
	{
		fill = new float[length];//todo: these lines making new arrays may be unnecessary, since length doesn't change.
		float[] datt = input.getSignal(length);
		for(int i = 0; i < datt.Length; i++) {
			if (datt[i] > current)
			{
				float attackStep = datt[i] / attackTime / info.sampleRate;
				current = Mathf.Min(current + attackStep, datt[i]);
			}
			if (datt[i] < current)
			{
				float sustainStep = 1 / sustainTime / info.sampleRate;//SHIT
				current = Mathf.Max(current - sustainStep, datt[i]);
			}
			fill[i] = current;
		}

			return fill;
	}
}

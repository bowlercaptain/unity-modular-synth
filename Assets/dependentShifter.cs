using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dependentShifter : mono {

	public mono input;
	public mono sourceMin;
	public mono sourceMax;
	public mono outMin;
	public mono outMax;

	public override float[] getSignal(List<bool[]> doneBoxes, int length) {
		fill = new float[length];
		float[] datt = input.gibSignal(doneBoxes, length);
		float[] inmins = sourceMin.gibSignal(doneBoxes, length);
		float[] inmaxs = sourceMax.gibSignal(doneBoxes, length);
		float[] outmins = outMin.gibSignal(doneBoxes, length);
		float[] outmaxs = outMax.gibSignal(doneBoxes, length);
		for (int i = 0; i < datt.Length; i++) {
			fill[i] = (datt[i] - inmins[i]) / (inmaxs[i] - inmins[i]) * (outmaxs[i] - outmins[i]) + outmins[i];
		}
		return fill;
	}
}

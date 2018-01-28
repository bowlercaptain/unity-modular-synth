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

	protected override void getSignal(List<bool[]> doneBoxes) {
		fill = new float[length];
		float[] datt = input.gibSignal(doneBoxes);
		float[] inmins = sourceMin.gibSignal(doneBoxes);
		float[] inmaxs = sourceMax.gibSignal(doneBoxes);
		float[] outmins = outMin.gibSignal(doneBoxes);
		float[] outmaxs = outMax.gibSignal(doneBoxes);
		for (int i = 0; i < datt.Length; i++) {
			fill[i] = (datt[i] - inmins[i]) / (inmaxs[i] - inmins[i]) * (outmaxs[i] - outmins[i]) + outmins[i];
		}
	}
}

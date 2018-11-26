using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bitcrushfilter : mono//yes we can and should make a base class that delayFilter and bitcrushfilter use. The parallel structure here was intentional. Yes, you're very smart, now shut up.
{
	public float minReach;
	public mono input{
get{return monoInputs[0];}
set{monoInputs[0]=value;}
}

	protected override void getSignal(List<bool[]> doneBoxes) {
		fill = new float[length];
		var datt = input.gibSignal(doneBoxes);
		for (int i = 0; i < length; i++) {//if length ever changes this breaks! But it doesn't, so...
			fill[i] = fuckSample(datt[i]);
		}
	}

	private float fuckSample(float sample) {

		return Mathf.Round(sample / minReach) * minReach;//todo: create a base offset so you can do .5,1.5,2.5 instead of always centering at 0.
	}


}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dependentShifter : mono {

	public mono input{
get{return monoInputs[0];}
set{monoInputs[0]=value;}
}
	public mono sourceMin{
get{return monoInputs[1];}
set{monoInputs[1]=value;}
}
	public mono sourceMax{
get{return monoInputs[2];}
set{monoInputs[2]=value;}
}
	public mono outMin{
get{return monoInputs[3];}
set{monoInputs[3]=value;}
}
	public mono outMax{
get{return monoInputs[4];}
set{monoInputs[4]=value;}
}

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
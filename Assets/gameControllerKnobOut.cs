using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControllerKnobOut : mono {

	public string axisName;
	float knobValue = .5f;

	public override float[] getSignal(List<bool[]> doneBoxes, int length) {
		for (int i = 0; i < length; i++)
		{
			fill[i] = knobValue;
		}
		return fill;
	}


	
	// Update is called once per frame
	void Update () {
		knobValue = Input.GetAxis(axisName);
	}
}

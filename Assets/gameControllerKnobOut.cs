using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControllerKnobOut : Knob {

	public string axisName;
	float knobValue = .5f;

	public override float Value() {
		return knobValue;
	}

	// Update is called once per frame
	void Update () {
		knobValue = Input.GetAxis(axisName);
	}
}

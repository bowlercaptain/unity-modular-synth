using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monoBridge : mono
{
	public mono source;
	public override float[] getSignal(List<bool[]> doneBoxes, int length)
	{
		fill = source.gibSignal( doneBoxes, length);
		return fill;
	}
}

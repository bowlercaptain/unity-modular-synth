using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monoBridge : mono
{
	public mono source;
	public override float[] getSignal(int length)
	{
		fill = ((mono)source).getSignal(length);
		return fill;
	}
}

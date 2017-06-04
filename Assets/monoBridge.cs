using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monoBridge : MonoBehaviour, mono
{
	public Component source;
	public float[] getSignal(int length)
	{
		return ((mono)source).getSignal(length);
	}
}

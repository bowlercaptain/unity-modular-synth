using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResamplerSpeedShifter : mono
{

	public mono input;
	public mono rates;

	private float[] tape = new float[1];
	private float tapePosition;
	private float lastSample = 0f;

	public override float[] getSignal(List<bool[]> doneBoxes, int length)
	{
		var ratte = rates.gibSignal(doneBoxes, length);
		for (int i = 0; i < length; i++)
		{
			tapePosition += ratte[i];
			if (tapePosition >= tape.Length)//may need to convert this to 'while' if there are edge cases
			{
				lastSample = tape[tape.Length - 1];
				tapePosition -= tape.Length;
				tape = input.gibSignal(doneBoxes, Mathf.CeilToInt(length * ratte[i]));//or multiply by two here? kind of janks the consistent performance thing.
				//Debug.Log("New tape! Length " + tape.Length+" "+ratte[i]);
				//Debug.Log("new pos: " + tapePosition);
			}

			int point = Mathf.FloorToInt(tapePosition - 1);
			float prevSample;
			if (point < 0) 
			{ prevSample = lastSample; } else
			 { prevSample = tape[point]; }
			
				float nextSample = tape[point + 1];
			
			
			fill[i] = Mathf.Lerp(prevSample, nextSample, tapePosition % 1);
		}
		return fill;
	}
}

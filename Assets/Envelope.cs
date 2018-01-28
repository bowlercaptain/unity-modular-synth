using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envelope : mono
{

	public NoteControl controller;

	public float attackTime;
	public float sustainTime;
	public float decayTime;


	float sample = 0;//logically this is an int but it's easier because this is always used as an int

	void OnEnable()
	{
		controller.noteOn += NoteOn;
	}

	void OnDisable()
	{
		controller.noteOn -= NoteOn;
	}

	public void NoteOn(int note, float velocity)
	{
		Debug.Log("note on");
		sample = 0;
	}

	protected override void getSignal(List<bool[]> doneBoxes) {
		fill = new float[length];
		int i = 0;
		float attackSamples = (attackTime * info.sampleRate);
		while (i < length && sample < attackSamples)
		{
			fill[i++]= sample++ / attackSamples ;
		}
		//Debug.Log("attack done"+i);
		float sustainSamples = (sustainTime * info.sampleRate);
		while (i < length && sample++ < attackSamples + sustainSamples)
		{
			fill[i++] = 1f;
			sample++;
		}
		//Debug.Log("even"+i);
		float decaySamples = decayTime * info.sampleRate;
		while(i < length && sample < attackSamples + sustainSamples + decaySamples		)
		{
			fill[i++] = 1-((sample-attackSamples-sustainSamples)/decaySamples);
			//Debug.Log(1 - ((sample - attackSamples - sustainSamples) / decaySamples));
			sample++;
		}
		//Debug.Log("The victory" + i);
		while (i < length) {
			fill[i++]=0;
		}
	}
}

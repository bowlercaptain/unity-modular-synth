﻿using UnityEngine;
using MidiJack;
using System.Collections.Generic;

public class OscillatorRack : MonoBehaviour
{

	public MidiChannel channel;

	private Stack<GameObject> unusedOscillators = new Stack<GameObject>();
	private Dictionary<int, GameObject> playingOscillators = new Dictionary<int, GameObject>();
	public GameObject oscPrefab;//has an InBridge and an out bridge. Clone these and keep track of them, direct them to an addandlevel er

	public AddAndLevel mixer;


	private void Awake()
	{
		if (oscPrefab == null)
		{ //default
			var ggg = new GameObject();
			var innn = ggg.AddComponent<InBridge>();
			var osc = ggg.AddComponent<SinOscillator>();
			osc.frequency = innn;
		}
		if (mixer == null)
		{
			mixer = gameObject.AddComponent<AddAndLevel>();
			mixer.levelMode = AddAndLevel.LevelMode.clip;
		}
	}

	GameObject GetFreeOsc()
	{
		if (unusedOscillators.Count > 0)
		{
			Debug.Log("osc exists");
			return unusedOscillators.Pop();
		} else
		{
			Debug.Log("new osc");
			var osc = Instantiate(oscPrefab);
			var temp = new List<Component>(mixer.inputs); //it is dumb Unity can't inspect Lists without a custom editor
			temp.Add(osc.GetComponent<OutBridge>());
			mixer.inputs = temp.ToArray();//WET FLOOR: this code is bad and I feel bad. But the fix is to dupe AddAndLevel using a List<> instead of an array, write a custom inspector (not actually that hard), or pull out "bundle of inputs" and make mixer take that instead of having its own collection, then have one of those with an array and one with a list. Fixes without taking either step, but will be confusing to work with unless we bury all these components behind the scenes. "bridge" is already pretty sketch.
			return osc;
		}
	}

	void NoteOn(MidiChannel channel, int note, float velocity)
	{
		if (velocity == 0f)
		{
			//NoteOff(channel, note);
			return;//my keyboard is weird. Is this normal? Note on at 0 and then off?
		}
		if (channel != this.channel) {
			return;
		}
		Debug.Log("NoteOn: " + channel + "," + note + "," + velocity);
		var osc = GetFreeOsc();
		var bridge = osc.GetComponent<InBridge>();
		bridge.freq = MidiNoteToFrequency(note);
		bridge.vol = velocity;

		playingOscillators[note] = osc;
		
		//var temp = new List<Component>(mixer.inputs); //it is dumb Unity can't inspect Lists without a custom editor
		//temp.Add(osc.GetComponent<OutBridge>());
		//mixer.inputs = temp.ToArray();//WET FLOOR: this code is bad and I feel bad. But the fix is to dupe AddAndLevel using a List<> instead of an array, write a custom inspector (not actually that hard), or pull out "bundle of inputs" and make mixer take that instead of having its own collection, then have one of those with an array and one with a list. Fixes without taking either step, but will be confusing to work with unless we bury all these components behind the scenes. "bridge" is already pretty sketch.
	}

	void NoteOff(MidiChannel channel, int note)
	{
		if(this.channel != channel) {
			return;
		}
		Debug.Log("NoteOff: " + channel + "," + note);
		var osc = playingOscillators[note];
		playingOscillators.Remove(note);
		unusedOscillators.Push(osc);
		var bridge = osc.GetComponent<InBridge>();
		bridge.vol = 0f;
		//var temp = new List<Component>(mixer.inputs);
		//temp.Remove(osc.GetComponent<OutBridge>());
		//mixer.inputs = temp.ToArray();
	}

	void OnEnable()
	{
		MidiMaster.noteOnDelegate += NoteOn;
		MidiMaster.noteOffDelegate += NoteOff;
	}

	void OnDisable()
	{
		MidiMaster.noteOnDelegate -= NoteOn;
		MidiMaster.noteOffDelegate -= NoteOff;
	}

	static float MidiNoteToFrequency(int note)
	{
		//copied off http://glassarmonica.com/science/frequency_midi.php
		return 27.5f * Mathf.Pow(2f, (note - 21) / 12f);
	}

}
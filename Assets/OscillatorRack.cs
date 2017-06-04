using UnityEngine;
using MidiJack;
using System.Collections.Generic;

public class OscillatorRack : MonoBehaviour
{

	public MidiChannel channel;

	private Stack<GameObject> unusedOscillators;
	private Dictionary<int, GameObject> playingOscillators;
	public GameObject oscPrefab;//has an InBridge and an out bridge. Clone these and keep track of them, direct them to an addandlevel er

	public AddAndLevel mixer;

	public Component volumeSource;
	public constantOut silenceSource;


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
		if (volumeSource == null)
		{
			volumeSource = gameObject.AddComponent<constantOut>();
			((constantOut)volumeSource).valll = .25f;//safe default? Or else could go 1 and set the mixer to safeLevel
		}
		if (silenceSource == null)
		{
			gameObject.AddComponent<constantOut>();//default val will be 0.
		}
	}

	GameObject GetFreeOsc()
	{
		if (unusedOscillators.Count > 0)
		{
			return unusedOscillators.Pop();
		} else
		{
			return Instantiate(oscPrefab);
		}
	}

	void NoteOn(MidiChannel channel, int note, float velocity)
	{
		Debug.Log("NoteOn: " + channel + "," + note + "," + velocity);
		var osc = GetFreeOsc();
		var bridge = osc.GetComponent<InBridge>();
		bridge.freq = MidiNoteToFrequency(note);
		bridge.vol = velocity;

		playingOscillators[note] = osc;
	}

	void NoteOff(MidiChannel channel, int note)
	{
		Debug.Log("NoteOff: " + channel + "," + note);
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
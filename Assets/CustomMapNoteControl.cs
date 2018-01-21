using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class CustomMapNoteControl : NoteControl {

	[System.Serializable]
	public class noteMap
	{ public MidiChannel channel; public int inNote; public int outNote; }

	public noteMap[] mappings;

	void NoteOn(MidiChannel channel, int note, float velocity)
	{
		print("lp" + note + channel);
		foreach (noteMap map in mappings) {
			if (channel == map.channel && map.inNote == note)
			{
				StartNote(map.outNote, velocity);
			} }
	}

	void NoteOff(MidiChannel channel, int note)
	{
		foreach (noteMap map in mappings)
		{
			if (channel == map.channel && map.inNote == note)
			{
				StopNote(map.outNote);
			}
		}
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MidiJackNoteControl : NoteControl {

	public MidiChannel channel;

	void NoteOn(MidiChannel channel, int note, float velocity) {
		if(channel == this.channel) {
			StartNote(note, velocity);
		}
	}

	void NoteOff(MidiChannel channel, int note) {
		if(channel == this.channel) {
			StopNote(note);
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

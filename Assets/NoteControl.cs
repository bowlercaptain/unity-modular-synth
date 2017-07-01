using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControl : MonoBehaviour {//dynamic music can call these delegates custom, inherited classes will read from midi keyboard / midi file.

	public NoteOnDelegate noteOn;
	public NoteOffDelegate noteOff;

	public delegate void NoteOnDelegate(int note, float velocity);
	public delegate void NoteOffDelegate(int note);

	public void StartNote(int note, float velocity) {
		if (noteOn != null) { noteOn(note, velocity); }
	}

	public void StopNote(int note) {
		if(noteOff!=null) { noteOff(note); }
	}
}

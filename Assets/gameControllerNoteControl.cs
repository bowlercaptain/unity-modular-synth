using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControllerNoteControl : NoteControl
{
	[System.Serializable]
	public class buttonMap
	{ public string buttonName; public int note; }//this should be a struct but serialization lul

	public buttonMap[] noteMappings;
	
	// Update is called once per frame
	void Update () {
		foreach(buttonMap map in noteMappings) {
			if(Input.GetButtonDown(map.buttonName)) {
				noteOn(map.note,.5f);
			}
			if(Input.GetButtonUp(map.buttonName)) { noteOff(map.note); }
		}
	}
}

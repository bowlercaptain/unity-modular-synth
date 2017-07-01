using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNoteControl : NoteControl {

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.H)) {
			StartNote(1,1f);
		}
		if(Input.GetKeyUp(KeyCode.H)) {
			StopNote(1);
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			StartNote(8, 1f);
		}
		if (Input.GetKeyUp(KeyCode.L))
		{
			StopNote(8);
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			StartNote(13, 1f);
		}
		if (Input.GetKeyUp(KeyCode.F))
		{
			StopNote(13);
		}
	}

	
}

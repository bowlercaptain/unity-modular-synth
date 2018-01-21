using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class mono : MonoBehaviour {

	public float[] fill = new float[1024];
	private bool[] doneBox = { false };

	public float[] gibSignal(List<bool[]> doneBoxes, int length) {
		if (doneBox[0]) {
			return fill;
		} else {
			doneBox[0] = true;
			doneBoxes.Add(doneBox);
			return getSignal(doneBoxes, length);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="length"></param>
	/// <returns>A float array </returns>
	abstract public float[] getSignal(List<bool[]> doneBoxes, int length);//nobody else should ever call this

}

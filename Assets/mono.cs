using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class mono : MonoBehaviour {

	public float[] fill = new float[1024];
	private bool[] doneBox = { false };
	protected int length;

	public mono[] monoInputs = new mono[0];
	public Knob[] knobInputs = new Knob[0];

	public float[] gibSignal(List<bool[]> doneBoxes) {
		if (!doneBox[0]) {
			doneBox[0] = true;
			doneBoxes.Add(doneBox);
			getSignal(doneBoxes);
		}
		return fill;
	}

	/// <summary>
	/// build "fill" to length
	/// </summary>
	/// <param name="length"></param>
	/// <returns>A float array </returns>
	abstract protected void getSignal(List<bool[]> doneBoxes);//nobody else should ever call this

	public virtual void setLength(int length) {
		fill = new float[length];
		this.length = length;
	}
	public virtual int getNumMonos() { return 0; }
	public virtual int getNumKnobs() { return 1; }
}

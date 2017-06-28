using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class mono : MonoBehaviour {

	public float[] fill = new float[1024];

	/// <summary>
	/// 
	/// </summary>
	/// <param name="length"></param>
	/// <returns>A float array </returns>
	abstract public float[] getSignal(int length);

}

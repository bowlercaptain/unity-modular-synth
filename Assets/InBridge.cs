using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBridge : MonoBehaviour {
	public constantOut frequency;
public float freq {
	set { frequency.value = value; }
}
	public constantOut volume;
public float vol {
	set { volume.value = value; }
}
}

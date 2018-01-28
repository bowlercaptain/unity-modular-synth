using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Oscillator : mono {

    public abstract float waveFunction(float position);

    private void Awake()
    {
        if (volume == null)
        {
			Debug.Log("Adding a volume input for your convenience.");
            volume = gameObject.AddComponent<constantOut>();
            ((constantOut)volume).value = 1;
        }
		if(frequency==null) {
			Debug.Log("Adding a frequency input for your convenience.");
			frequency = gameObject.AddComponent<constantOut>();
			((constantOut)frequency).value = 0;
		}
    }

    float currentPos;

    public mono frequency;

    public mono volume;

	protected override void getSignal(List<bool[]> doneBoxes) {

		fill = new float[length];

        float[] freqs = frequency.gibSignal(doneBoxes);
        float[] vols = volume.gibSignal(doneBoxes);
        for (int i = 0; i < length; i++)
        {
            currentPos += freqs[i] / info.sampleRate;
            fill[i] = waveFunction(currentPos)*vols[i];
        }
        while (currentPos > 1f) { currentPos -= 1f; }
        while (currentPos < -1f) { currentPos += 1f; }
    }
}

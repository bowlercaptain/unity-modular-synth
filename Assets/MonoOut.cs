using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoOut : MonoBehaviour {

    public mono[] monoInputs;

    public mono input{
get{return monoInputs[0];}
set{monoInputs[0]=value;}
}

    private void OnAudioFilterRead(float[] data, int channels)
    {
		List<bool[]> doneBoxes = new List<bool[]>() ;
        var datta = input.gibSignal(doneBoxes);
		foreach (var box in doneBoxes) { box[0] = false; }
        for(int i = 0; i < data.Length/channels; i++)
        {
            for (int j = 0; j < channels; j++)
            {
                data[i * channels + j]=datta[i];
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOut : MonoBehaviour {

    public Component input;
    private mono inputMono
    {
        get { return (mono)input; }
        set { input = (Component)value; Debug.Log("please tell Robert why you just did this, I could not come up with a use case but put it in place anyway"); }
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        //Debug.Log(channels);
        //Debug.Log(data.Length);

        //for(int i=0; i<data.Length; i++)
        //{

        //}
        var datta = inputMono.getSignal(data.Length / channels);
        for(int i = 0; i < data.Length/channels; i++)
        {
            for (int j = 0; j < channels; j++)
            {
                data[i * channels + j]=datta[i];
            }
        }
    }

    public void Awake()
    {
        Debug.Log(AudioSettings.outputSampleRate);
    }

}

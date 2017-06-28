using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOut : MonoBehaviour {

    public mono input;


    private void OnAudioFilterRead(float[] data, int channels)
    {
        //Debug.Log(channels);
        //Debug.Log(data.Length);

        //for(int i=0; i<data.Length; i++)
        //{

        //}
        var datta = input.getSignal(data.Length / channels);
        for(int i = 0; i < data.Length/channels; i++)
        {
            for (int j = 0; j < channels; j++)
            {
                data[i * channels + j]=datta[i];
            }
        }
    }



}

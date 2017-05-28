using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour {

    public static int sampleRate;
    private void Awake()
    {
        sampleRate = AudioSettings.outputSampleRate;
    }
}

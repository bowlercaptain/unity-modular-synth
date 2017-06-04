using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class knobOutput : MonoBehaviour, mono {

    public MidiChannel channel;
    public int knobNumber;
    float knobValue;

    public float[] getSignal(int length)
    {
        float[] fill = new float[length];
        for (int i = 0; i < length; i++)
        {
            fill[i] = knobValue;
        }
        return fill;
    }

    void Knob(MidiChannel channel, int knobNumber, float knobValue)
    {
        if (channel == this.channel && knobNumber == this.knobNumber)
        {
            knobValue = this.knobValue;
        }
    }

    private void OnEnable()
    {
        MidiMaster.knobDelegate += Knob;
    }

    private void OnDisable()
    {
        MidiMaster.knobDelegate -= Knob;
    }
}

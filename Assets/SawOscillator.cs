using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawOscillator : Oscillator
{
    public override float waveFunction(float position)
    {
        return (position * 2 + 1f) % 2f - 1f;
    }
}
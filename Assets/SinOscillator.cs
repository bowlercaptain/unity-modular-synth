using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinOscillator : Oscillator
{
    public override float waveFunction(float position)
    {
        return Mathf.Sin(2 * Mathf.PI * position);
    }
}

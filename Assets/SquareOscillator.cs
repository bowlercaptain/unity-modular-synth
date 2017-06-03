using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareOscillator : Oscillator
{
    public override float waveFunction(float position)
    {
        return Mathf.Floor((position * 2 + 1f) % 2f) * 2f - 1f;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curveOscillator : Oscillator {

    [Tooltip("Output values between -1 and 1, one full cycle should be from 0 to 1 horizontally. Use pingpong or loop endpoints!")]
    public AnimationCurve curve;

    public override float waveFunction(float position)
    {
        return curve.Evaluate(position);
    }
}

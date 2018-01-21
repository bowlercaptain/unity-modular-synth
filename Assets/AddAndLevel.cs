using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAndLevel : mono
{



	public mono[] inputs;

	

	public enum LevelMode
	{
		safeLevel,
		clip,
		capLevel,
		dontLevel
	}

	private float capValue = .01f;

	public LevelMode levelMode = LevelMode.safeLevel;

	public override float[] getSignal(List<bool[]> doneBoxes, int length)
	{

		fill = new float[length];
		float[][] sources = new float[inputs.Length][];
		for (int i = 0; i < inputs.Length; i++)
		{
			sources[i] = inputs[i].gibSignal(doneBoxes, length);
		}
		for (int i = 0; i < length; i++)
		{
			float sample = 0f;
			for (int j = 0; j < sources.Length; j++)
			{
				sample += sources[j][i];
			}
			switch (levelMode)
			{
				case LevelMode.safeLevel:
					sample /= Mathf.Min((float)inputs.Length,1);
					break;
				case LevelMode.clip:
					sample = Mathf.Clamp(sample, -1f, 1f);
					break;
				case LevelMode.capLevel:
					if (Mathf.Abs(sample) > capValue) { capValue = Mathf.Abs(sample); }
					sample /= capValue;
					
					break;
				case LevelMode.dontLevel:
					break;
				default:
					throw new System.NotImplementedException("That's not a level mode yet, you need to actually write code for this");
			}
			fill[i] = sample;
		}

		return fill;
	}

	private void Update()
	{
		capValue = capValue * .99f;
	}


}

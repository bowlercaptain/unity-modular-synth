﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthVisualizer : MonoBehaviour {

    public mono toShow;

    // When added to an object, draws colored rays from the
    // transform position.

    public void Awake()
    {
        CreateLineMaterial();
    }

    static Material lineMaterial;
	static void CreateLineMaterial()
	{
		if (!lineMaterial)
		{
			// Unity has a built-in shader that is useful for drawing
			// simple colored things.
			Shader shader = Shader.Find("Hidden/Internal-Colored");
			lineMaterial = new Material(shader);
			lineMaterial.hideFlags = HideFlags.HideAndDontSave;
			// Turn on alpha blending
			lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
			lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
			// Turn backface culling off
			lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
			// Turn off depth writes
			lineMaterial.SetInt("_ZWrite", 0);
		}
	}

	// Will be called after all regular rendering is done
	public void OnRenderObject()
	{
		float[] heights = toShow.fill;
		//CreateLineMaterial();
		// Apply the line material
		lineMaterial.SetPass(0);
		
		GL.PushMatrix();
		// Set transformation matrix for drawing to
		// match our transform
		GL.MultMatrix(transform.localToWorldMatrix);

		// Draw lines
		GL.Begin(GL.LINES);

		GL.Color(new Color(0, 1, 0, 0.8F));
		GL.Vertex3(-.5f, heights[0]/2f, -.50001f);
		for (int i = 1; i < heights.Length; ++i)
		{
			float a = i / (float)heights.Length;
			// Vertex colors change from red to green
			GL.Color(new Color(a, 1 - a, 0, 0.8F));
			// One vertex at transform position
			GL.Vertex3(a-.5f, heights[i]/2f, -.50001f);
		}
		GL.End();
		GL.PopMatrix();
	}


    LineRenderer[] wires;
    private void Start()
    {
        DrawWires();

    }

    void DrawWires()
    {
        foreach (var wire in wires)
        {
            ReturnWire(wire);
        }
        wires = new LineRenderer[toShow.getNumMonos()];
        for (int i = 0; i < toShow.monoInputs.Length; i++)
        {
            wires[i].SetPositions(new Vector3[]{ transform.position, toShow.monoInputs[i].transform.position});
        }
    }

    static void ReturnWire(LineRenderer wire) { wire.enabled = false; wirePool.Enqueue(wire); }

    static Queue<LineRenderer> wirePool = new Queue<LineRenderer>();
    static LineRenderer getWire()
    {
        if (wirePool.Count > 0)
        {

            var wire = wirePool.Dequeue();
            wire.enabled = true;
            return wire;
        } else
        {
            var lr = new GameObject();
            return lr.AddComponent<LineRenderer>();
        }
    }


}
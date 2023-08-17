using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/*
	This way of making the path accessible was from this tutorial:
		- https://youtu.be/aFxucZQ_5E4
*/

public class PathPoints : MonoBehaviour
{
	public static Transform[] points;

	// Awake is called when the game starts
    void Awake()
	{
		points = new Transform[transform.childCount];
		for (int i = 0; i < points.Length; i++)
			points[i] = transform.GetChild(i);
	}
}

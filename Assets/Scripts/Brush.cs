using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour {
	public GameObject paint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool pressed = Input.GetMouseButton (0);
		if (pressed) {
			GameObject newPaint = GameObject.Instantiate (paint);
			newPaint.transform.position = Input.mousePosition;
		}
	}
}

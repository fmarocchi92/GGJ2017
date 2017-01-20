using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePaint : MonoBehaviour {
	public float hSpeed;
	public float vSpeed;
	private float deltaY = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	//INPUT
		bool pressed = Input.GetKey(KeyCode.Space);
	//MOVEMENT CONTROL
		if (pressed) {
			deltaY += vSpeed;
		} else {
			deltaY -= vSpeed;
		}
		transform.position = new Vector3 (transform.position.x + hSpeed * Time.deltaTime, transform.position.y +deltaY * Time.deltaTime, transform.position.z);

	}
}

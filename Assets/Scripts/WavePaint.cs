using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePaint : MonoBehaviour {
	public float hSpeed;
	public float vSpeed;
	private float deltaY = 0;
	public float pitchRange = 12;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	//INPUT
		bool pressed = Input.GetKey(KeyCode.Space);
	//MOVEMENT CONTROL
		if (transform.position.y +deltaY * Time.deltaTime > pitchRange / 2 || transform.position.y +deltaY * Time.deltaTime < -pitchRange / 2)
			deltaY = 0;
		if (pressed) {
			deltaY += vSpeed;
		} else {
			deltaY -= vSpeed;
		}

		transform.position = new Vector3 (transform.position.x + hSpeed * Time.deltaTime, transform.position.y +deltaY * Time.deltaTime, transform.position.z);
		float tempPitch =  transform.position.y / pitchRange;
		tempPitch=Mathf.Clamp01 (tempPitch+0.5f);

		audioSource.pitch = tempPitch==0?0.1f:(tempPitch * 3);
	}
}

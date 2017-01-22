using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {
	private AudioSource audioSource;
	private Renderer renderer;
	private Shader shader;
	public Material newMaterial;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		print ("CHECKPOINT ACTIVATED!");
		audioSource.Play();
		renderer.material = newMaterial;
		//TODO triggeranimation
	}
}

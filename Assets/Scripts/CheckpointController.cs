using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		print ("CHECKPOINT ACTIVATED!");
		//audioSource.play();
		//TODO triggeranimation
	}
}

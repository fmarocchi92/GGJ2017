using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPiece : MonoBehaviour {

	AudioSource audioSource;
	bool played;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		print (collision.contacts [0].normal);
//		if(collision.gameObject.layer == LayerMask.NameToLayer("Middle")){
		if(collision.contacts [0].normal == new Vector3(0,1,0)){
			if(!audioSource.isPlaying)
			audioSource.Play ();
		played = true;
		Invoke ("destroyFragment", 1.2f);
		}
	}

	void destroyFragment(){
		GameObject.Destroy (gameObject);
	}
}

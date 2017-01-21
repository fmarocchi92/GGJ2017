using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float hSpeed;
	public GameObject waveHead;
	public GameObject player;
	private GameObject currentTarget;
	// Use this for initialization
	void Start () {
		currentTarget = waveHead;
	}

	// Update is called once per frame
	void Update () {
		print (waveHead);
		transform.position = new Vector3 (transform.position.x , transform.position.y, waveHead.transform.position.z);
	}

	public void followPlayer (){
		currentTarget = player;
	}

	public void followWave(){
		currentTarget = waveHead;
	}
}

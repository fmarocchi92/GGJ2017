using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLightController : MonoBehaviour {
	GameObject[] players;
	Material material;
	Color defaultColor;
	// Use this for initialization
	void Start () {
		players=GameManager.getPlayers ();
		print (players);
		material = GetComponent<Renderer> ().material;
		defaultColor = material.color;
	}
	
	// Update is called once per frame
	void Update () {
		bool lightUp = false;
		if (players == null) {
			players = GameManager.getPlayers ();
		}
		for (int i = 0; i < players.Length; i++) {
			if (players [i].transform.position.z > transform.position.z) {
				//CHANGE SHADER PARAMETER
				lightUp = true;
			} 
		}
		if (lightUp) {
			material.color = Color.cyan;
		} else {
			material.color = defaultColor;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject[] players;
	public GameObject[] waveHeads;
	public GameObject[] spotLights;
	public GameObject[] checkPoints;

	// Use this for initialization
	void Start () {
//		for (int i = 0; i < players.Length; i++) {
//			waveHeads [i].GetComponent<WaveController> ().start ();
//		}
		print("3,2,1");
		for (int i = 0; i < players.Length; i++) {
			waveHeads [i].GetComponent<WaveController> ().ready = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void waveHit(int playerIndex){
		print ("playerHit");
		GameObject newSpotlight = Light.Instantiate (spotLights[playerIndex]);
		newSpotlight.transform.position = new Vector3(waveHeads[playerIndex].transform.position.x, waveHeads[playerIndex].transform.position.y,-5);
	}
}

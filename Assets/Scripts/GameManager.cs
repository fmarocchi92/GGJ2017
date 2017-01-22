using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
	public GameObject[] players;
	public GameObject[] waveHeads;
	public GameObject[] spotLights;
	public GameObject[] checkPoints;
	public static GameObject[] playerList;

	// Use this for initialization
	void Start () {
//		for (int i = 0; i < players.Length; i++) {
//			waveHeads [i].GetComponent<WaveController> ().start ();
//		}
		for (int i = 0; i < players.Length; i++) {
			waveHeads [i].GetComponent<WaveController> ().ready = true;
		}
		playerList = players;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void waveHit(int playerIndex){
		GameObject newSpotlight = Light.Instantiate (spotLights[playerIndex]);
		newSpotlight.transform.position = new Vector3(players[playerIndex].transform.position.x +5, players[playerIndex].transform.position.y,players[playerIndex].transform.position.z);
		newSpotlight.transform.rotation = Quaternion.Euler (0, -90, 0);
	}

	public static GameObject[] getPlayers(){
		return playerList;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour {

	public void singlePlayer(){
		SceneManager.LoadScene ("mappalivello1");
	}

	public void multiPlayer(){
		SceneManager.LoadScene ("multiplayer1");
	}

	public void exit(){
		Application.Quit ();
	}

	public void back(){
		SceneManager.LoadScene ("menu");
	}
}

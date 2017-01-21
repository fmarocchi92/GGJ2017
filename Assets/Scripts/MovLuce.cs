using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovLuce : MonoBehaviour {
	public RoboMovement robot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position+=robot.direction*robot.speed*Time.deltaTime;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboMovement : MonoBehaviour {
	public static int x = 0;
	public static Vector3[] vettore;
	public float offset = 131.7f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (WaivePaint.i > 300){
			transform.position = new Vector3 (vettore [x].x, vettore [x].y - offset, vettore [x].z);

			//transform.LookAt (new Vector3(vettore [x].x, vettore [x].y - offset , vettore [x].z));
			
			WaivePaint.i++;
			x++;



	}



}
	public static void startMovement(){
		vettore = WaivePaint.list.ToArray(typeof(Vector3)) as Vector3[];

	}
}
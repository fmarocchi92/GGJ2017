using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaivePaint : MonoBehaviour {
	public float speed = 0;
	public GameObject paint;
	public float accel = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		


		transform.position = new Vector3 (transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
		if (Input.GetKey (KeyCode.W)) {
			accel = accel + 0.5f;
			transform.position = new Vector3 (transform.position.x, transform.position.y + accel * Time.deltaTime, transform.position.z);
		} else {
			accel = accel - 0.5f;
			transform.position = new Vector3 (transform.position.x, transform.position.y + accel * Time.deltaTime, transform.position.z);
			}

		GameObject newPaint = GameObject.Instantiate (paint);
		newPaint.transform.position = transform.position;
	}
}

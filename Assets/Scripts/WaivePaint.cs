using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaivePaint : MonoBehaviour {
	public float speed = 0;
	public GameObject paint;
	public float accel = 0;
	public static int i = 0;
	public static ArrayList list = new ArrayList();
	public float acceladd = 0.3f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (i < 300) {


		


			transform.position = new Vector3 (transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
			if (Input.GetKey (KeyCode.W)) {
				accel = accel + acceladd;
				transform.position = new Vector3 (transform.position.x, transform.position.y + accel * Time.deltaTime, transform.position.z);
			} else {
				accel = accel - acceladd;
				transform.position = new Vector3 (transform.position.x, transform.position.y + accel * Time.deltaTime, transform.position.z);
			}

			GameObject newPaint = GameObject.Instantiate (paint);
			newPaint.transform.position = transform.position;
			list.Add (transform.position);
			i++;
		} else if (i == 300) {
//			RoboMovement.startMovement ();
			i++;
		}

	}
}

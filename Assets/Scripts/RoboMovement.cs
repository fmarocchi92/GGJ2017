using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboMovement : MonoBehaviour {
	public int x = 1;
	public  Transform[] vettore;
	public float offset = 1f;
	public ArrayList list = new ArrayList ();
	public bool moving;
	public float speed;
	public WaveController waveController;
	public Vector3 direction;
	private bool toggle;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		if (moving) {
			
		//	float angle = Mathf.Atan2 (vettore [x + 1].y - vettore[x].y, vettore [x + 1].z - vettore[x].z)*180/Mathf.PI;
			print(x);
			print (list.Count);
	//		direction =Vector3.Normalize( vettore [x + 1] - vettore[x]);
//			transform.RotateAround(transform.position,Vector3.right, angle);
			transform.position = new Vector3 (((Transform)list[x]).transform.position.x,((Transform)list[x]).transform.position.y - offset, ((Transform)list[x]).transform.position.z);

			transform.LookAt (new Vector3(((Transform)list[x]).transform.position.x, ((Transform)list[x]).transform.position.y /*- offset */, 0));
//			transform.forward = Vector3.Normalize(new Vector3(vettore [x].x-transform.position.x, vettore [x].y-transform.position.y /*- offset */, vettore[x].z-transform.position.z));
//			transform.position = new Vector3( transform.position.x, vettore [x].y, transform.position.z);
//			transform.Translate (direction*speed*Time.deltaTime);
	//		transform.position+=direction*speed*Time.deltaTime;
		//	transform.rotation = Quaternion.Euler (new Vector3(-angle, 0, 0));

		//	if(vettore[x + 1].z <= transform.position.z)
			if(toggle)
				x = x +2 ;
			toggle = !toggle;
			print (x);
			//WaivePaint.i++;
			if (x >= list.Count) {
				x = 0;
				moving = false;
				waveController.ready = true;
				waveController.hitSequence ();
			}
		}


//	}



}
	public void startMovement(){
		print ("start Robot movement");
//		vettore = list.ToArray(typeof(Transform)) as Transform[];
		print ("vettore length:" + vettore.Length);
		moving = true;
	}

}
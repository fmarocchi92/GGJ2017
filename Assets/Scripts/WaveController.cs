using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {
	public float hSpeed;
	public float vSpeed;
	private float deltaY = 0;
	public float pitchRange = 12;
	public float maxHeight;
	public float minHeight;
	public int playerId;
	public GameObject paint;
	private AudioSource audioSource;
	public GameObject lastCheckPoint;
	public GameManager gameManager;
	public GameObject player;
	private RoboMovement playerController;
	private TrailRenderer trailRenderer;
	public Transform target;
	public bool moving = false;
	public bool ready = false;
	public CameraController cameraController;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		trailRenderer = GetComponent<TrailRenderer> ();
		playerController = player.GetComponent<RoboMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ready && !moving) {
			moving = Input.GetKey (KeyCode.Space);
		}
		if (moving) {
			cameraController.followWave ();
			//INPUT
			bool pressed = Input.GetKey (KeyCode.Space);
			//MOVEMENT CONTROL
			if (transform.position.y + deltaY * Time.deltaTime > maxHeight || transform.position.y + deltaY * Time.deltaTime < minHeight)
				deltaY = 0;
			if (pressed && !(transform.position.y + deltaY * Time.deltaTime > maxHeight)) {
				deltaY += vSpeed;
			} else if(!pressed && !(transform.position.y + deltaY * Time.deltaTime < minHeight)){
				deltaY -= vSpeed;
			}


			transform.position = new Vector3 (transform.position.x , transform.position.y + deltaY * Time.deltaTime, transform.position.z+ hSpeed * Time.deltaTime);
			float tempPitch = transform.position.y / pitchRange;
			tempPitch = Mathf.Clamp01 (tempPitch + 0.5f);

			audioSource.pitch = tempPitch == 0 ? 0.1f : (tempPitch * 3);

			//points instantiation
			GameObject newPaint = GameObject.Instantiate (paint);
			newPaint.transform.position = transform.position;
			playerController.list.Add (transform.position);

			if (transform.position.z >= target.position.z) {
				print ("wave reached goal");
				movePlayer ();
			}
		}
	}


	void OnTriggerEnter (Collider other){
		print ("collision with: "+other.gameObject.tag +" " +other.gameObject);
		switch (other.gameObject.tag) {
		case "checkpoint":
			if (other.gameObject.Equals(lastCheckPoint)) {
				break;
			}
			lastCheckPoint = other.gameObject;
			print ("hitting checkpoint");
			movePlayer ();
			break;
		case "goal":
			movePlayer ();
			break;
		default:
			stopWave ();
			gameManager.waveHit (playerId);
			hitSequence();
			break;
		}
	}

	void hitSequence(){
		print ("hit animation, maybe here i need to wait for the animation to end or just a timer before teleporting");
		trailRenderer.time = -1;
		transform.position = player.transform.position;
		Invoke("ResetTrails", 0.03f);
		foreach(Vector3 c in playerController.list){
//			GameObject.Destroy (c.gameObject);
		}
		playerController.list.Clear ();

	}

	void ResetTrails(){
		trailRenderer.time = 30;
	}
	void stopWave(){
		moving = false;
		ready = true;
		deltaY = 0;
	}
	void movePlayer(){
		cameraController.followPlayer ();
		moving = false;
		ready = false;
		deltaY = 0;
		playerController.startMovement ();
	}
}

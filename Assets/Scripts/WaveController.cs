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
			if (Input.GetKey (KeyCode.Space)) {
				moving = true;
				print ("invoke movePlayer");
				Invoke ("movePlayer", 1f);
			}
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
			playerController.list.Add (newPaint.transform);


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

			break;
		case "goal":
			
			break;
		default:
			stopWave ();
			break;
		}
	}

	public void hitSequence(){
		print ("hit animation, maybe here i need to wait for the animation to end or just a timer before teleporting");
		trailRenderer.time = -1;
		gameManager.waveHit (playerId);
		transform.position = playerController.lastCheckPoint.transform.position;
		Invoke("ResetTrails", 0.03f);
		Transform[] vettore = playerController.list.ToArray(typeof(Transform)) as Transform[];
		for (int i = 0; i < vettore.Length; i++) {
			GameObject.Destroy (vettore [i].gameObject);
		}
		stopWave ();
		playerController.list.Clear ();
		player.transform.position = transform.position;

	}

	void teleport(){

	}

	void ResetTrails(){
		trailRenderer.time = 30;
	}
	public void stopWave(){
		moving = false;
		ready = true;
		deltaY = 0;
	}
	void movePlayer(){
//		cameraController.followPlayer ();
//		moving = true;
//		ready = false;
//		deltaY = 0;
		playerController.startMovement ();

	} 
}

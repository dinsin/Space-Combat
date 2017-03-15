using UnityEngine;
using System.Collections;

public class P1RotationMove : MonoBehaviour {

	public float rotationSpeed;
	public float thrust;
	public float speed = 15f;
	public GameObject player;
	Rigidbody2D playerRB;


	// Use this for initialization
	void Start () {
		playerRB = player.GetComponent<Rigidbody2D> ();
		rotationSpeed = 250f;
		thrust = 1f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float horizontal = Input.GetAxis ("Horizontal (P1)");
		float vertical = Input.GetAxis ("Vertical (P1)");
		transform.Translate(0f, vertical * Time.deltaTime * speed, 0f);
		transform.Rotate (0, 0, -horizontal * rotationSpeed * Time.deltaTime);
		playerRB.AddForce (vertical * transform.up * thrust * Time.deltaTime);
		
		/*
		if (Input.GetKey(KeyCode.D)){
			Vector3 newRotation = transform.rotation.eulerAngles;
    		newRotation.z += 10;
   			transform.rotation = Quaternion.Euler (newRotation);
		}       
		else if (Input.GetKey(KeyCode.A)) {
   			Vector3 newRotation = transform.rotation.eulerAngles;
   			newRotation.z -= 10;
    		transform.rotation = Quaternion.Euler (newRotation);
		}
		*/

	}
}

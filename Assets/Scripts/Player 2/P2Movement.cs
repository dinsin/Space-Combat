using UnityEngine;
using System.Collections;

public class P2Movement : MonoBehaviour {

	public float speed = 5f;

	// Update is called once per frame
	void Update () {

		// "horizontal" controls horizontal input (A & D, Left Arrow & Right Arrow)
		// GetAxis returns -1  to 1... it is 0 if nothing is pressed
		float horizontal = Input.GetAxis("Horizontal (P2)");	
		// Up & down, W & S
		// Mapped input can be seen in Unity via Edit -> Project Settings -> Input
		float vertical = Input.GetAxis("Vertical (P2)");

		// Time.deltaTime is the length of the frame in seconds
		// Multply stuff by deltaTime to make it framerate INDEPENDENT
		transform.Translate(horizontal * Time.deltaTime * speed, vertical * Time.deltaTime * speed, 0f);
		// For example, running at 100fps, deltaTime will be .01f. At 10FPS, deltaTime will be .1f

	}
}

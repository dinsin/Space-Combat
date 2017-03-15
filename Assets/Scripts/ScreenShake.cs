using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	Vector3 startPosition;
	float shakeStrength;
	public GameObject player1;
	public GameObject player2;
	float currentHealthP1;
	float currentHealthP2;

	// Use this for initialization
	void Start () {
		// Remember where the camera started
		startPosition = transform.position;

		currentHealthP1 = player1.GetComponent<Damageable> ().remainingHealth;

		currentHealthP2 = player2.GetComponent<Damageable> ().remainingHealth;
	}

	// Update is called once per frame
	void Update () {

		if(player1 != null && (currentHealthP1 > player1.GetComponent<Damageable>().remainingHealth)){
		//if (Input.GetKey(KeyCode.Space)){
			shakeStrength = 1.5f;
			currentHealthP1 = player1.GetComponent<Damageable> ().remainingHealth;
		}
		else if (player1 != null && (currentHealthP1 < player1.GetComponent<Damageable>().remainingHealth)){	// Checks if health has increased, and accounts for that
			currentHealthP1 = player1.GetComponent<Damageable> ().remainingHealth;
		}

		if(player2 != null && (currentHealthP2 > player2.GetComponent<Damageable>().remainingHealth)){
			//if (Input.GetKey(KeyCode.Space)){
			shakeStrength = 1.5f;
			currentHealthP2 = player2.GetComponent<Damageable> ().remainingHealth;
		}
		else if (player2 != null && (currentHealthP2 < player2.GetComponent<Damageable>().remainingHealth)){	// Checks if health has increased, and accounts for that
			currentHealthP2 = player2.GetComponent<Damageable> ().remainingHealth;
		}

		// Decay shakeStrength over time
		shakeStrength = Mathf.Clamp(shakeStrength - Time.deltaTime, 0f, 1f);

		// Multiply inside sin wave for faster frequency
		// Multiply outside sin wave for distance/amplitude
		transform.position = startPosition 
			+ shakeStrength * (
				transform.right * Mathf.Sin (Time.time * 25f) * .06f 
				+ transform.up * Mathf.Sin (Time.time * 17f) * .06f);

	}
}


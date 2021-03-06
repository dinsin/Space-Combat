using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour {

	public float verticalVelocity = 0.0f;
	public float horizontalVelocity = 0.0f;

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 15f);
	}

	void FixedUpdate (){

		transform.Translate (horizontalVelocity * Time.deltaTime, verticalVelocity * Time.deltaTime, 0f);

	}

	void OnTriggerEnter2D(Collider2D activator){

		if (activator.tag == "BulletPass"){
			return;
		}

		if (activator.GetComponent<Damageable>() != null){
			activator.GetComponent<Damageable> ().remainingHealth -= 20;
			activator.attachedRigidbody.AddForce (new Vector2 (500, 700));
		}

	}
}
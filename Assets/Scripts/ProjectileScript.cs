using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

	public float verticalVelocity = 0.0f;
	public float horizontalVelocity = 0.0f;

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 3f);
	}

	void FixedUpdate (){

		transform.Translate (horizontalVelocity * Time.deltaTime, verticalVelocity * Time.deltaTime, 0f);

	}

	void OnTriggerEnter2D(Collider2D activator){

		if (activator.tag == "BulletPass"){
			return;
		}

		if (activator.GetComponent<Damageable>() != null){
			activator.GetComponent<Damageable> ().remainingHealth -= 5;
			Destroy (this.gameObject);
		}

	}
}
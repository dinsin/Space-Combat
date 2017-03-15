using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {

	public float remainingHealth = 100f;

	// Update is called once per frame
	void Update () {
		if(remainingHealth <= 0){
			Destroy (this.gameObject);
		}
	}
}

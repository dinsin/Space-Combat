using UnityEngine;
using System.Collections;

public class weaponUpgrade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 4f);
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D activator){

		if (activator.GetComponent<P1Shoot>() != null){					// Checks if its P1, and assigns powerup
			if (activator.GetComponent<P1Shoot>().weaponLevel != 3){
				activator.GetComponent<P1Shoot> ().weaponLevel += 1;
				Destroy (this.gameObject);
			}
			else{
				Destroy (this.gameObject);
			}
		}
		else if (activator.GetComponent<P2Shoot>() != null){			// Checks if its P2, and assigns powerup
			if (activator.GetComponent<P2Shoot>().weaponLevel != 3){
				activator.GetComponent<P2Shoot> ().weaponLevel += 1;
				Destroy (this.gameObject);
			}
			else{
				Destroy (this.gameObject);
			}
		}

	}
}

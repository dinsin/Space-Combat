using UnityEngine;
using System.Collections;

public class DamageFlash : MonoBehaviour {

	public SpriteRenderer playerSprite;
	public GameObject player;
	float currentHealth;
	Color initial;

	void Start() {
		
		initial = playerSprite.color;
		currentHealth = player.GetComponent<Damageable> ().remainingHealth;


	}

	// Update is called once per frame
	void Update () {
		if ( player != null && (currentHealth > player.GetComponent<Damageable> ().remainingHealth)){
			StartCoroutine (Damage (2));
			currentHealth = player.GetComponent<Damageable> ().remainingHealth;
		}
	}

	IEnumerator Damage(int flashCountMax = 1){
		for (int flashCount = 0; flashCount < flashCountMax; flashCount++){
			playerSprite.color = new Color (1f, 0f, 0f);
			yield return new WaitForSeconds (0.05f);
			playerSprite.color = new Color (1f, 1f, 1f);
			yield return new WaitForSeconds (0.05f);
			playerSprite.color = initial;

			if(flashCount == 3){
				yield break;
			}

		}
	}
}

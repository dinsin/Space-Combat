using UnityEngine;
using System.Collections;

public class BottomGenerator : MonoBehaviour {

	public GameObject crossShotPowerup;
	public GameObject healthPowerup;
	public GameObject weaponUpgrade;
	float elapsedTime = 0.0f;
	ArrayList powerupPrefabs = new ArrayList();

	// Use this for initialization
	void Start () {
		powerupPrefabs.Add (crossShotPowerup);
		powerupPrefabs.Add (healthPowerup);
		powerupPrefabs.Add (weaponUpgrade);
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		float spawnInterval = Random.Range (12.5f, 20.0f);
		if (elapsedTime > spawnInterval){
			int powerup = Random.Range (0, 3);
			int aimOffset = Random.Range (1, 10);
			int horizontalForce = Random.Range (-100, 100);
			int verticalForce = Random.Range (100, 500);
			GameObject newPowerup = (GameObject)Instantiate ((GameObject)powerupPrefabs[powerup], 
				(transform.position - ((transform.right + transform.up)/aimOffset)), Quaternion.Euler(0f, 0f, 0f));
			newPowerup.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (horizontalForce, verticalForce));
			elapsedTime = 0.0f;
		}
	}
}

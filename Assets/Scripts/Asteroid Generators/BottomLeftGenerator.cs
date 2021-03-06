using UnityEngine;
using System.Collections;

public class BottomLeftGenerator : MonoBehaviour {

	public GameObject asteroidPrefab;
	float elapsedTime = 0.0f;
	ArrayList debrisPrefabs = new ArrayList();

	// Use this for initialization
	void Start () {
		debrisPrefabs.Add (asteroidPrefab);
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		float spawnInterval = Random.Range (10.0f, 35.0f);
		if (elapsedTime > spawnInterval){
			int debris = Random.Range (0, 0);
			int aimOffset = Random.Range (1, 10);
			int horizontalForce = Random.Range (200, 300);
			int verticalForce = Random.Range (100, 400);
			GameObject newDebris = (GameObject)Instantiate ((GameObject)debrisPrefabs[debris], 
				(transform.position - ((transform.right + transform.up)/aimOffset)), Quaternion.Euler(0f, 0f, 0f));
			newDebris.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (horizontalForce, verticalForce));
			elapsedTime = 0.0f;
		}
	}
}

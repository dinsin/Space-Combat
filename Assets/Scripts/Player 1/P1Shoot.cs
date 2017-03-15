using UnityEngine;
using System.Collections;

public class P1Shoot : MonoBehaviour {

	public int weaponLevel = 1;

	public GameObject standardProjectile;
	public GameObject crossShotProjectile;
	float standardElapsedTime = 0.0f;

	public float crossShotPowerupTime = 0.0f;
	float crossShotElapsedTime = 0.0f;

	ArrayList projectilePrefabs = new ArrayList();

	// Use this for initialization
	void Start () {
		projectilePrefabs.Add (standardProjectile);
		projectilePrefabs.Add (crossShotProjectile);
	}
	
	// Update is called once per frame
	void Update () {


		standardElapsedTime += Time.deltaTime;
		float standardSpawnInterval = .5f;

		if (weaponLevel == 1) {
			if (standardElapsedTime > standardSpawnInterval) {

				GameObject newProjectile = (GameObject)Instantiate ((GameObject)projectilePrefabs[1],
					transform.position + transform.up, Quaternion.Euler (0f, 0f, 0f));

				newProjectile.transform.rotation = this.transform.rotation;

				Physics2D.IgnoreCollision (newProjectile.GetComponent<BoxCollider2D> (), 
					this.GetComponent<CircleCollider2D> ());

				newProjectile.GetComponent<ProjectileScript> ().verticalVelocity = 20f;

				standardElapsedTime = 0.0f;
			}			
		}
		else if (weaponLevel == 2) {
			if (standardElapsedTime > standardSpawnInterval) {

				int projectileNumber = Random.Range (0, 0);

				GameObject newProjectileLeft = (GameObject)Instantiate ((GameObject)projectilePrefabs [projectileNumber],
					transform.position + (-transform.right / 3) + transform.up, Quaternion.Euler (0f, 0f, 0f));

				GameObject newProjectileRight = (GameObject)Instantiate ((GameObject)projectilePrefabs [projectileNumber],
					transform.position + (transform.right / 3) + transform.up, Quaternion.Euler (0f, 0f, 0f));

				newProjectileLeft.transform.rotation = this.transform.rotation;
				newProjectileRight.transform.rotation = this.transform.rotation;

				Physics2D.IgnoreCollision (newProjectileLeft.GetComponent<BoxCollider2D> (), 
					this.GetComponent<CircleCollider2D> ());
				Physics2D.IgnoreCollision (newProjectileRight.GetComponent<BoxCollider2D> (), 
					this.GetComponent<CircleCollider2D> ());

				newProjectileLeft.GetComponent<ProjectileScript> ().verticalVelocity = 20f;
				newProjectileRight.GetComponent<ProjectileScript> ().verticalVelocity = 20f;

				standardElapsedTime = 0.0f;
			}
		}
		else if (weaponLevel == 3){
			if (standardElapsedTime > standardSpawnInterval) {

				GameObject newProjectileLeft = (GameObject)Instantiate ((GameObject)projectilePrefabs [1],
					transform.position + (-transform.right / 3) + transform.up, Quaternion.Euler (0f, 0f, 0f));

				GameObject newProjectileMid = (GameObject)Instantiate ((GameObject)projectilePrefabs [1],
					transform.position + transform.up, Quaternion.Euler (0f, 0f, 0f));

				GameObject newProjectileRight = (GameObject)Instantiate ((GameObject)projectilePrefabs [1],
					transform.position + (transform.right / 3) + transform.up, Quaternion.Euler (0f, 0f, 0f));

				newProjectileLeft.transform.rotation = this.transform.rotation;
				newProjectileMid.transform.rotation = this.transform.rotation;
				newProjectileRight.transform.rotation = this.transform.rotation;

				Physics2D.IgnoreCollision (newProjectileLeft.GetComponent<BoxCollider2D> (), 
					this.GetComponent<CircleCollider2D> ());
				Physics2D.IgnoreCollision (newProjectileMid.GetComponent<BoxCollider2D> (), 
					this.GetComponent<CircleCollider2D> ());
				Physics2D.IgnoreCollision (newProjectileRight.GetComponent<BoxCollider2D> (), 
					this.GetComponent<CircleCollider2D> ());

				newProjectileLeft.GetComponent<ProjectileScript> ().verticalVelocity = 15f;
				newProjectileLeft.GetComponent<ProjectileScript> ().horizontalVelocity = -7.5f;
				newProjectileMid.GetComponent<ProjectileScript> ().verticalVelocity = 20f;
				newProjectileRight.GetComponent<ProjectileScript> ().verticalVelocity = 15f;
				newProjectileRight.GetComponent<ProjectileScript> ().horizontalVelocity = 7.5f;

				standardElapsedTime = 0.0f;
			}
		}

		crossShotElapsedTime += Time.deltaTime;
		float crossShotSpawnInterval = 0.75f;
		if(crossShotPowerupTime > 0.0f){
			if (crossShotElapsedTime > crossShotSpawnInterval){
				int projectileNumber = Random.Range (1, 1);

				GameObject newProjectileBottom = (GameObject)Instantiate ((GameObject)projectilePrefabs [projectileNumber],
					transform.position - transform.up, Quaternion.Euler (0f, 0f, 0f));

				GameObject newProjectileLeft = (GameObject)Instantiate ((GameObject)projectilePrefabs [projectileNumber],
					transform.position -transform.right, Quaternion.Euler (0f, 0f, 0f));

				GameObject newProjectileRight = (GameObject)Instantiate ((GameObject)projectilePrefabs [projectileNumber],
					transform.position + transform.right, Quaternion.Euler (0f, 0f, 0f));

				newProjectileBottom.transform.rotation = this.transform.rotation;
				newProjectileLeft.transform.rotation = this.transform.rotation;
				newProjectileRight.transform.rotation = this.transform.rotation;

				Physics2D.IgnoreCollision (newProjectileBottom.GetComponent<CircleCollider2D>(), 
					this.GetComponent<CircleCollider2D>());
				Physics2D.IgnoreCollision (newProjectileLeft.GetComponent<CircleCollider2D>(), 
					this.GetComponent<CircleCollider2D>());
				Physics2D.IgnoreCollision (newProjectileRight.GetComponent<CircleCollider2D>(), 
					this.GetComponent<CircleCollider2D>());

				newProjectileBottom.GetComponent<ProjectileScript> ().verticalVelocity = -15f;
				newProjectileLeft.GetComponent<ProjectileScript> ().horizontalVelocity = -15f;
				newProjectileRight.GetComponent<ProjectileScript> ().horizontalVelocity = 15f;

				crossShotElapsedTime = 0.0f;
			}

			crossShotPowerupTime -= Time.deltaTime;
		}
	}
}

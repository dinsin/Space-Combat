/* ChickenFight
 * Author: Kevin Zeng, Dinesh Singh, Jon Wu */
using UnityEngine;
using System.Collections;

public class PlayerScreenWrap : MonoBehaviour {
	
	ParticleSystem ps;
	public TrailRenderer playerTrail;
	float changeOffset = 0.015f;
	public float changeOffsetMultipler = 1;

	void Start()
	{
		ps = GetComponent<ParticleSystem>();
	}

	void Update() {

		bool willTeleport = false;
		
		Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

		if (viewportPosition.x < -changeOffset * changeOffsetMultipler)
		{
			AttemptPause();
			viewportPosition.x = 1 + changeOffset * changeOffsetMultipler + viewportPosition.x;
			willTeleport = true;
		}
		else if (viewportPosition.x > 1 + changeOffset * changeOffsetMultipler)
		{
			AttemptPause();
			viewportPosition.x = -changeOffset * changeOffsetMultipler - (1 - viewportPosition.x);
			willTeleport = true;
		}

		if (viewportPosition.y < -changeOffset * changeOffsetMultipler)
		{
			AttemptPause();
			viewportPosition.y = 1 + changeOffset * changeOffsetMultipler + viewportPosition.y;
			willTeleport = true;
		} else if (viewportPosition.y > 1 + changeOffset * changeOffsetMultipler)
		{
			AttemptPause();
			viewportPosition.y = -changeOffset * changeOffsetMultipler - (1 - viewportPosition.y);
			willTeleport = true;
		}

		if (willTeleport){
			float tempTime = playerTrail.time;
			playerTrail.time = 0;
			transform.position = Camera.main.ViewportToWorldPoint(viewportPosition);
			StartCoroutine (ResetTrailDist ());
			playerTrail.time = tempTime;
		}
		else{
			transform.position = Camera.main.ViewportToWorldPoint(viewportPosition);
		}

		if (ps && ps.isPaused) {
			ps.Play ();
		}
	}

	void AttemptPause()	{	
		if (ps) {
			ps.Pause ();
		}
	}

	IEnumerator ResetTrailDist(){
		yield return new WaitForSeconds(.5f);
	}

}
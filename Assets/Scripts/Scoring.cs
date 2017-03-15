using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

	public GameObject player;
	string playerName;
	float health;

	// Use this for initialization
	void Start () {
		playerName = player.name;
	}
	
	// Update is called once per frame
	void Update () {
		string textBuffer = "";
		if (player != null){
			health = player.GetComponent<Damageable> ().remainingHealth;
			textBuffer += playerName + ": " + health;
			GetComponent<Text>().text = textBuffer;
		}
	}
}

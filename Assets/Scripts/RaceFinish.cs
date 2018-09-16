using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceFinish : MonoBehaviour {

	public GameObject MyCar;
	public GameObject FinishCam;
	public GameObject ViewModes;
	public GameObject LevelMusic;
	public GameObject CompleteTrig;
	public AudioSource FinishMusic;
	public static float currentSpeed;

	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == "playerCar"){
			this.GetComponent<BoxCollider> ().enabled = false;
			MyCar.SetActive (false);
			CompleteTrig.SetActive (false);
			currentSpeed = 0.0f;
			MyCar.GetComponent<MovementControls> ().enabled = false;
			MyCar.SetActive (true);
			FinishCam.SetActive (true);
			LevelMusic.SetActive (false);
			ViewModes.SetActive (false);
			FinishMusic.Play ();
		}
	}
}

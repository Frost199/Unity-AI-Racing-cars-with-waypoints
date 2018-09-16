using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
	
	public GameObject countDown;
	public AudioSource GetReady;
	public AudioSource GoAudio;
	public GameObject LapTimer;
	public GameObject[] CarControls;
	public AudioSource musicBackground;

	void Awake(){
		LapTimer.SetActive(false);
		StartCoroutine (CountStart ());
		for(int i = 0; i < CarControls.Length; i++){
			CarControls[i].SetActive (false);
		}
	}

	void Start () {		
	}


	IEnumerator CountStart () {
		yield return new WaitForSeconds (0.5f);
		countDown.GetComponent<Text> ().text = "3";
		GetReady.Play ();
		countDown.SetActive (true);
		LapTimer.SetActive (false);
		yield return new WaitForSeconds (1);
		countDown.SetActive (false);
		countDown.GetComponent<Text> ().text = "2";
		GetReady.Play ();
		countDown.SetActive (true);
		yield return new WaitForSeconds (1);
		countDown.SetActive (false);
		countDown.GetComponent<Text> ().text = "1";
		GetReady.Play ();
		countDown.SetActive (true);
		yield return new WaitForSeconds (1);
		countDown.SetActive (false);
		GoAudio.Play ();
		musicBackground.Play();
		LapTimer.SetActive (true);
		LapTimeManager.MinuteCount = 0;
		LapTimeManager.SecondCount = 0;
		LapTimeManager.MilliCount = 0;
		LapTimeManager.rawTime = 0;
		for(int i = 0; i < CarControls.Length; i++){
			CarControls[i].SetActive (true);
		}

	}
}

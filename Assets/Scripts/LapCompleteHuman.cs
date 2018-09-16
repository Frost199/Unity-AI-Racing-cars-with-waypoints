using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCompleteHuman : MonoBehaviour {

	public GameObject firstLapMinuteDisplay;
	public GameObject firstLapSecondDisplay;
	public GameObject firstLapMilliDisplay;

	public GameObject LapCounter;
	public GameObject raceEndedPanel;

	public static int lapdone_Human = 0;

	public float rawTimeCheck;
	public int mins;
	public int secs;
	public float millis;
	public LapCOmpleteAI1 lapCOmpleteforAI1;
	public LapCompleteAI2 lapCompleteforAI2;
	public LapCompleteAI3 lapCompleteforAI3;

	public static int AI1Tracker;
	public static int AI2Tracker;
	public static int AI3Tracker;

	public GameObject MyCar;
	public GameObject FinishCam;
	public GameObject ViewModes;
	public GameObject LevelMusic;
	//public GameObject CompleteTrig;
	public AudioSource FinishMusic;
	public static float currentSpeed;
	public GameObject TimeManager;
	public GameObject halfLineTrigger;
	public GameObject[] lapCompleteAiCars;

	void Start(){
		lapCOmpleteforAI1 = GameObject.FindObjectOfType<LapCOmpleteAI1>() as LapCOmpleteAI1;
		lapCompleteforAI2 = GameObject.FindObjectOfType<LapCompleteAI2>() as LapCompleteAI2;
		lapCompleteforAI3 = GameObject.FindObjectOfType<LapCompleteAI3>() as LapCompleteAI3;
	}
	void Update(){
		lapCOmpleteforAI1 = GameObject.FindObjectOfType<LapCOmpleteAI1>() as LapCOmpleteAI1;
		lapCompleteforAI2 = GameObject.FindObjectOfType<LapCompleteAI2>() as LapCompleteAI2;
		lapCompleteforAI3 = GameObject.FindObjectOfType<LapCompleteAI3>() as LapCompleteAI3;
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "playerCar"){

			mins = LapTimeManager.MinuteCount;
			secs = LapTimeManager.SecondCount;
			millis = LapTimeManager.MilliCount;

			rawTimeCheck = LapTimeManager.rawTime;
			lapdone_Human += 1;

			if(lapdone_Human == 1){
				FirstLapFinishTImePopulated();
				raceEndedPanel.SetActive(true);
				LapCounter.GetComponent<Text> ().text = "" + lapdone_Human;
				if(AI1Tracker != 3){
					lapCOmpleteforAI1.LapFinishTImePopulatedAI1BeforeCheckpoint();
				}
				if(AI2Tracker != 5){
					lapCompleteforAI2.LapFinishTImePopulatedAI2BeforeCheckpoint();
				}
				if(AI3Tracker != 7){
					lapCompleteforAI3.LapFinishTImePopulatedAI3BeforeCheckpoint();
				}


				MyCar.SetActive (false);
				//CompleteTrig.SetActive (false);
				currentSpeed = 0.0f;
				MyCar.GetComponent<MovementControls> ().enabled = false;
				MyCar.GetComponent<AudioSource> ().enabled = false;
				MyCar.SetActive (true);
				FinishCam.SetActive (true);
				LevelMusic.SetActive (false);
				ViewModes.SetActive (false);
				FinishMusic.Play ();
				TimeManager.SetActive(false);
				for(int i = 0; i < lapCompleteAiCars.Length; i++){
					lapCompleteAiCars[i].SetActive(false);
				}
				halfLineTrigger.SetActive(false);
				//Time.timeScale = 0;

			}
				
		}
	}

	public void FirstLapFinishTImePopulated(){
		if (secs <= 9) {
			firstLapSecondDisplay.GetComponent<Text> ().text = "0" + secs + ".";
		} else {
			firstLapSecondDisplay.GetComponent<Text> ().text = "" + secs + ".";
		}

		if (mins <= 9) {
			firstLapMinuteDisplay.GetComponent<Text> ().text = "0" + mins + "\"";
		} else {
			firstLapMinuteDisplay.GetComponent<Text> ().text = "" + mins + "\"";
		}

		firstLapMilliDisplay.GetComponent<Text> ().text = "" + millis;
	}

}

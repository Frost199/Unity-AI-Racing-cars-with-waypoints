using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {

	public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;

	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;

	public GameObject firstLapMinuteDisplay;
	public GameObject firstLapSecondDisplay;
	public GameObject firstLapMilliDisplay;

	public GameObject secondLapMinuteDisplay;
	public GameObject secondLapSecondDisplay;
	public GameObject secondLapMilliDisplay;

	public GameObject thirdLapMinuteDisplay;
	public GameObject thirdLapSecondDisplay;
	public GameObject thirdLapMilliDisplay;

	public GameObject LapTimeBox;
	public GameObject LapCounter;
	public GameObject raceEndedPanel;

	public static int lapdone_Human = 1;
	public static int lapdone_AI1 = 1;
	public static int lapdone_AI2 = 1;
	public static int lapdone_AI3 = 1;


	public int finalLapInt = 3;
	public float rawTimeCheck;
	public int mins;
	public int secs;
	public float millis;

	public GameObject MyCar;
	public GameObject FinishCam;
	public GameObject ViewModes;
	public GameObject LevelMusic;

	public AudioSource FinishMusic;
	public static float currentSpeed;
	public GameObject TimeManager;
	public GameObject halfLineTrigger;

	void OnTriggerEnter(Collider other){
		
		if(other.gameObject.tag == "playerCar"){
			
			mins = LapTimeManager.MinuteCount;
			secs = LapTimeManager.SecondCount;
			millis = LapTimeManager.MilliCount;

			rawTimeCheck = PlayerPrefs.GetFloat("RawTime");
			lapdone_Human += 1;
			if(LapTimeManager.rawTime <= rawTimeCheck){
				LapFinishTImePopulated();
			}
			PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
			PlayerPrefs.SetInt("SecSave", LapTimeManager.SecondCount);
			PlayerPrefs.SetFloat("MilliSave", LapTimeManager.MilliCount);
			PlayerPrefs.SetFloat("RawTime", LapTimeManager.rawTime);

			/*LapTimeManager.MinuteCount = 0;
			LapTimeManager.SecondCount = 0;
			LapTimeManager.MilliCount = 0;
			LapTimeManager.rawTime = 0;*/

			if(lapdone_Human == 2){
				FirstLapFinishTImePopulated();
				LapCounter.GetComponent<Text> ().text = "" + lapdone_Human;
				PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
				PlayerPrefs.SetInt("SecSave", LapTimeManager.SecondCount);
				PlayerPrefs.SetFloat("MilliSave", LapTimeManager.MilliCount);
				PlayerPrefs.SetFloat("RawTime", LapTimeManager.rawTime);

			}else if(lapdone_Human == 3){
				SecondLapFinishTImePopulated();
				LapCounter.GetComponent<Text> ().text = "" + lapdone_Human;
				PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
				PlayerPrefs.SetInt("SecSave", LapTimeManager.SecondCount);
				PlayerPrefs.SetFloat("MilliSave", LapTimeManager.MilliCount);
				PlayerPrefs.SetFloat("RawTime", LapTimeManager.rawTime);

			}else if(lapdone_Human >= 4){ //finishing the race
				raceEndedPanel.SetActive(true);
				ThirdLapFinishTImePopulated();
				LapCounter.GetComponent<Text>().text = "" + finalLapInt;
				PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
				PlayerPrefs.SetInt("SecSave", LapTimeManager.SecondCount);
				PlayerPrefs.SetFloat("MilliSave", LapTimeManager.MilliCount);
				PlayerPrefs.SetFloat("RawTime", LapTimeManager.rawTime);
				mins = 0;
				secs = 0;
				millis = 0f;

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
				//Time.timeScale = 0;
			}

			PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
			PlayerPrefs.SetInt("SecSave", LapTimeManager.SecondCount);
			PlayerPrefs.SetFloat("MilliSave", LapTimeManager.MilliCount);
			PlayerPrefs.SetFloat("RawTime", LapTimeManager.rawTime);

		
			HalfLapTrig.SetActive (true);
			LapCompleteTrig.SetActive (false);
			LapTimeManager.MinuteCount = 0;
			LapTimeManager.SecondCount = 0;
			LapTimeManager.MilliCount = 0;
			LapTimeManager.rawTime = 0;}
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

	public void SecondLapFinishTImePopulated(){
		if (secs <= 9) {
			secondLapSecondDisplay.GetComponent<Text> ().text = "0" + secs + ".";
		} else {													  
			secondLapSecondDisplay.GetComponent<Text> ().text = "" + secs + ".";
		}

		if (mins <= 9) {
			secondLapMinuteDisplay.GetComponent<Text> ().text = "0" + mins + "\"";
		} else {
			secondLapMinuteDisplay.GetComponent<Text> ().text = "" + mins + "\"";
		}

		secondLapMilliDisplay.GetComponent<Text> ().text = "" + millis;
	}

	public void ThirdLapFinishTImePopulated(){
		if (secs <= 9) {
			thirdLapSecondDisplay.GetComponent<Text> ().text = "0" + secs + ".";
		} else {
			thirdLapSecondDisplay.GetComponent<Text> ().text = "" + secs + ".";
		}

		if (mins <= 9) {
			thirdLapMinuteDisplay.GetComponent<Text> ().text = "0" + mins + "\"";
		} else {
			thirdLapMinuteDisplay.GetComponent<Text> ().text = "" + mins + "\"";
		}

		thirdLapMilliDisplay.GetComponent<Text> ().text = "" + millis;
	}

	public void LapFinishTImePopulated(){
		if (LapTimeManager.SecondCount <= 9) {
			SecondDisplay.GetComponent<Text> ().text = "0" + LapTimeManager.SecondCount + ".";
		} else {
			SecondDisplay.GetComponent<Text> ().text = "" + LapTimeManager.SecondCount + ".";
		}

		if (LapTimeManager.MinuteCount <= 9) {
			MinuteDisplay.GetComponent<Text> ().text = "0" + LapTimeManager.MinuteCount + "\"";
		} else {
			MinuteDisplay.GetComponent<Text> ().text = "" + LapTimeManager.MinuteCount + "\"";
		}

		MilliDisplay.GetComponent<Text> ().text = "" + LapTimeManager.MilliCount;
	}
}

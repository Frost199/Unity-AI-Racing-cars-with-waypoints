using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCompleteAI3 : MonoBehaviour {
	
	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;

	public static int tracker_3 = 6;

	public int mins;
	public int secs;
	public float millis;
	public float rawTimeAi3Finished;

	public int MinuteCount;
	public int SecondCount;
	public float MilliCount;
	public float timeExhausted;
	public float MinuteCountExhausted;

	void Update(){

		LapCompleteHuman.AI3Tracker = tracker_3;
		MilliCount += Time.deltaTime * 10;
		if (MilliCount >= 10) {
			MilliCount = 0;
			SecondCount += 1;
		}
		if (SecondCount >= 60) {
			SecondCount = 0;
			MinuteCount += 1;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "AI3"){
			rawTimeAi3Finished = LapTimeManager.rawTime;
			tracker_3 ++;
			mins = LapTimeManager.MinuteCount;
			secs = LapTimeManager.SecondCount;
			millis = LapTimeManager.MilliCount;

			if(tracker_3 == 7){
				LapFinishTImePopulatedAI3();
			}
			Debug.Log("Ai3 just passed");
		}
	}

	public void LapFinishTImePopulatedAI3(){
		if (secs <= 9) {
			SecondDisplay.GetComponent<Text> ().text = "0" + secs + ".";
		} else {
			SecondDisplay.GetComponent<Text> ().text = "" + secs + ".";
		}

		if (mins <= 9) {
			MinuteDisplay.GetComponent<Text> ().text = "0" + mins + "\"";
		} else {
			MinuteDisplay.GetComponent<Text> ().text = "" + mins + "\"";
		}

		MilliDisplay.GetComponent<Text> ().text = "" + millis;
	}

	public void LapFinishTImePopulatedAI3BeforeCheckpoint(){

		timeExhausted = Random.Range(80.11f, 90.05f);
		MinuteCountExhausted = Mathf.Round(timeExhausted/60);
		System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(timeExhausted);

		SecondDisplay.GetComponent<Text> ().text = string.Format("{0:00}", timeSpan.Seconds) + ".";
		MilliDisplay.GetComponent<Text> ().text = string.Format("{0:00}", timeSpan.Milliseconds);
		MinuteDisplay.GetComponent<Text> ().text = string.Format("{0:00}", timeSpan.Minutes) + "\"";

		/*if (SecondCount <= 9) {
			SecondDisplay.GetComponent<Text> ().text = "0" + SecondCount + ".";
		} else {
			SecondDisplay.GetComponent<Text> ().text = "" + SecondCount + ".";
		}

		if (MinuteCount <= 9) {
			MinuteDisplay.GetComponent<Text> ().text = "0" + MinuteCount + "\"";
		} else {
			MinuteDisplay.GetComponent<Text> ().text = "" + MinuteCount + "\"";
		}

		MilliDisplay.GetComponent<Text> ().text = "" + MilliCount;*/
	}
}

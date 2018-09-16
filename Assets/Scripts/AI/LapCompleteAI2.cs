using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCompleteAI2 : MonoBehaviour {


	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;

	public static int tracker_2 = 4;
	public static int tracker_2_clone;

	public int mins;
	public int secs;
	public float millis;
	public float rawTimeAi2Finished;

	public int MinuteCount;
	public int SecondCount;
	public float MilliCount;
	public float timeExhausted;
	public float MinuteCountExhausted;

	void OnTriggerEnter(Collider other){
		string otherTag = other.gameObject.tag;
		if(otherTag == "AI2"){
			rawTimeAi2Finished = LapTimeManager.rawTime;
			tracker_2 ++;
			mins = LapTimeManager.MinuteCount;
			secs = LapTimeManager.SecondCount;
			millis = LapTimeManager.MilliCount;

			if(tracker_2 == 5){
				LapFinishTImePopulatedAI2();
			}
			Debug.Log("Ai2 just passed");
		}
		else{
			return;
		}
	}

	void Update(){
		LapCompleteHuman.AI2Tracker = tracker_2;
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

	public void LapFinishTImePopulatedAI2(){
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

	public void LapFinishTImePopulatedAI2BeforeCheckpoint(){
		timeExhausted = Random.Range(82.36f, 91.46f);
		MinuteCountExhausted = Mathf.Round(timeExhausted/60);
		System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(timeExhausted);

		SecondDisplay.GetComponent<Text> ().text = string.Format("{0:00}", timeSpan.Seconds) + ".";
		MilliDisplay.GetComponent<Text> ().text = string.Format("{0:00}", timeSpan.Milliseconds);
		MinuteDisplay.GetComponent<Text> ().text = string.Format("{0:00}", timeSpan.Minutes) + "\"";

		/*if (MilliCount >= 10) {
			MilliCount = 0;
			SecondCount += 1;
		}
		if (SecondCount >= 60) {
			SecondCount = 0;
			MinuteCount += 1;
		}
		if (LapTimeManager.SecondCount <= 9) {
			SecondDisplay.GetComponent<Text> ().text = "0" + SecondCount + ".";
		} else {
			SecondDisplay.GetComponent<Text> ().text = "" + SecondCount + ".";
		}

		if (LapTimeManager.MinuteCount <= 9) {
			MinuteDisplay.GetComponent<Text> ().text = "0" + MinuteCount + "\"";
		} else {
			MinuteDisplay.GetComponent<Text> ().text = "" + MinuteCount + "\"";
		}

		MilliDisplay.GetComponent<Text> ().text = "" + MilliCount;*/
	}
}

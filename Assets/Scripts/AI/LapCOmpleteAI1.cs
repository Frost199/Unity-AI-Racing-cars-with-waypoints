using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCOmpleteAI1 : MonoBehaviour {

	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;

	public static int tracker = 2;

	public int mins;
	public int secs;
	public float millis;
	public float rawTimeAiFinished;

	public int MinuteCount;
	public int SecondCount;
	public float MilliCount;
	public float timeExhausted;
	public float MinuteCountExhausted;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "AI1"){
			rawTimeAiFinished = LapTimeManager.rawTime;
			tracker ++;
			mins = LapTimeManager.MinuteCount;
			secs = LapTimeManager.SecondCount;
			millis = LapTimeManager.MilliCount;

			if(tracker == 3){
				LapFinishTImePopulated();
			}
			Debug.Log("AI1 just passed");
				
		}
	}

	void Update(){
		LapCompleteHuman.AI1Tracker = tracker;
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
		
	public void LapFinishTImePopulated(){
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

	public void LapFinishTImePopulatedAI1BeforeCheckpoint(){
		timeExhausted = Random.Range(84.26f, 94.26f);
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

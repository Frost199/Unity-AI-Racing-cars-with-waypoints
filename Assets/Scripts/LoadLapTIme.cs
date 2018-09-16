using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLapTIme : MonoBehaviour {

	//Public Varaibles
	public int minCount;
	public int secCount;
	public float milliCount;
	public GameObject minDisplay;
	public GameObject secDisplay;
	public GameObject milliDisplay;

	// Use this for initialization
	void Start () {
		minCount = PlayerPrefs.GetInt("MinSave");
		secCount = PlayerPrefs.GetInt("SecSave");
		milliCount = PlayerPrefs.GetInt("MilliSave");

		if (secCount <= 9) {
			secDisplay.GetComponent<Text> ().text = "0" + secCount + ".";
		} else {
			secDisplay.GetComponent<Text> ().text = "" + secCount + ".";
		}

		if (minCount <= 9) {
			minDisplay.GetComponent<Text> ().text = "0" + minCount + "\"";
		} else {
			minDisplay.GetComponent<Text> ().text = "" + minCount + "\"";
		}
		milliDisplay.GetComponent<Text>().text = "" + milliCount;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

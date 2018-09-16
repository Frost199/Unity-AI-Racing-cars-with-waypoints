using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMode : MonoBehaviour {

	//public variables
	public GameObject normalCam;
	public GameObject farCam;
	public GameObject fpCam;
	public GameObject fartherCam;
	public int camMode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void camSwitch(){
		if(camMode == 3){
			camMode = 0;
		}else{
			camMode += 1;
		}
		StartCoroutine(ModeChange());
	}

	IEnumerator ModeChange(){
		yield return new WaitForSeconds(0.01f);
		if(camMode == 0){
			normalCam.SetActive(true);
			farCam.SetActive(false);
			fpCam.SetActive(false);
			fartherCam.SetActive(false);
		}
		if(camMode == 1){
			normalCam.SetActive(false);
			farCam.SetActive(true);
			fpCam.SetActive(false);
			fartherCam.SetActive(false);
		}
		if(camMode == 2){
			normalCam.SetActive(false);
			farCam.SetActive(false);
			fartherCam.SetActive(false);
			fpCam.SetActive(true);
		}
		if(camMode == 3){
			normalCam.SetActive(false);
			farCam.SetActive(false);
			fpCam.SetActive(false);
			fartherCam.SetActive(true);
		}
	}
}

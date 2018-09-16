using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "playerCar"){
			Debug.Log("Car Entered");
		}else if(other.gameObject.tag == "AI_1"){
			Debug.Log("Sphere Entered");
		}
	}
}

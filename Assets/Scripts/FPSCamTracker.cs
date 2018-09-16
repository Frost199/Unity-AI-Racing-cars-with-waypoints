using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamTracker : MonoBehaviour {
	//public Variables
	public GameObject theCar;
	public float carX;
	public float carY;
	public float carZ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		carX = theCar.transform.eulerAngles.x;
		carY = theCar.transform.eulerAngles.y;
		carZ = theCar.transform.eulerAngles.z;

		transform.eulerAngles = new Vector3(carX - carX, carY, carZ - carZ);
	}
}

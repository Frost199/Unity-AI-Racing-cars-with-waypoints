using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mappingWheelColliders : MonoBehaviour {

	//public variables
	public WheelCollider wc;

	//private Variables
	Vector3 wcCenter;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		wcCenter = wc.transform.TransformPoint(wc.center);
		if(Physics.Raycast(wcCenter, -wc.transform.up, out hit, wc.suspensionDistance + wc.radius)){
			transform.position = hit.point + (wc.transform.up * wc.radius);
		}else{
			transform.position = wcCenter - (wc.transform.up * wc.suspensionDistance);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastWaypoint : MonoBehaviour {

	public static int currentLap = 1;
	public  int LapMAx = 4;
	public static Transform lastWaypoint;
	public static int currentWayPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetIndividualLap.lapdone = currentLap;
		Debug.Log(currentWayPoint);
	}
	public void OnTriggerEnter(Collider other) {
		string otherTag = other.gameObject.tag;
		if(otherTag == "1" || otherTag == "2" ||otherTag == "3" || otherTag == "4" || otherTag == "5" || otherTag == "6" || otherTag == "7"){
			currentWayPoint = System.Convert.ToInt32(otherTag);
			Debug.Log("Trigger Selected waypoint" + currentWayPoint);
		}else{
			return;
		}
		//currentWayPoint = System.Convert.ToInt32(otherTag);
		if (currentWayPoint == 1){ // completed a lap, so increase currentLap;
			currentLap += 1;
			/*if(currentLap == LapMAx){//completed all laps
				currentLap = LapMAx;
			}*/
		}
		lastWaypoint = other.transform;
	}
}

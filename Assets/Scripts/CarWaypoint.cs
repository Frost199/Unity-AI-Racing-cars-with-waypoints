using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWaypoint : MonoBehaviour {

	public int currentWaypoint;
	public int currentLap;
	public Transform lastWaypoint;

	private static int WAYPOINT_VALUE = 5;
	private static int LAP_VALUE = 3;

	void Update(){
		currentLap = LastWaypoint.currentLap;
		lastWaypoint = LastWaypoint.lastWaypoint;
		currentWaypoint = LastWaypoint.currentWayPoint;
	}
	// Use this for initialization
	public void Initialize() {
		currentWaypoint = 0;
		currentLap = 0;
	}

	public float GetDistance() {
		return (transform.position - lastWaypoint.position).magnitude + currentWaypoint * WAYPOINT_VALUE + currentLap * LAP_VALUE;
	}

	public int GetCarPosition(CarWaypoint[] allCars) {
		float distance = GetDistance();
		int position = 1;
		foreach (CarWaypoint car in allCars) {
			if (car.GetDistance() > distance)
				position++;
		}
		return position;
	}
}

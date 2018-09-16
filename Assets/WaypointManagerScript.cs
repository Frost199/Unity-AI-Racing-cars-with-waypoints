using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManagerScript : MonoBehaviour {

	public GameObject[] carObjects;
	public CarWaypoint[] allCars;
	public CarWaypoint[] carOrder;

	public void Start() {
		// set up the car objects
		allCars = new CarWaypoint[carObjects.Length];
		carOrder = new CarWaypoint[carObjects.Length];
		for (int i = 0; i < carObjects.Length; i++) {
			allCars[i] = carObjects[i].GetComponent<CarWaypoint>();
		}
	}

	// this gets called every frame
	public void update() {
		foreach (CarWaypoint car in allCars) {
			carOrder[car.GetCarPosition(allCars) - 1] = car;
		}
	}
}

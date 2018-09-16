using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 10f;
    public Vector3 offset;

	// Update is called once per frame
	void FixedUpdate () {

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothenedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothenedPosition;

		transform.rotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f);

	}
}

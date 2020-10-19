using UnityEngine;
using System.Collections;

public class Hammer : MonoBehaviour {

	private Vector3 initialPosition;

	void Start () {
		initialPosition = transform.position;
	}

	public void Hit (Vector3 targetPosition) {
       
		transform.position = targetPosition;
	}

	void Update () {
		transform.position = Vector3.Lerp (transform.position, initialPosition, Time.deltaTime);
	}
}

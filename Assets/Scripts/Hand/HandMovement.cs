using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class HandMovement : MonoBehaviour
{

	public Transform StartingPosition;
	public Transform EndingPosition;
	private float PercentDistance;
	public float timeToTravel;
	public FloatData Timer;
	
	
	// Use this for initialization
	private void OnEnable()
	{
		transform.position = StartingPosition.position;
		// activate the warning sprites
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.Lerp(StartingPosition.position, EndingPosition.position, PercentDistance);			// actual movement of the object
		PercentDistance += ((1 / timeToTravel) * Time.deltaTime); 														// this makes the object move the total distance over the period of time set
		
	}
}

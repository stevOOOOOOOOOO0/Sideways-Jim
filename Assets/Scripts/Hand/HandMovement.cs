using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.WSA;

public class HandMovement : MonoBehaviour
{

	public Transform StartingPosition;
	public Transform EndingPosition;
	private float PercentDistance;
	public float timeToTravel;
	public float WaitTime;
	private bool startMoving;
	private float PercentDistance2;
	
	// Use this for initialization
	private void OnEnable()
	{
		transform.position = StartingPosition.position;
		startMoving = false;
		PercentDistance = 0;
		PercentDistance2 = .01f;
		StartCoroutine(OnEnableCoroutine(WaitTime));
	}

	private void Update()
	{
		if (startMoving)
		{
			transform.position = Vector3.Lerp(StartingPosition.position, EndingPosition.position, PercentDistance); 	// actual movement of the object downward
			PercentDistance += ((1 / timeToTravel) * Time.deltaTime);
		}

		if (PercentDistance > 1)
		{
			transform.position = Vector3.Lerp(EndingPosition.position, EndingPosition.right * -30, PercentDistance2); 	// actual movement of the object to the left
			PercentDistance2 += PercentDistance2 / 10;

		}
	}

	private IEnumerator OnEnableCoroutine( float Time)
	{
		yield return new WaitForSeconds(Time);
		startMoving = true;
	}
}

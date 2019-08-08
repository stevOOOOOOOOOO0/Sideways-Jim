using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehavior : MonoBehaviour {

	public Transform FollowThis;
	private Vector3 updatePosition;
	public float Offset;
	public float Smoothspeed;
	
	// Update is called once per frame
	void Update ()
	{
		updatePosition.Set(transform.position.x, FollowThis.position.y + Offset, 2.9f);
		transform.position = Vector3.Lerp(transform.position, updatePosition, Smoothspeed);
	}
}

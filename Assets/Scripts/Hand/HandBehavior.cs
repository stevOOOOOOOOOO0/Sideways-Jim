using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehavior : MonoBehaviour {

	public Transform FollowThis;
	public Transform Follower;
	private Transform positionUpdater;
	
	// Update is called once per frame
	void Update () {
		positionUpdater.position = FollowThis.position;
		positionUpdater.position.Set(0, positionUpdater.position.y, 0);
		Follower.position = positionUpdater.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBack : MonoBehaviour {

	public float OffsetValue;
	private float offsetUsed;
	public float Time;
	public float SecondWait;
	private Vector3 updatePosition;
	private Vector3 originalPosition;

	// Use this for initialization
	private IEnumerator Start () {
		originalPosition = transform.position;
		yield return new WaitForSeconds(10);
		while (true)
		{
			offsetUsed = OffsetValue;
			yield return new WaitForSeconds(Time);
			offsetUsed = 0;
			yield return new WaitForSeconds(SecondWait);
		}
	}
	
	// Update is called once per frame
	void Update () {
		updatePosition.Set(originalPosition.x + offsetUsed, originalPosition.y, originalPosition.z);
		transform.position = Vector3.Lerp(transform.position, updatePosition, .05f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningInitiation : MonoBehaviour
{

	public float TimeActive;
	private float TimeActiveRemember;
	public float XMin;
	public float XMax;
	public float YMin;
	public float YMax;
	
	// Use this for initialization
	void OnEnable ()
	{
		transform.position.Set(Random.Range(XMin, XMax), Random.Range(YMin, YMax), 0);				// give the sprite a random location within the range
		TimeActiveRemember = TimeActive;
	}
	
	// Update is called once per frame
	void Update ()
	{
		TimeActive -= 1 * Time.deltaTime;
		if (TimeActive <= 0)
		{
			TimeActive = TimeActiveRemember;
			gameObject.SetActive(false);
		}
	}
}

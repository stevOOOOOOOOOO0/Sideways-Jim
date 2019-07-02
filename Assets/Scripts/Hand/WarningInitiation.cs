using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningInitiation : MonoBehaviour
{

	public float TimeActive;
	public float XMin;
	public float XMax;
	public float YMin;
	public float YMax;
	
	// Use this for initialization
	void OnEnable ()
	{
		transform.position.Set(Random.Range(XMin, XMax), Random.Range(YMin, YMax), 0);
		StartCoroutine(OnEnableCoroutine());
	}

	private IEnumerator OnEnableCoroutine()
	{
		yield return new WaitForSeconds(TimeActive);
		gameObject.SetActive(false);
	}
}

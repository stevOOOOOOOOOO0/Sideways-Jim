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
		transform.position = new Vector3(Random.Range(XMin, XMax), Random.Range(YMin, YMax), 2.9f);
		Debug.Log("position: " + transform.position);
		StartCoroutine(OnEnableCoroutine());
	}

	private IEnumerator OnEnableCoroutine()
	{
		yield return new WaitForSeconds(TimeActive);
		gameObject.SetActive(false);
	}
}

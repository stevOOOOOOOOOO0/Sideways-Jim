using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour
{

	public GameObject Restart;
	
	public void OnTriggerEnter(Collider other)
	{
		Debug.Log("collision detected");
		if (other.gameObject.tag == "Hand")
		{
			Restart.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}

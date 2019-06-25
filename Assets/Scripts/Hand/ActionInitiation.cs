using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ActionInitiation : MonoBehaviour
{

	public FloatData Time;
	private int randNumber;
	public ListData Objects;
	
	// Use this for initialization
	void Start ()
	{
		Time.Value = -7;
		Time.Timer = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.Value >= 3)
		{
			randNumber = Random.Range(0, (Objects.Value.Count - 1));		//Create New Hand choosing between four options
			Objects.Value[randNumber].SetActive(true);
		}
	}
}

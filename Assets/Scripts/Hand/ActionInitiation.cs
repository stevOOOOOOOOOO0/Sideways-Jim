using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ActionInitiation : MonoBehaviour
{

	public FloatData TimeValue;
	private int randNumber;
	public ListData Objects;
	
	// Use this for initialization
	void Start ()
	{
		TimeValue.Value = -7;
		TimeValue.Timer = true;
		for(int i = 0; i < (Objects.Value.Count); i++)
		{
			Instantiate(Objects.Value[i]);
			Objects.Value[i].SetActive(false);
			Debug.Log("is it active? - " + Objects.Value[i].activeInHierarchy);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (TimeValue.Timer)
			TimeValue.Value += 1 * Time.deltaTime;
	
		if (TimeValue.Value >= 3 && TimeValue.Timer)
		{
			randNumber = Random.Range(0, (Objects.Value.Count - 1));		//Create New Hand choosing between four options
			Debug.Log("in i now equals: " + randNumber);
			Objects.Value[randNumber].SetActive(true);
			Debug.Log("is it active? - " + Objects.Value[randNumber].activeInHierarchy);
			TimeValue.Timer = false;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ActionInitiation : MonoBehaviour
{

	public FloatData TimeValue;
	public ListData Objects;
	public List<GameObject> newObjects;

	private IEnumerator Start ()
	{
		TimeValue.Value = -7;
		TimeValue.Timer = true;

		foreach (var obj in Objects.Value)
		{
			var newObj = Instantiate(obj);
			newObjects.Add(newObj as GameObject);
			obj.SetActive(false);
		}
		
		yield return new WaitForSeconds(10);
		
		while (true)
		{
			var i = Random.Range(0, (newObjects.Count));															
			Debug.Log(i);
			newObjects[i].SetActive(true);
			TimeValue.Timer = false;
			yield return new WaitForSeconds(6);
		}
	}

	private void Reset()
	{
		for(var i = 0; i < (newObjects.Count); i++)
		{
			newObjects[i].SetActive(false);
		}
	}
}
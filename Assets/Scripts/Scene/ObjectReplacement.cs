using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class ObjectReplacement : MonoBehaviour {

	public FloatData ItemSpeed;
	public ListData ObjectList;
	public Transform StartingPosition;
	public float DistanceBetween;
	public float ChanceToActivate;
	private float OGChanceToActivate;
	public int i = 0;
	public GameObject Populator;
	public Vector3 StorageLocation;
	
    
																			// Start is called before the first frame update
	void Start()
	{
		ItemSpeed.Value = 5f;
		ObjectList.Value.Clear();
		OGChanceToActivate = ChanceToActivate;
		for (int j = 0; j < 5; j++)
		{
			ObjectList.Value.Add(Instantiate(Populator, StorageLocation, StartingPosition.rotation));
			ObjectList.Value[j].SetActive(false);
		}
		ObjectList.Value[i].transform.position = StartingPosition.position;
		ObjectList.Value[i].SetActive(true);
	}

																			// Update is called once per frame
	void LateUpdate()
	{
		if ((StartingPosition.position.x - ObjectList.Value[i].transform.position.x) > DistanceBetween)
		{
			if (Random.Range(0, 100) < ChanceToActivate) 					//runs the chances that a new creature is placed
			{
				Debug.Log("in the Activation Script");
				i++; 														// i is changed to the next deactivated piece
				if (i >= ObjectList.Value.Count)							// if i is out of scope it switches back to zero
					i = 0;
				ObjectList.Value[i].SetActive(true);						// object is set to active
				ObjectList.Value[i].transform.SetPositionAndRotation(StartingPosition.position, StartingPosition.rotation); //create Creature
				ChanceToActivate = OGChanceToActivate;
			}
			else 															//falled the roll increase chances
			{
				ChanceToActivate += 20 * Time.deltaTime;
			}
		}
		if (ItemSpeed.Value < 20)
			ItemSpeed.Value += .5f * Time.deltaTime;
	}
}
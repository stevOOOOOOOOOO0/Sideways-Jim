using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Random = System.Random;

public class FloorReplacement : MonoBehaviour
{

    public FloatData FloorSpeed;
    public ListData Floor;
    public GameObject BasicFloor;
    public GameObject BlankFloor;
    public GameObject SpikeFloor;
    public Vector3 Offset;
    public Transform StartingPosition;
    private GameObject lastUsed;
    private int randFloor;
    
    // Start is called before the first frame update
    void Start()
    {
        FloorSpeed.Value = 5f;
        Floor.Value.Clear();
        StartingPosition.position.Set(-20, 0, 0 );
        StartingPosition.rotation.Set(0, 0, 0, 0);
        Floor.Value.Add(Instantiate(BasicFloor, StartingPosition));
        for (int i = 0; i < 14; i++)
        {
            Floor.Value.Add(Instantiate(BasicFloor, Floor.Value[Floor.Value.Count - 1].transform.position + Offset,
                Floor.Value[Floor.Value.Count - 1].transform.rotation));
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Floor.Value[0].transform.position.x < -20)
        {
            Floor.Value.Add(Instantiate(ChooseGameObject(), Floor.Value[Floor.Value.Count - 1].transform.position + Offset,
                Floor.Value[Floor.Value.Count - 1].transform.rotation));
            Floor.Value.RemoveAt(0); // removes first element in the list and shifts everything down
        }
        if (FloorSpeed.Value < 20)
            FloorSpeed.Value += .5f * Time.deltaTime;
    }

    private  GameObject ChooseGameObject()
    {
        randFloor = UnityEngine.Random.Range(0, 4);
        switch (randFloor)
        {
            case 0:
                lastUsed = BasicFloor;
                break;
            case 1:
                lastUsed = BlankFloor;
                break;
            case 2:
                lastUsed = SpikeFloor;
                break;
            case 3:
                lastUsed = BasicFloor;
                break;
        }
        return lastUsed;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Random = System.Random;

public class FloorReplacement : MonoBehaviour
{

    public FloatData ItemSpeed;
    public ListData Floor;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public Vector3 Offset;
    public Transform StartingPosition;
    private GameObject lastUsed;
    private int randFloor;
    
    // Start is called before the first frame update
    void Start()
    {
        ItemSpeed.Value = 5f;
        Floor.Value.Clear();
        Floor.Value.Add(Instantiate(Item1, StartingPosition));
        for (int i = 0; i < 14; i++)
        {
            Floor.Value.Add(Instantiate(Item1, Floor.Value[Floor.Value.Count - 1].transform.position + Offset,
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
        if (ItemSpeed.Value < 20)
            ItemSpeed.Value += .5f * Time.deltaTime;
    }

    private  GameObject ChooseGameObject()
    {
        randFloor = UnityEngine.Random.Range(0, 4);
        switch (randFloor)
        {
            case 0:
                lastUsed = Item1;
                break;
            case 1:
                lastUsed = Item2;
                break;
            case 2:
                lastUsed = Item3;
                break;
            case 3:
                lastUsed = Item4;
                break;
        }
        return lastUsed;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class FloorReplacement : MonoBehaviour
{
    public float Speed;
    private Vector3 endPosition;
    public EventSystem FloorSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        Speed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        endPosition = transform.position;
        endPosition.x -= Speed;
        transform.position = Vector3.Lerp(transform.position, endPosition, 1 * Time.deltaTime);
        Speed += 1 * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Break")
        {
            FloorSpawner.Invoke();
            Destroy(gameObject);
        }
    }
}

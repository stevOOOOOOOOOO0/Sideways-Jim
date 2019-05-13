using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public float Speed;
    private Vector3 endPosition;

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
}

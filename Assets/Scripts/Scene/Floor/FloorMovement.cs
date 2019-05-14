using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public float Speed;
    private Vector3 endPosition;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        Speed = 6f;
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        endPosition = position;
        endPosition.x -= Speed;
        position = Vector3.Lerp(position, endPosition, 1 * Time.deltaTime);
        transform.position = position;
        Speed += 1 * Time.deltaTime;
    }
}

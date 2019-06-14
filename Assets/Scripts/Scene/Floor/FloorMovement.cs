using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FloorMovement : MonoBehaviour
{
    public FloatData FloorSpeed;
    private Vector3 endPosition;
    private Vector3 position;
    public float DeactivatePostition;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        endPosition = position;
        endPosition.x -= FloorSpeed.Value;
        position = Vector3.Lerp(position, endPosition, 1 * Time.deltaTime);
        transform.position = position;
        if (transform.position.x < DeactivatePostition)
            Destroy(gameObject);
    }
}

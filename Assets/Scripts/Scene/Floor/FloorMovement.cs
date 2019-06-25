using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FloorMovement : MonoBehaviour
{
    public FloatData FloorSpeed;
    private Vector3 endPosition;
    public float DeactivatePostition;

    // Update is called once per frame
    void Update()
    {
        endPosition = transform.position;
        endPosition.x -= FloorSpeed.Value;
        transform.position = Vector3.Lerp(transform.position, endPosition, 1 * Time.deltaTime);
        if (transform.position.x < DeactivatePostition)
            gameObject.SetActive(false);
    }
}

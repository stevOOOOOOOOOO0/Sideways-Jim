using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float Value;
    public bool Timer;

    void AddTime()
    {
        if (Timer == true)
            Value += 1 * Time.deltaTime;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float waitSeconds = 0;
    public float speedOut = 0;

    private float timer;
    public float timeToSpeedUp;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToSpeedUp)
        {
            speedOut = 3.0f + (Time.deltaTime * 500) ;
        }
    }
}

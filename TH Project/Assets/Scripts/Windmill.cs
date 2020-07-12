using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            transform.rotation = Quaternion.AngleAxis(10, Vector3.forward);
        if (Input.GetKeyUp(KeyCode.Space))
            transform.rotation = Quaternion.AngleAxis(20, Vector3.forward);
    }
}

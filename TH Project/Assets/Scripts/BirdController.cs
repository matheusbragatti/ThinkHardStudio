using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public bool gameOver;
    public bool gameWin;

    public float flapForce = 10;
    public float tiltSmooth = 5;
    public Vector3 startPos;
    Rigidbody2D rigidbody;
    Quaternion downRotation;
    Quaternion forwardRotation;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -60);
        forwardRotation = Quaternion.Euler(0, 0, 40);
        //rigidbody.simulated = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = forwardRotation;
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(Vector2.up * flapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "DeadZone")
        {
            rigidbody.simulated = false;
            gameOver = true;
        }

        if(col.gameObject.tag == "EndGoal")
        {
            gameWin = true;
        }
    }
}

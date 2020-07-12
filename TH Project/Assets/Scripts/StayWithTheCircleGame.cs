using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StayWithTheCircleGame : MonoBehaviour
{
    private float timer;
    private float timeLeft;
    private float timerOutside;

    public float timeLimit;
    public TextMeshProUGUI timerAmount;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!CountdownController.gameBegan) return;

        timer += Time.deltaTime;
        Vector3 mousePos = Input.mousePosition;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);

        if (!hit)
        {
            timerOutside += Time.deltaTime;
            if (timerOutside > 0.5)
            {
                Debug.Log("Outside");
                //controller.gameLost();
            }
        }
        else
            timerOutside = 0;

        timeLeft = timeLimit - timer;
        timerAmount.text = timeLeft.ToString("F2") + "s";
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlyToNestGame : MonoBehaviour
{
    public GameObject mainController;
    public Controller controller;
    public BirdController bird;

    public TextMeshProUGUI timerAmount;
    public float timeLimit;

    private float timer;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();
        bird = FindObjectOfType<BirdController>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (CountdownController.gameBegan)
            timer += Time.deltaTime;

        if (timer > timeLimit)
        {
            //controller.gameWon();
        }

        if(bird.gameOver)
        {
            //controller.gameLost();
        }

        timeLeft = timeLimit - timer;
        timerAmount.text = timeLeft.ToString("F2") + "s";
    }


}

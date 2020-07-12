using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlyToNestGame : MonoBehaviour
{
    public GameObject mainController;
    public Controller controller;
    public BirdController bird;

    public GameObject winText;
    public GameObject loseText;
    public AudioSource winTone;

    public TextMeshProUGUI timerAmount;
    public float timeLimit;

    public static bool gameOver;

    private float timer;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();
        bird = FindObjectOfType<BirdController>();
        timer = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CountdownController.gameBegan) return;
        if (gameOver) return;

        timer += Time.deltaTime;

        if (timer > timeLimit)
        {
            gameOver = true;
            StartCoroutine("MiniGameWin");
        }

        if(bird.gameOver)
        {
            gameOver = true;
            StartCoroutine("MiniGameLoss");
        }

        timeLeft = timeLimit - timer;
        timerAmount.text = timeLeft.ToString("F2") + "s";
    }

    IEnumerator MiniGameWin()
    {
        winText.SetActive(true);
        winTone.Play();
        yield return new WaitForSeconds(1f);
        controller.miniGameWon();
    }

    IEnumerator MiniGameLoss()
    {
        loseText.SetActive(false);
        yield return new WaitForSeconds(1f);
        controller.miniGameLost();
    }
}

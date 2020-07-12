using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StayWithTheCircleGame : MonoBehaviour
{
    private float timer;
    private float timeLeft;
    private float timerOutside;

    public static bool gameLoss;

    public float timeLimit;
    public TextMeshProUGUI timerAmount;

    public GameObject mainController;
    public Controller controller;

    public GameObject winText;
    public GameObject loseText;
    public AudioSource winTone;

    void Start()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();
        gameLoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CountdownController.gameBegan) return;
        if (gameLoss) return;

        timer += Time.deltaTime;
        Vector3 mousePos = Input.mousePosition;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);

        if(timer < timeLimit)
        {
            if (!hit)
            {
                timerOutside += Time.deltaTime;
                if (timerOutside > 0.5)
                {
                    gameLoss = true;
                    StartCoroutine("MiniGameLoss");
                }
            }
            else
                timerOutside = 0;
        }
        else
        {
            StartCoroutine("MiniGameWin");
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

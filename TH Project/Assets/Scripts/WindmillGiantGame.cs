using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindmillGiantGame : MonoBehaviour
{
    public GameObject mainController;
    public Controller controller;

    public GameObject winText;
    public GameObject loseText;
    public AudioSource winTone;
    public AudioSource meter;
    public bool canPlay;

    public float meterAmount;
    public float meterMaxAmount;
    public Slider meterGauge;
    public TextMeshProUGUI meterAmountValue;
    public TextMeshProUGUI timerAmount;
    public float timeLimit;

    public SpriteRenderer rend;
    public Sprite one;
    public Sprite two;

    private float meterCurrentAmount;
    private float timer;
    private float timeLeft;

    private void Awake()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();
    }

    private void Start()
    {
        meterCurrentAmount = 0;
        meterGauge.maxValue = meterMaxAmount;
        timer = 0f;
        canPlay = true;
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!CountdownController.gameBegan) return;

        timer += Time.deltaTime;

        meterGauge.value = meterCurrentAmount;

        if (timer <= timeLimit)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                meterCurrentAmount += 10;
                Mathf.Clamp(meterCurrentAmount, 0, 100f);
                rend.sprite = two;
                if (canPlay)
                {
                    meter.Play();
                    canPlay = false;
                }

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rend.sprite = one;
            }

            if (meterCurrentAmount >= meterMaxAmount)
            {
                StartCoroutine("MiniGameWin");
            }
        }
        else if (timer > timeLimit)
        {
            StartCoroutine("MiniGameLoss");
        }

        meterAmountValue.text = meterCurrentAmount.ToString("F0") + "%";
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
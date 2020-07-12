using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindmillGiantGame : MonoBehaviour
{
    public GameObject mainController;
    public Controller controller;

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
                rend.sprite = two;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rend.sprite = one;
            }

            if (meterCurrentAmount >= meterMaxAmount)
            {
                //controller.miniGameWon();
            }
        }
        else if (timer > timeLimit)
        {
            //controller.miniGameLost();
        }

        meterAmountValue.text = meterCurrentAmount.ToString("F0") + "%";
        timeLeft = timeLimit - timer;
        timerAmount.text = timeLeft.ToString("F2") + "s";
    }
}
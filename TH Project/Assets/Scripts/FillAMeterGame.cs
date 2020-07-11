using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillAMeterGame : MonoBehaviour
{
    public GameObject mainController;
    public Controller controller;

    public float meterAmount;
    public float meterMaxAmount;
    public Slider meterGauge;
    public TextMeshProUGUI meterAmountValue;
    public TextMeshProUGUI timerAmount;
    public float timeLimit;

    private float meterCurrentAmount;
    private float timer;
    private float timeLeft;
    //private string currentControl;
    private int currentControlIndex;

    // Start is called before the first frame update
    void Awake()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();
        meterCurrentAmount = 0;
        meterGauge.maxValue = meterMaxAmount;
        //currentControl = "";
        timer = 0f;
    }

    private void Start()
    {
        //ChangeControl();
    }

    // Update is called once per frame
    void Update()
    {
        if(CountdownController.gameBegan)
            timer += Time.deltaTime;

        meterGauge.value = meterCurrentAmount;

        if(timer <= timeLimit)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                meterCurrentAmount += 10;
            }
            if(meterCurrentAmount >= meterMaxAmount)
            {
                //controller.gameWin();
            }
        }
        else if (timer > timeLimit)
        {
            //controller.gameLoss();
        }

        meterAmountValue.text = meterCurrentAmount.ToString("F0") + "%";
        timeLeft = timeLimit - timer;
        timerAmount.text = timeLeft.ToString("F2") + "s";
    }

    /*void ChangeControl() //attempt to implement control change
    {
        currentControlIndex = Random.Range(1, 3);
        switch (currentControlIndex)
        {
            case 1:
                currentControl = "Space";
                break;
            case 2:
                currentControl = "R";
                break;
            case 3:
                currentControl = "B";
                break;
        default:
                currentControl = "Space";
                break;
        }
    }*/
}

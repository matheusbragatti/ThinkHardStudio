using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class DrawGunMinigame : MonoBehaviour
{
    public GameObject mainController;
    public Controller controller;

    public GameObject panel;

    public GameObject Enemy;

    public float timeLimit;

    private float timer;

    private bool state;

    private bool drawn = false;

    private bool textShow = false;

    public GameObject textFire;
    public GameObject textWin;
    public GameObject textLose;

    public GameObject textBox;

    public Text going;

    public GameObject m_otherScript;

    public Effects other;

    public bool gunShot = false;

    public bool PlayerLost = false;
    public GameObject Player;


    public GameObject Test;
    public Controller TestingC;

    void Start()

    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();

        textFire = GameObject.Find("Fire-Text");
        textFire.SetActive(false);
        Debug.Log("TETSING: " + textFire);
        textWin = GameObject.Find("Win-Text");
        textWin.SetActive(false);
        textLose = GameObject.Find("Lose");
        textLose.SetActive(false);

        startCountDown();
    }

    public bool allowClick = true;

    public SpriteRenderer renderingPlayer;
    public SpriteRenderer renderingEnemy;
    public Sprite[] playerFire;
    public Sprite[] enemyFire;

    private void Update()
    {
        if (textShow == true)
        {
            textFire.SetActive(true);
            textShow = false;
        }

        if (PlayerLost == true)
        { }

        if (gunShot == true)
        {
            Debug.Log("TOO LONG");
            allowClick = false;
            renderingEnemy.sprite = enemyFire[1];

            textLose.SetActive(true);
            textFire.SetActive(false);

                    textLose.SetActive(true);
                    //textFire = GameObject.Find("Fire-Text");
                    textFire.SetActive(false);
            controller.miniGameLost();
           // startCountDownEnemy();


        }

        if (allowClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pressed primary button.");
                if (drawn == true)
                {
                    textWin.SetActive(true);
                    Debug.Log("WON!");

                    textFire = GameObject.Find("Fire-Text");
                    textFire.SetActive(false);

                    renderingPlayer.sprite = playerFire[1];

                }
                else
                {
                    Debug.Log("LOST....");
                    renderingEnemy.sprite = enemyFire[1];
                    textLose.SetActive(true);
                    textFire = GameObject.Find("Fire-Text");
                    textFire.SetActive(false);

                    controller.miniGameLost();


                }

                allowClick = false;
            }
        }
    }

    private void startCountDown()
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        timeLimit = Random.Range(2000, 4000);
        aTimer.Interval = 3000;
        aTimer.Enabled = true;
        aTimer.Start();

        /*
        Here the game should show the enemy drew their gun
        and the user should click it.
        */
    }

    private void startCountDownEnemy()
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent2);
        timeLimit = Random.Range(2000, 4000);
        aTimer.Interval = 3000;
        aTimer.Enabled = true;
        aTimer.Start();

        /*
        Here the game should show the enemy drew their gun
        and the user should click it.
        */
    }

    public bool timeUP = true;
    public int track = 0;

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        if (gunShot != true)
        {
            if (timeUP == true)
            {
                Debug.Log("TIME UP");
                drawn = true;
                timeUP = false;
                textShow = true;
            }
            if (timeUP == false)
            {
                Debug.Log("TRACKING: " + track);
                track += 1;
                if (track == 2)
                {
                    gunShot = true;
                    Debug.Log("NOPE");
                }
                //Add failure state here
                //gunShot = true;
                // drawn = false;
            }
        }
    }

    private void OnTimedEvent2(object source, ElapsedEventArgs e)
    {
        textLose.SetActive(true);

        textFire = GameObject.Find("Fire-Text");
        textFire.SetActive(false);

        renderingEnemy.sprite = enemyFire[1];
        allowClick = false;
    }
}
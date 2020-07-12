using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DrawGunMinigame : MonoBehaviour
{

    public GameObject mainController;
    public Controller controller;

    public GameObject panel;

    public GameObject Enemy;

    public float timeLimit;

    private float timer;

    bool state;

    bool drawn = false;

    bool textShow = false;

    // Start is called before the first frame update
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

    //     //other = GameObject.Find("Passer");
    //     // Effects scr = GetComponent<Effects>();
    //     // scr.selectEffect("mouse");
    //      other.selectEffect("mouse");
    //     //other.GetComponent

    //     //Effects.selectEffect("mouse");


    //     //text.gameObject.SetActive(false);
    //     //CanvasGroup.alpha = 0f;
        textFire = GameObject.Find("Fire-Text");
        textFire.SetActive(false);
        Debug.Log("TETSING: " + textFire);
        textWin = GameObject.Find("Win-Text");
        textWin.SetActive(false);
        textLose = GameObject.Find("Lose");
        textLose.SetActive(false);

        //Player = GameObject.Find("AudioPlayer");
        //Player.GetComponent<Audio>().Play();

        


    //   //  GetComponent(textFire).enabled = false;
    //     //textFire.GetComponent<Text>().enabled = false;




    //     //textFire.enabled = false;
    //     // timer = 0;
    //     // timeLimit = Random.Range(2f, 4f);
         startCountDown();
    }


    public bool allowClick = true;


    public SpriteRenderer renderingPlayer;
    public SpriteRenderer renderingEnemy;
    public Sprite[] playerFire;
    public Sprite[] enemyFire;


    // Update is called once per frame
    void Update()
    {


        if(textShow == true)
        {
            textFire.SetActive(true);
            textShow = false;
        }

        if(PlayerLost == true)
        {}

        if(gunShot == true)
        {
            Debug.Log("TOO LONG");
            allowClick = false;
            renderingEnemy.sprite = enemyFire[1];
                    textLose.SetActive(true);
                    //textFire = GameObject.Find("Fire-Text");
                    textFire.SetActive(false);
            controller.miniGameLost();
           // startCountDownEnemy();

        }


        if(allowClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pressed primary button.");
                if(drawn == true)
                {
                   // textWin = GameObject.Find("Win-Text");
                    textWin.SetActive(true);
                    Debug.Log("WON!");

                    textFire = GameObject.Find("Fire-Text");
                    textFire.SetActive(false);
                    //rendering.sprite = enemyFire[1];

                    renderingPlayer.sprite = playerFire[1];
                    // AudioSource audioCheck;
                    // audioCheck = GetComponent<AudioSource>();
                    // audioCheck.mute = true;

                    // Test = GameObject.Find("TestController");
                    //   TestingC = Test.GetComponent<Controller>();
                    //   TestingC.miniGameWon();


                    //controller.miniGameWon();


                   // going = textFire2.GetComponent<Text>();
                    //going.text = "YOU WIN!";


                    //controller.miniGameWon();

                }
                else
                {
                    Debug.Log("LOST....");
                    //textLose = GameObject.Find("Lose");
                    renderingEnemy.sprite = enemyFire[1];
                    textLose.SetActive(true);
                    textFire = GameObject.Find("Fire-Text");
                    textFire.SetActive(false);
                    controller.miniGameLost();

                }


                allowClick = false;
            }


        }



        // if (CountdownController.gameBegan)
        //     timer += Time.deltaTime;

        // if (timer > timeLimit)
        // {
        //     drawn = true;
        //     startCountDown();
        //     //controller.gameLoss();
        // }

        // if(bird.gameOver)
        // {
        //     //controller.gameLoss();
        // }
    }

    void startCountDown()
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

    void startCountDownEnemy()
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
        if(gunShot != true)
        {
            if(timeUP == true)
            {
                Debug.Log("TIME UP");
                drawn = true;
                // textFire = GameObject.Find("Fire-Text");
                // textFire.SetActive(true);
                timeUP = false;
                textShow = true;
                //gunShot = true;
                //startCountDown();
                

            }
            if(timeUP == false)
            {
                Debug.Log("TRACKING: " + track);
                track += 1;
                if(track == 2)
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
    Debug.Log("ENEMY WON");
    textLose.SetActive(true);
                    //Debug.Log("WON!");

                    textFire = GameObject.Find("Fire-Text");
                    textFire.SetActive(false);
                    //rendering.sprite = enemyFire[1];

                    renderingEnemy.sprite = enemyFire[1];
                    allowClick = false;




}



       
    




}

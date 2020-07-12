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

    private void Start()
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
        textWin = GameObject.Find("Win-Text");
        textWin.SetActive(false);
        textLose = GameObject.Find("Lose");
        textLose.SetActive(false);

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
    private void Update()
    {
        if (textShow == true)
        {
            textFire.SetActive(true);
            textShow = false;
        }

        if (gunShot == true)
        {
            //Debug.Log("TOO LONG");
            // allowClick = false;
            // renderingEnemy.sprite = enemyFire[1];
            //         textLose.SetActive(true);
            //         textFire = GameObject.Find("Fire-Text");
            //         textFire.SetActive(false);
        }

        if (allowClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pressed primary button.");
                if (drawn == true)
                {
                    // textWin = GameObject.Find("Win-Text");
                    textWin.SetActive(true);
                    Debug.Log("WON!");

                    textFire = GameObject.Find("Fire-Text");
                    textFire.SetActive(false);
                    //rendering.sprite = enemyFire[1];

                    renderingPlayer.sprite = playerFire[1];

                    // going = textFire2.GetComponent<Text>();
                    //going.text = "YOU WIN!";

                    controller.miniGameWon();
                }
                else
                {
                    Debug.Log("LOST....");
                    //textLose = GameObject.Find("Lose");
                    renderingEnemy.sprite = enemyFire[1];
                    textLose.SetActive(true);
                    textFire = GameObject.Find("Fire-Text");
                    textFire.SetActive(false);
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

    public bool timeUP = true;

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        if (gunShot != true)
        {
            if (timeUP == true)
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
            if (timeUP == false)
            {
                Debug.Log("NOPE");
                //Add failure state here
                //gunShot = true;
                // drawn = false;
            }
        }

        //Console.WriteLine("Hello World!");
    }
}
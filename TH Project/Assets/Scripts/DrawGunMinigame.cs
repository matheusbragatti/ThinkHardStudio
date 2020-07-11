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

    public GameObject textBox;

    public GameObject m_otherScript;

    public Effects other;
    
    
    void Start()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();
         
        //other = GameObject.Find("Passer");
        
        other.selectEffect("mouse");
        //other.GetComponent


        //text.gameObject.SetActive(false);
        //CanvasGroup.alpha = 0f;
        textFire = GameObject.Find("Fire-Text");
        Debug.Log("TETSING: " + textFire);
      //  GetComponent(textFire).enabled = false;
        //textFire.GetComponent<Text>().enabled = false;
        
        textFire.SetActive(false);


        //textFire.enabled = false;
        // timer = 0;
        // timeLimit = Random.Range(2f, 4f);
        startCountDown();
    }


    public bool allowClick = true;

    // Update is called once per frame
    void Update()
    {


        if(textShow == true)
        {
            textFire.SetActive(true);
        }


        if(allowClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pressed primary button.");
                if(drawn == true)
                {
                    Debug.Log("WON!");
                    //controller.miniGameWon();
                    
                }
                else
                {
                    Debug.Log("LOST....");
                    //controller.miniGameLost();
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
        aTimer.Interval = timeLimit;
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
        if(timeUP == true)
        {
            Debug.Log("TIME UP");
            drawn = true;
            // textFire = GameObject.Find("Fire-Text");
            // textFire.SetActive(true);
            timeUP = false;
            textShow = true;
            
        }
        
        
        //Console.WriteLine("Hello World!");
    }


   

}

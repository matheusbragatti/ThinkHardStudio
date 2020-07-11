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

    // Start is called before the first frame update
    void Start()
    {
         mainController = GameObject.FindGameObjectWithTag("GameController");
         controller = mainController.GetComponent<Controller>();
        
        // timer = 0;
        // timeLimit = Random.Range(2f, 4f);
        //startCountDown();
    }


    public bool allowClick = true;

    // Update is called once per frame
    void Update()
    {

        if(allowClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pressed primary button.");
                allowClick = false;
            }
           

        }
        
        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed secondary button.");

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");


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
        aTimer.Interval = 3000;
        aTimer.Enabled = true;
        aTimer.Start();

        /*
        Here the game should show the enemy drew their gun
        and the user should click it. 
        */
        
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        drawn = true;
        
        //Console.WriteLine("Hello World!");
    }


    // void OnMouseDown(){
    //     //Check to see if the enemy pulled their gun and 
    //     //then reply either true or false
    //     if(drawn == true)
    //     {

    //     }
    //     else
    //     {
    //         controller.gameLoss();
    //     }

    //       state = !state; 
    //       panel.gameObject.SetActive (state);
    //     //Debug.log("I CLICKED");
    // }

}

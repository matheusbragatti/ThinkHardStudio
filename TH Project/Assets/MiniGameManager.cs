using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public GameObject mainController;
    public Controller controller;
    public int miniGamesLives;


    // Start is called before the first frame update
    void Start()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent < Controller > ();
    }

    // Update is called once per frame
    void Update()
    {
        if(miniGamesLives <= 0)
        {
            controller.lifeCounter -= 1;
        }
    }

}

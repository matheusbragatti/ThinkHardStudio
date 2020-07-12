using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    private GameObject mainController;
    private Controller controller;


    // Start is called before the first frame update
    void Start()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();
    }


    public void restartGame()
    {
        controller.restartGame();
    }


}

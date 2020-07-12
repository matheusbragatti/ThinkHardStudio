using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    private GameObject mainController;
    private Controller controller;
    public AudioSource backgroundMusic;


    // Start is called before the first frame update
    void Start()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();
        backgroundMusic.Play();
    }


    public void restartGame()
    {
        controller.restartGame();
        backgroundMusic.Stop();
    }

}

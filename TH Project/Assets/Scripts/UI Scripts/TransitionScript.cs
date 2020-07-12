using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    private GameObject mainController;
    private Controller controller;


    private void Start()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();
    }


    public void continueGame()
    {
        string miniGamePicked;

        miniGamePicked = controller.pickRandomGame();
        SceneManager.LoadScene(miniGamePicked);
    }
}

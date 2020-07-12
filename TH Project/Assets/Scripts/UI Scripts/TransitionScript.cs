using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour
{
    private GameObject mainController;
    private Controller controller;
    public TextMeshProUGUI lifesText;
    public TextMeshProUGUI miniGamesLeftText;


    private void Start()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();
        lifesText.text = controller.lifeCounter + " Lifes left";
        miniGamesLeftText.text = controller.miniGamesLeft + " Games left";
    }


    public void continueGame()
    {
        string miniGamePicked;

        miniGamePicked = controller.pickRandomGame();
        SceneManager.LoadScene(miniGamePicked);
    }
}

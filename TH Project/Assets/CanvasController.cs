using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public Controller mainController;
    public string gamePicked;
   


    void startGame()
    {


        gamePicked = mainController.pickRandomGame();
        SceneManager.LoadScene(gamePicked);
    }
  



}

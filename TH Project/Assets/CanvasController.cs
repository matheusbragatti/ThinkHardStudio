using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public Controller mainController;

    


    void startGame()
    {
        Instantiate(mainController);
        mainController.liveCounter = 3;
    }



}

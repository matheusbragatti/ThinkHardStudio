using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public int lifeCounter;
    public int miniGamesLeft;
    public int randomMiniGame;
    public string miniGame;


    private void Awake()
    {

    }


    void Start()
    {
        lifeCounter = 3;
        miniGamesLeft = 10;
    }

    void Update()
    {

    }

    public void changeLives(int value)
    {
        this.lifeCounter += value;

        if(this.lifeCounter <= 0)
        {
            //Trigger game over method.
        }

    }




    public string pickRandomGame()
    {
        randomMiniGame = Random.Range(1, 5);

        switch (randomMiniGame)
        {
            case 0:
                miniGame = "Pong";
                break;

            case 1:

                break;

        }
        return miniGame;
    }
}

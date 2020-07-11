using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public int lifeCounter;
    public int miniGamesLeft;
    public int randomMiniGame;
    public string miniGame;
    public int maxGames;
    public List<int> playedMiniGames;

    private void Awake()
    {
        //Make this object a singleton
    }


    void Start()
    {

        lifeCounter = 3;
        miniGamesLeft = 10;
    }

    void Update()
    {

    }

    public void startGame()
    {
        string firstMiniGame;
        //Play Intro
        //
        //---


        firstMiniGame = pickRandomGame();

        SceneManager.LoadScene(firstMiniGame);


    }

    public void miniGameWon()
    {
        string miniGamePicked;

        this.miniGamesLeft--;
        if(miniGamesLeft <= 0)
        {
            //Trigger you won
        }
        else
        {

            //Trigger minigame transition

            miniGamePicked = pickRandomGame();
            SceneManager.LoadScene(miniGamePicked);

        }

    }

    public void miniGameLost()
    {
        string miniGamePicked;

        this.lifeCounter--;

        if(this.lifeCounter <= 0)
        {
            //Trigger game over method.
        }
        else
        {
            //Trigger minigame transition

            miniGamePicked = pickRandomGame();
            SceneManager.LoadScene(miniGamePicked);
        }

    }

    public string pickRandomGame()
    {
        randomMiniGame = Random.Range(1, maxGames);
        while (playedMiniGames.Contains(randomMiniGame))
        {
            if(playedMiniGames.Count >= maxGames)
            {
                return "MainScene";
            }
            randomMiniGame = Random.Range(1, maxGames);
        }

        switch (randomMiniGame)
        {
            case 0:
                miniGame = "Pong";
                break;

            case 1:

                break;

        }
        playedMiniGames.Add(randomMiniGame);
        return miniGame;
    }

}
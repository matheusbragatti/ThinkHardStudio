using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{

    public static Controller Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int lifeCounter;
    public int miniGamesLeft;
    public int randomMiniGame;
    public string miniGame;
    public int maxGames;
    public List<int> playedMiniGames;
    public bool logoPlayed;

    void Start()
    {
        maxGames = 4;
        logoPlayed = false;
    }

    void Update()
    {

    }

    public void miniGameWon()
    {

        this.miniGamesLeft--;
        if(miniGamesLeft <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            SceneManager.LoadScene("TransitionScene");
        }

    }

    public void miniGameLost()
    {

        this.lifeCounter--;

        if(this.lifeCounter <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
        else
        {
            SceneManager.LoadScene("TransitionScene");
        }

    }

    public string pickRandomGame()
    {
        randomMiniGame = Random.Range(0, maxGames);
        while (playedMiniGames.Contains(randomMiniGame))
        {
            if(playedMiniGames.Count >= maxGames)
            {
                playedMiniGames.Clear();
            }
            randomMiniGame = Random.Range(0, maxGames);
        }

        switch (randomMiniGame)
        {
            case 0:
                miniGame = "GiantAndWindmill";
                break;

            case 1:
                miniGame = "FlyToNest";
                break;

            case 2:
                miniGame = "StayWithTheCircle";
                break;

            case 3:
                miniGame = "DrawGunScene";
                break;

        }
        playedMiniGames.Add(randomMiniGame);
        return miniGame;
    }

    public void restartGame()
    {
        lifeCounter = 3;
        miniGamesLeft = 10;
        playedMiniGames.Clear();
        SceneManager.LoadScene("MainScene");
    }

}
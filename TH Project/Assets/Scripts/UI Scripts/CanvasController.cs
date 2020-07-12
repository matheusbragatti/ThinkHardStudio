using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class CanvasController : MonoBehaviour
{
    private GameObject mainController;
    private Controller controller;
    public string gamePicked;
    public VideoPlayer introVideoPlayer;
    public VideoPlayer logoVideoPlayer;
    public GameObject panel;
    public GameObject playButton;


    private void Start()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();
        panel.SetActive(false);
        if (!controller.logoPlayed)
        {
            StartCoroutine(playLogo());
            controller.logoPlayed = true;
        }
        else
        {
            panel.SetActive(true);
        }
        
    }

    public void startGame()
    {
        playButton.SetActive(false);

        controller.lifeCounter = 3;
        controller.miniGamesLeft = 10;
        controller.playedMiniGames.Clear();

        StartCoroutine(prepareVideo());
        
    }

    IEnumerator prepareVideo()
    {
        introVideoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!introVideoPlayer.isPrepared)
        {
            yield return waitForSeconds;
        }
        panel.SetActive(false);
        introVideoPlayer.Play();
        while (introVideoPlayer.isPlaying)
        {
            yield return waitForSeconds;
        }
        gamePicked = controller.pickRandomGame();
        SceneManager.LoadScene(gamePicked);
    }

    IEnumerator playLogo()
    {
        logoVideoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!logoVideoPlayer.isPrepared)
        {
            yield return waitForSeconds;
        }
        panel.SetActive(false);
        logoVideoPlayer.Play();
        while (logoVideoPlayer.isPlaying)
        {
            yield return waitForSeconds;
        }
        panel.SetActive(true);
    }


    public void options()
    {

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void setTransitionInfo()
    {

    }

}

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
    public VideoPlayer videoPlayer;
    public GameObject panel;
    public GameObject playButton;
    public Text lifesText;
    public Text miniGamesLeftText;

    private void Start()
    {
        mainController = GameObject.FindGameObjectWithTag("GameController");
        controller = mainController.GetComponent<Controller>();
        lifesText.text = controller.lifeCounter + " Lifes left";
        miniGamesLeftText.text = controller.miniGamesLeft + "Games left";
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
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
        }
        panel.SetActive(false);
        videoPlayer.Play();
        while (videoPlayer.isPlaying)
        {
            yield return waitForSeconds;
        }
        gamePicked = controller.pickRandomGame();
        SceneManager.LoadScene(gamePicked);
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

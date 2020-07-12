using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CanvasController : MonoBehaviour
{
    public Controller mainController;
    public string gamePicked;
    public VideoPlayer videoPlayer;
    public GameObject panel;
    public GameObject playButton;

  


    public void startGame()
    {       
        StartCoroutine(prepareVideo());
        playButton.SetActive(false);
        
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
        gamePicked = mainController.pickRandomGame();
        SceneManager.LoadScene(gamePicked);

    }

}

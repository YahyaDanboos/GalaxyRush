using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject uiCanvas;

    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.pauseGame += TogglePause;
    }

    void OnDestroy()
    {
        PlayerController.pauseGame -= TogglePause;
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;

            uiCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;

            uiCanvas.SetActive(false);
        }
    }

    public void Continue()
    {
        TogglePause();
    }
    public void Retry()
    {
        TogglePause();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
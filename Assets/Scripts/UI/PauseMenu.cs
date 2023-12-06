using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

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

            pauseMenuUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;

            pauseMenuUI.SetActive(false);
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
        TogglePause();

        SceneManager.LoadScene(0);
    }
}

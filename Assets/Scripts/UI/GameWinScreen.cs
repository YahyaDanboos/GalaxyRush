using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinScreen : MonoBehaviour
{
    public GameObject gameWinUI;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameWin += ToggleGameWinScreen;
    }

    void OnDestroy()
    {
        GameManager.gameWin -= ToggleGameWinScreen;
    }

    void ToggleGameWinScreen()
    {
        gameWinUI.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

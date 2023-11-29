using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public CanvasGroup gameOverUI;
   
    float fadeDuration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameOver += ToggleGameOverScreen;
    }

    void OnDestroy()
    {
        GameManager.gameOver -= ToggleGameOverScreen;
    }

    void ToggleGameOverScreen()
    {
        StartCoroutine(FadeGameOverScreen());
    }

    IEnumerator FadeGameOverScreen()
    {
        float elapsedTime = 0;
        gameOverUI.gameObject.SetActive(true);
        gameOverUI.alpha = 0;

        while (elapsedTime < fadeDuration)
        {
            gameOverUI.alpha = elapsedTime / fadeDuration;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameOverUI.alpha = 1;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Prefab References")]
    public GameObject playerPrefab;

    [Header("Player Stats")]
    int playerLives = 3;

    // Player's health component reference
    Health playerHealthReference;

    // Game Over Event
    public static event Action gameOver;

    // Game Win Event
    public static event Action gameWin;

    // Player Lives change Events
    public static event Action removePlayerLife;
    public static event Action addPlayerLife;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Spawns the Player
    void SpawnPlayer()
    {
        // Calculate a position at the bottom of the screen
        float offsetFromBottom = 0.1f;
        Camera mainCamera = Camera.main;
        Vector2 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector2(0.5f, offsetFromBottom));

        // Spawn Player
        playerHealthReference = Instantiate(playerPrefab, spawnPosition, Quaternion.identity).GetComponent<Health>();

        // Subscribe to the player instance's defeat event
        playerHealthReference.characterDefeated += PlayerDefeated;
        playerHealthReference.addLife += AddPlayerLife;
    }

    // Called by the player when it's defeated
    void PlayerDefeated()
    {
        // Unsubscribe from the player instance's Defeated and AddPlayerLife event
        playerHealthReference.characterDefeated -= PlayerDefeated;
        playerHealthReference.addLife -= AddPlayerLife;

        playerLives--;
        removePlayerLife?.Invoke();

        if (playerLives <= 0)
            GameOver();
        else
            Respawn();
    }

    // Add a life to the player if there are less than 3 lives
    void AddPlayerLife()
    {
        if (playerLives < 3)
        {
            playerLives++;
            addPlayerLife?.Invoke();
        }
    }

    // Starts the player respawning phase
    void Respawn()
    {
        StartCoroutine(RespawnRoutine());
    }

    IEnumerator RespawnRoutine()
    {
        yield return new WaitForSeconds(2f);

        SpawnPlayer();
    }

    // Called when the game is over
    void GameOver()
    {
        gameOver?.Invoke();
    }

    // Called when the game is won
    public void GameWin()
    {
        gameWin?.Invoke();
    }

    void OnDestroy()
    {
        // Unsubscribe from the player instance's Defeated and AddPlayerLife event
        playerHealthReference.characterDefeated -= PlayerDefeated;
        playerHealthReference.addLife -= AddPlayerLife;
    }
}

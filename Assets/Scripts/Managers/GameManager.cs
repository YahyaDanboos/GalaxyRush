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
    public int playerLives = 3;
    public int playerScore;

    Health playerHealthReference;

    public static event Action gameOver;

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
    }

    // Called by the player when it's defeated
    public void PlayerDefeated()
    {
        // Unsubscribe to the player instance's defeat event
        playerHealthReference.characterDefeated -= PlayerDefeated;

        playerLives--;

        if (playerLives <= 0)
            GameOver();
        else
            Respawn();
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
        print("Game Over");

        gameOver?.Invoke();
    }
}
